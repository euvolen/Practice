using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimpleAlgorithms
{
    //Simple algorithm for calculating all possible products for a weight  a kid can bear to school 
    public class SchoolBreakfasts
    {
        public SchoolBreakfasts()
        {
            breakfast = new List<Food[]>();
        }

        enum Food
        {
            pack,
            apple,
            sandwich,
            peaceOfPie
                 
        }
        
        private  List<Food[]> breakfast;

        private int Weight = 0;
        
        public void checkTheWeigth(int weight)
        {
            if (weight <= 0)
            {
                Console.WriteLine("Please don't be too greedy - feed a kid!");
                return;
            }
            if (weight > 10)
            {
              throw new ObesityException("Beware! A kid might become chubby a bit!");

            }

            Weight = weight;

        }

        public void allPossibleFood()
        {
            if (Weight == 0)
            {
                Console.WriteLine("We assume that you prefer to feed a kid as everybody else");
                Weight = 5;
            }
            
            Node root = new Node(Food.pack);
            Stack<Food> products = new Stack<Food>();

            makeAGraph(root, Weight, products);
            
            Console.WriteLine("Today a kid will be happy with: ");
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i< breakfast.Count; i++)
            {
                foreach (Food p in breakfast[i])
                {
                    sb.Append(p);
                    sb.Append(',');
                }
                sb.Remove(sb.Length - 1, 1);
                Console.WriteLine(i+". "+sb+'.');
                sb.Clear();
            }
            Console.WriteLine(new string('*', 20));

        }

        private void makeAGraph(Node node, int weight, Stack<Food> products)
        {
            if (weight >= 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        int w = weight - 1;
                        node.LNode = new Node(Food.apple);
                        products.Push(Food.apple);
                        makeAGraph(node.LNode, w, products);
                        products.Pop();

                    }

                    if (i == 1 && weight > 1)
                    {
                        int w = weight - 2;
                        node.CNode = new Node(Food.sandwich);
                        products.Push(Food.sandwich);
                        makeAGraph(node.CNode, w, products);
                        products.Pop();
                        
                    }

                    if (i == 2 && weight > 2)
                    {
                        int w = weight - 3;
                        node.RNode = new Node(Food.peaceOfPie);
                        products.Push(Food.peaceOfPie);
                        makeAGraph(node.RNode, w, products);
                        products.Pop();
                        
                    }
                }
            }
            else if (weight <= 0)
            {
                Food[] bf = products.Select(p => p).ToArray();
                breakfast.Add(bf);
                
            }
        }
        class Node
        {
            public Food product { get; set; }
            public Node RNode { get; set; }
            public Node CNode { get; set; }
            public Node LNode { get; set; }

            private Node() { }

            public Node(Food product)
            {
                this.product = product;
            }
        }

    }
    
  
    
    //TODO ObesityException
    [Serializable]
    public class ObesityException : Exception
    {
      
        public ObesityException(string message) : base(message) { }

        protected ObesityException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
   
}