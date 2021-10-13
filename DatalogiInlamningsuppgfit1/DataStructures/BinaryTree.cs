using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgfit1.DataStructures
{
    public class BinaryTree
    {
        public Node Root { get; set; }
        public string TreeAsString { get; set; }

        // Adds a value to the binary tree, thus creating a Node
        public bool Add(int val)
        {
            Node before = null;
            Node next = this.Root;

            while(next != null)
            {
                before = next;
                // Checks if the new node is in the left of the tree
                if(val < next.Data)
                {
                    next = next.Left;
                }
                // Checks if the new node is in the right of the tree
                else if(val > next.Data)
                {
                    next = next.Right;
                }
                else
                {
                    // If the value already exists
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = val;

            // Checks if the tree is empty
            if(this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if(val < before.Data)
                {
                    before.Left = newNode;
                }
                else
                {
                    before.Right = newNode;
                }
            }

            return true;
        }

        public Node Find(int val)
        {
            return this.Find(val, this.Root);
        }

        public void Remove(int val)
        {
            this.Root = Remove(this.Root, val);
        }

        public string TraversePreOrder()
        {
            TreeAsString = "";
            TraversePreOrder(this.Root);
            return TreeAsString;
        }

        public string TraverseInOrder()
        {
            TreeAsString = "";
            TraverseInOrder(this.Root);
            return TreeAsString;
        }

        // Gets the max value in the binary tree
        public int MaxVal()
        {
            int maxVal = this.Root.Data;
            Node newNode = this.Root;

            while(newNode.Right != null)
            {
                maxVal = newNode.Right.Data;
                newNode = newNode.Right;
            }

            return maxVal;
        }

        private void TraverseInOrder(Node parent)
        {
            if(parent != null)
            {
                TraverseInOrder(parent.Left);
                TreeAsString += parent.Data + " ";
                TraverseInOrder(parent.Right);
            }
        }

        private void TraversePreOrder(Node parent)
        {
            if(parent != null)
            {
                TreeAsString += parent.Data + " ";
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }

        // Recursive Remove method
        private Node Remove(Node parent, int val)
        {
            if(parent == null)
            {
                return parent;
            }
            
            if(val < parent.Data)
            {
                parent.Left = Remove(parent.Left, val);
            }
            else if(val > parent.Data)
            {
                parent.Right = Remove(parent.Right, val);
            }

            // If value is the same as parent.Data. This is the node to be deleted.
            else
            {
                // Node only haas one child or no children
                if (parent.Left == null)
                {
                    return parent.Right;
                }
                else if (parent.Right == null)
                {
                    return parent.Left;
                }

                parent.Data = MinVal(parent.Right);

                parent.Right = Remove(parent.Right, parent.Data);
            }

            return parent;
        }

        // Gets the node with the smallest value
        private int MinVal(Node node)
        {
            int minVal = node.Data;
            while(node.Left != null)
            {
                minVal = node.Left.Data;
                node = node.Left;
            }

            return minVal;
        }

        // Recursive method of finding the node with the Value
        // If no node is found, return null
        private Node Find(int val, Node parent)
        {
            if(parent != null)
            {
                if(val == parent.Data)
                {
                    return parent;
                }

                if(val < parent.Data)
                {
                    return Find(val, parent.Left);
                }
                else
                {
                    return Find(val, parent.Right);
                }
            }

            return null;
        }
    }
}
