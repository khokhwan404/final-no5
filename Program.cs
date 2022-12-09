using System;
class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();
        InputNumber(tree);
    }

    static void InputNumber(BinaryTree<int> tree)
    {
        int inputNode;
        while(true)
        {
            inputNode = int.Parse(Console.ReadLine());
            if(inputNode <= 0)
            {
                break;
            }
            else
            {
                tree.Add(inputNode);
            }
        }
    }
}
