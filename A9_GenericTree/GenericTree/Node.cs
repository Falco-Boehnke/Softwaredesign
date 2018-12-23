using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTree
{
    class Node<T>
    {
        public T nodeValue;
        public Node<T> nodeParent;
        public List<Node<T>> nodeChildren;

        private void init()
        {
            nodeChildren = new List<Node<T>>();
        }
        public Node(T nodeValue)
        {
            init();
            this.nodeValue = nodeValue;        
        }

        public void AppendChildNode(Node<T> childNode)
        {
            nodeChildren.Add(childNode);
        }


        public void OutputAllValues()
        {
            Console.WriteLine(nodeValue);

            if (nodeChildren.Count == 0)
                return;

            foreach (Node<T> node in nodeChildren)
            {
                node.OutputAllValues();
            }
        }
    }
}
