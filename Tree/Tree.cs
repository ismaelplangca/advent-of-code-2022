namespace MyTree;
using System.Collections;
public class Tree<T> : IEnumerable<Tree<T>>
{
    public T Data { get; set; }
    public Tree<T>? Parent { get; set; }
    public ICollection<Tree<T> > Children { get; set; }

    public Boolean IsRoot
    {
        get { return Parent == null; }
    }

    public Boolean IsLeaf
    {
        get { return Children.Count == 0; }
    }

    public int Level
    {
        get
        {
            if(this.IsRoot)
                return 0;
            return Parent!.Level + 1;
        }
    }
    public Tree(T data)
    {
        this.Data = data;
        this.Children = new LinkedList<Tree<T> >();

        this.ElementsIndex = new LinkedList<Tree<T> >();
        this.ElementsIndex.Add(this);
    }
    public Tree<T> AddChild(T child)
    {
        Tree<T> childNode = new Tree<T>(child) { Parent = this };
        this.Children.Add(childNode);

        this.RegisterChildForSearch(childNode);

        return childNode;
    }
    public override string ToString()
    {
        return Data != null ? Data.ToString()! : "[data null]";
    }
    #region seaching

    private ICollection<Tree<T> > ElementsIndex { get; set; }

    private void RegisterChildForSearch(Tree<T> node)
    {
        ElementsIndex.Add(node);
        if (Parent != null)
            Parent.RegisterChildForSearch(node);
    }

    public Tree<T> FindTreeNode(Func<Tree<T>, bool> predicate)
    {
        return this.ElementsIndex.FirstOrDefault(predicate)!;
    }

    #endregion

    #region iterating

    public IEnumerator<Tree<T>> GetEnumerator()
    {
        yield return this;
        foreach(var directChild in this.Children)
        {
            foreach(var anyChild in directChild)
                yield return anyChild;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}