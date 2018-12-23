using System;

namespace GenericTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> mainTree = new Tree<string>();
            Node<string> root = mainTree.CreateNode("root");
            Node<string> child1 = mainTree.CreateNode("child1");
            Node<string> child2 = mainTree.CreateNode("child2");

            Node<string> root2 = mainTree.CreateNode("root2");
            Node<string> child11 = mainTree.CreateNode("child11");
            Node<string> child12 = mainTree.CreateNode("child12");
            Node<string> child13 = mainTree.CreateNode("child13");

            Node<string> root3 = mainTree.CreateNode("root3");
            Node<string> child21 = mainTree.CreateNode("child21");
            Node<string> child22 = mainTree.CreateNode("child22");
            Node<string> child23 = mainTree.CreateNode("child23");

            Console.WriteLine("Reading Tree");
            mainTree.OutputWholeTree();
        }
    }
}
