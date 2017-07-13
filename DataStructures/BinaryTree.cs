using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Node<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public T Value { get; set; }
        public Node() { }
        public Node(T Value) { this.Value = Value; }
    }

    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Node<T> RootNode { get; set; }

        public BinaryTree() { }

        public Node<T> Find(Node<T> current, T value)
        {
            if (current == null)
                return null;
            if (current.Value.Equals(value))
                return current;
            if (value.CompareTo(current.Value) < 0)
                return Find(current.LeftNode, value);

            return Find(current.RightNode, value);
        }

        public void Add(T value)
        {
            if (RootNode == null)
            {
                RootNode = new Node<T>(value);
                return;
            }
            Node<T> currentNode = RootNode;
            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = new Node<T>(value);
                        return;
                    }
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    if (currentNode.RightNode == null)
                    {
                        currentNode.RightNode = new Node<T>(value);
                        return;
                    }
                    currentNode = currentNode.RightNode;
                }

            }
        }

        public bool Remove(T value)
        {
            Node<T> focusNode = RootNode;
            Node<T> parent = RootNode;
            bool isLeftChild = true;

            while (!focusNode.Value.Equals(value))
            {
                parent = focusNode;
                if (value.CompareTo(focusNode.Value) < 0)
                {
                    isLeftChild = true;
                    focusNode = focusNode.LeftNode;
                }
                else
                {
                    isLeftChild = false;
                    focusNode = focusNode.RightNode;
                }

                if (focusNode == null)
                    return false;

            }


            if (focusNode.LeftNode == null && focusNode.RightNode == null)
            {
                if (focusNode == RootNode)
                    RootNode = null;
                else if (isLeftChild)
                    parent.LeftNode = null;
                else
                    parent.RightNode = null;
            }
            else if (focusNode.RightNode == null)
            {
                if (focusNode == RootNode)
                    RootNode = focusNode.LeftNode;
                else if (isLeftChild)
                    parent.LeftNode = focusNode.LeftNode;
                else
                    parent.RightNode = focusNode.LeftNode;
            }
            else if (focusNode.LeftNode == null)
            {
                if (focusNode == RootNode)
                    RootNode = focusNode.RightNode;
                else if (isLeftChild)
                    parent.LeftNode = focusNode.RightNode;
                else
                    parent.RightNode = focusNode.RightNode;
            }
            else
            {
                Node<T> replacement = GetReplacementNode(focusNode);
                if (focusNode == RootNode)
                    RootNode = replacement;
                else if (isLeftChild)
                    parent.LeftNode = replacement;
                else
                    parent.RightNode = replacement;
                replacement.LeftNode = focusNode.LeftNode;
            }

            return true;
        }

        private Node<T> GetReplacementNode(Node<T> replacedNode)
        {
            Node<T> replacementParent = replacedNode;
            Node<T> replacement = replacedNode;

            Node<T> focusNode = replacement;

            while (focusNode != null)
            {
                replacementParent = replacement;
                replacement = focusNode;
                focusNode = focusNode.LeftNode;
            }
            if (replacement != replacedNode.RightNode)
            {
                replacementParent.LeftNode = replacement.RightNode;
                replacement.RightNode = replacedNode.RightNode;
            }
            return replacement;
        }

        public void Print(Node<T> currentNode)
        {
            if (currentNode == null)
                return;

            Print(currentNode.LeftNode);
            Console.Write(currentNode.Value + " ");
            Print(currentNode.RightNode);
        }

    }
}
