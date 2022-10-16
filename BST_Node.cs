namespace BinarySearchTrees_AVL
{
    public class BST_Node
    {
        public BST_Node? Parent { get; set; }
        public BST_Node? LeftNode { get; set; }
        public BST_Node? RightNode { get; set; }
        public int Value { get; set; }
        public int Counter { get; set; }
        public int Height { get; set; }
    }
}
