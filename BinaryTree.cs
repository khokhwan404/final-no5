class BinaryTree<T> where T : IComparable<T>
{
    protected TreeNode<T> root = null;
    protected int length = 0;

    public void Add(T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(this.root == null)
        {
            this.root = node;
        }
        else
        {
            Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
            nodeQueue.Push(this.root);

            TreeNode<T> ptr;
            while(nodeQueue.GetLength() > 0)
            {
                ptr = nodeQueue.Pop();
                if(ptr.Left() == null)
                {
                    ptr.SetLeft(node);
                    break;
                }
                else if(ptr.Right() == null)
                {
                    ptr.SetRight(node);
                    break;
                }
                else
                {
                    nodeQueue.Push(ptr.Left());
                    nodeQueue.Push(ptr.Right());
                }
            }
        }
        this.length++;
    }

    public void AddLeft(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetLeft(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetLeft(ptr.Left());
            ptr.SetLeft(node);
        }
        this.length++;
    }

    public void AddRight(int index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(index == -1)
        {
            node.SetLeft(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetRight(ptr.Right());
            ptr.SetRight(node);
        }
        this.length++;
    }

    public void Remove(int index)
    {
        if(index == 0)
        {
            TreeNode<T> ptr = this.root;
            this.root = ptr.Left();
            if(this.root.Right() != null)
            {
                this.root.SetLeft(this.root.Right());
                this.root.SetRight(null);
            }
        }
        else
        {
            TreeNode<T> previousPtr = this.GetTreeNode(index-1);
            if(previousPtr.Left() != null)
            {
                TreeNode<T> ptr = previousPtr.Left();

                if(ptr.Right() != null)
                {
                    previousPtr.SetLeft(ptr.Left());
                    ptr.Right().SetRight(ptr.Right());
                }
                else
                {
                    previousPtr.SetLeft(ptr.Right());
                }
            }
            else
            {
                TreeNode<T> ptr = previousPtr.Right();

                if(ptr.Left() != null)
                {
                    previousPtr.SetRight(ptr.Left());
                    ptr.Left().SetRight(ptr.Right());
                }
                else
                {
                    previousPtr.SetRight(ptr.Right());
                }
            }
        }
        this.length--;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    private TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;

        if(traverseStep > 0 && currentTreeNode.Left() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Left(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Right() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Right(), ref traverseStep);
        }

        return ptr;
    }

    private TreeNode<T> Search(T value)
    {
        Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
        nodeQueue.Push(this.root);

        TreeNode<T> ptr;
        while(nodeQueue.GetLength() > 0)
        {
            ptr = nodeQueue.Pop();
            if(ptr.GetValue().CompareTo(value) == 0)
            {
                return ptr;
            }
            else
            {
                if(ptr.Left() != null)
                {
                    nodeQueue.Push(ptr.Left());
                }
                if(ptr.Right() != null)
                {
                    nodeQueue.Push(ptr.Right());
                }
            }
        }

        return null;
    }

    public void GetAllOpponents(T value)
    {
        TreeNode<T> ptr = this.Search(value);
        while(ptr != null)
        {
            if(ptr.Left() != null && ptr.Right() != null)
            {
                if(ptr.Left().GetValue().CompareTo(value) == 0)
                {
                    Console.WriteLine(ptr.Right().GetValue());
                    ptr = ptr.Left();
                }
                else
                {
                    Console.WriteLine(ptr.Left().GetValue());
                    ptr = ptr.Right();
                }
            }
            else
            {
                break;
            }
        }
    }
}