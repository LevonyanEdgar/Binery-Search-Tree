using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarSTree
{
    class BSTree
    {
        public Node root;
        public BSTree()
        {
            root = null;
        }
        public void Insert(double value)
        {
            Node newItem = new Node(value);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                Node current = root;
                Node parent = null;
                while (parent != null)
                {
                    parent = current;
                    if (value < current.value)
                    {
                        current = current.LeftNode;
                        if (current == null)
                        {
                            parent.LeftNode = newItem;
                        }
                    }
                    else
                    {
                        current = current.RightNode;
                        if (current==null)
                        {
                            parent.RightNode = newItem;
                        }
                    }
                    

                }

            }

        }
        public void InOderTreeDisply(Node root)
        {
            if (root !=null)
            {
                InOderTreeDisply(root.LeftNode);
                Console.WriteLine($"{root.value}");
                InOderTreeDisply(root.RightNode);
            
            }
        }
        public bool FindeValue(Node root, double value)
        {
            if (root !=null)
            {
                FindeValue(root.LeftNode, value);
                FindeValue(root.RightNode, value);
                if (root.value== value)
                {
                    Console.WriteLine("value exists!");
                    return true;
                }
            }
            return false;
        }
        public Node GoToTarget(double target)
        {
            Node p = root;
            Node ReturnThis = null;
            while (p!=null)
            {
                if (target< p.value)
                {
                    p = p.LeftNode;
                }
                if (target == p.value)
                {
                    ReturnThis = p;
                    break;
                }
                if (target> p.value)
                {
                    p = p.RightNode;
                }
                

                
            }
            return ReturnThis;

        }
        public Node ParentOfNode(Node target)
        {
            Node current = root;
            Node parent = null;
            while (current != null)
            {
                if (current.LeftNode==target || current.RightNode== target)
                {
                    parent = current;
                    break;
                }
                if (target.value< current.value && target!=current.LeftNode)
                {
                    current = current.LeftNode;
                }
                if (target.value> current.value && target != current.RightNode)
                {
                    current = current.RightNode;
                }
            }
            return parent;
        }
        public bool Find(double target)
        {
            if (root != null && reguler_finde(target)!=false)
            {
                return true;
            }
            return false;

        }
        public bool reguler_finde(double target)
        {
            bool isFound = false;
            Node current = root;
            while (current != null && isFound == false)
            {
                if (current.value == target)
                {
                    isFound = true;
                    break;
                }
                if (target< current.value)
                {
                    if (current.LeftNode==null)
                    {
                        break;
                    }
                    else
                    {
                        current = current.LeftNode;
                    }
                }
                if (target> current.value)
                {
                    if (current.RightNode == null)
                    {
                        break;
                    }
                    else
                    {
                        current = current.RightNode;

                    }
                }
            }
            if (isFound==true)
            {
                Console.WriteLine("Found it!");
                return true;
            }
            else
            {
                Console.WriteLine(" It is not found");
                return false;
            }

        }

        public void Remove(double target)
        {
            if (root==null || Find(target)==false)
            {
                Console.WriteLine("Value not found to delete!");
                return;
            }
            else
            {
                Console.WriteLine($"{Private_Remove(target)} was removed from the tree");
                return;
            }
        }
        public double Private_Remove(double target)
        {
            double temp;
            Node targetNode = GoToTarget(target);
            if (targetNode== root)
            {
                if (targetNode.LeftNode == null && targetNode.LeftNode == null)
                {
                    temp = root.value;
                    root = null;
                    return temp;

                }
                if (targetNode.LeftNode != null)
                {
                    Node current = root.LeftNode;
                    temp = root.value;
                    if (root.LeftNode.RightNode==null)
                    {
                        root.value = root.RightNode.value;

                    }
                    else
                    {
                        while (current!=null)
                        {
                            if (current.RightNode.RightNode==null)
                            {
                                root.value = root.RightNode.value;
                                break;
                            }
                            current = current.RightNode;
                        }
                        if (current.RightNode!=null)
                        {
                            current.RightNode = current.RightNode.RightNode;

                        }
                        else
                        {
                            current.RightNode = null;
                        }
                        return temp;
                    }
                    if (root.LeftNode.LeftNode ==null)
                    {
                        root.LeftNode = null;
                    }
                    else
                    {
                        root.LeftNode = root.LeftNode.LeftNode;
                        
                    }
                    return temp;

                }
                if (targetNode.RightNode != null)
                {
                    temp = root.value;
                    root.value = root.RightNode.value;
                    if (root.RightNode.RightNode== null)
                    {
                        root.RightNode = null;
                    }
                    else
                    {
                        root.RightNode = root.RightNode.RightNode;
                    }
                    return temp;
                }
            }
            if (targetNode.LeftNode== null &&  targetNode.RightNode==null)
            {
                if (ParentOfNode(targetNode).LeftNode== targetNode)
                {
                    temp = targetNode.value;
                    ParentOfNode(targetNode).LeftNode = null;
                }
                else
                {
                    temp = targetNode.value;
                    ParentOfNode(targetNode).RightNode = null;
                }
                return temp;
            }
            if (targetNode.LeftNode!=null && targetNode.LeftNode== null)
            {
                temp = targetNode.value;
                ParentOfNode(targetNode).RightNode = targetNode.LeftNode;
                return temp;
            }
            if (targetNode.LeftNode == null && targetNode.RightNode!=null)
            {
                temp = targetNode.value;
                if (ParentOfNode(targetNode)== root)
                {
                    ParentOfNode(targetNode).LeftNode = targetNode.RightNode;
                }
                else
                {
                    ParentOfNode(targetNode).RightNode = targetNode.RightNode;
                }
                return temp;

            }
            if (targetNode.LeftNode != null && targetNode.RightNode!=null)
            {
                if (ParentOfNode(targetNode).LeftNode == targetNode)
                {
                    temp = targetNode.value;
                    targetNode.value = targetNode.LeftNode.value;
                    targetNode.LeftNode = null;
                    return temp;
                }
                else
                {
                    temp = targetNode.value;
                    targetNode.value = targetNode.LeftNode.value;
                    if (targetNode.LeftNode.LeftNode!=null)
                    {
                        targetNode.LeftNode = targetNode.LeftNode.LeftNode;
                    }
                    else
                    {
                        targetNode.RightNode= null;
                    }                
                    return temp;
                }


            }
            return Double.MaxValue;

        }



    }
}
