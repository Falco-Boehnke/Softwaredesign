using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTree
{
    class Tree<T>
    {
        List<Node<T>> allNodes;

        public Tree()
        {
            allNodes = new List<Node<T>>();
        }

        public Node<T> CreateNode(T nodeValue)
        {
            Node<T> createdNode = new Node<T>(nodeValue);
            createdNode.nodeValue = nodeValue;
            allNodes.Add(createdNode);
            return createdNode;
        }

        public void OutputWholeTree()
        {
            allNodes[0].OutputAllValues();
        }

    }
}
