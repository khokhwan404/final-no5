class TreeNode<T> where T : IComparable<T>
{
    private T value;
    private TreeNode<T> left = null;
    private TreeNode<T> right = null;

    public TreeNode(T value)
    {
        this.SetValue(value);
    }

    public void SetLeft(TreeNode<T> left)
    {
        this.left = left;
    }

    public void SetRight(TreeNode<T> right)
    {
        this.right = right;
    }

    public TreeNode<T> Left()
    {
        return this.left;
    }

    public TreeNode<T> Right()
    {
        return this.right;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}