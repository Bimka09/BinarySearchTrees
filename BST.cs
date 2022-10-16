namespace BinarySearchTrees_AVL
{
    public class BST
    {
        public BST_Node? Root { get; set; }
        public void Insert(int value)
        {
            if(Root == null)
            {
                Root = new BST_Node()
                {
                    Value = value
                };
            }
            else
            {
                Root = Insert(value, Root, Root);
            }
            Root.Height = CalcuateHeight(Root);
        }
        private BST_Node Insert(int value, BST_Node? node, BST_Node parentNode)
        {
            if(node == null)
            {
                node = new BST_Node()
                {
                    Parent = parentNode,
                    Value = value
                };
                return node;
            }
            else if (node.Value < value)
            {
                node.RightNode = Insert(value, node.RightNode, node);
                return node;
            }
            else if (node.Value > value)
            {
                node.LeftNode = Insert(value, node.LeftNode, node);
                return node;
            }
            else
            {
                node.Counter++;
                return node;
            }
        }
        private int CalcuateHeight(BST_Node node)
        {
            var leftHeight = 1;
            var rightHeight = 1;
            if (node.LeftNode == null & node.RightNode == null)
            {
                node.Height = 1;
                return node.Height;
            }
            if(node.LeftNode != null)
            {
                leftHeight = CalcuateHeight(node.LeftNode);
            }
            if (node.RightNode != null)
            {
                rightHeight = CalcuateHeight(node.RightNode);
            }
            node.Height = Math.Max(leftHeight, rightHeight) + 1;
            return node.Height;
        }
        public bool Search(int value)
        {
            if(Root != null)
            {
                return Search(value, Root);
            }
            else
            {
                return false;
            }
        }
        private bool Search(int value, BST_Node? node)
        {
            if (node != null)
            {
                if (node.Value == value)
                {
                    return true;
                }
                else if (node.Value > value)
                {
                    return Search(value, node.LeftNode);
                }
                else
                {
                    return Search(value, node.RightNode);
                }
            }
            else
            {
                return false;
            }
        }
        private BST_Node? SearchNode(int value, BST_Node? node)
        {
            if (node != null)
            {
                if (node.Value == value)
                {
                    return node;
                }
                else if (node.Value > value)
                {
                    return SearchNode(value, node.LeftNode);
                }
                else
                {
                    return SearchNode(value, node.RightNode);
                }
            }
            else
            {
                //throw new ArgumentException("Value not found");
                return null;
            }
        }
        public void Remove(int value)
        {
            var nodeToDelete = SearchNode(value,Root);
            if(nodeToDelete == null)
            {
                return;
            }
            if(nodeToDelete.Counter != 0)
            {
                nodeToDelete.Counter--;
                return;
            }
            var nodeForRepalce = FindValueForReplace(value, nodeToDelete);
            nodeToDelete.Value = nodeForRepalce.Value;
            if (nodeForRepalce == nodeForRepalce.Parent.RightNode)
            {
                nodeForRepalce.Parent.RightNode = nodeForRepalce.RightNode;
            }
            else
            {
                nodeForRepalce.Parent.LeftNode = nodeForRepalce.LeftNode;
            }
            nodeForRepalce = null;
            if(Root != null)
            {
                Root.Height = CalcuateHeight(Root);
            }
        }
        private BST_Node FindValueForReplace(int value, BST_Node node)
        {
            if(node.LeftNode != null & node.RightNode != null)
            {
                if(node.LeftNode.Height > node.RightNode.Height)
                {
                    return DigToLastNode(node.LeftNode, false);
                }
                else
                {
                    return DigToLastNode(node.RightNode, true);
                }
            }
            else if(node.LeftNode == null & node.RightNode == null)
            {
                return node;
            }
            else if(node.LeftNode == null)
            {
                return DigToLastNode(node.RightNode, true);
            }
            else
            {
                return DigToLastNode(node.LeftNode, true);
            }    
        }
        private BST_Node DigToLastNode(BST_Node node, bool leftDirection)
        {
            if (leftDirection == true)
            {
                while (node.LeftNode != null)
                {
                    node = node.LeftNode;
                }
                return node;
            }
            else
            {
                while (node.RightNode != null)
                {
                    node = node.RightNode;
                }
                return node;
            }
        }
        public void Sort()
        {
            PrintAscending(Root);
        }
        private void PrintAscending(BST_Node node)
        {
            if(node.LeftNode != null)
            {
                PrintAscending(node.LeftNode);
            }
            for(int i = 0; i <= node.Counter; i++)
            {
                Console.WriteLine(node.Value);
            }        
            if (node.RightNode != null)
            {
                PrintAscending(node.RightNode);
            }
        }
    }
}
