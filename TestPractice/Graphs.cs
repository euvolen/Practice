using System;
using System.Collections.Generic;
using System.Globalization;


namespace PlayWithGraphs
{
    public class Graph
    {
        public Graph()
        {
        
            makeMeADefaultRandomArray();
        }
        
        public Graph(int [] numbers)
        {
            this.numbers = numbers;
         

        }
        
        private int[] numbers;
        
        private Nodes graph;
        
        
        public int [] makemeanArrayof(int quantity)
        {
            int[] arr = new int [quantity];
            Random r = new Random();
            for (int i = 0; i < quantity; i++)
            {
                arr[i] = r.Next(1, 100);
            }

            return arr;
        }
        
        
        
     
        //Very simple algorithm for creating binary tree
        public Nodes getTree()
        {
            if (numbers.Length > 0)
            {
                graph = new Nodes(numbers[0]);
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                makeGraph(new Nodes (numbers[i]), graph);
            } 
           
           return graph;
        }

        
        public Nodes getTree(int [] arr)
        {
            Nodes tree;
            if (arr.Length > 1)
            {
                {
                    tree = new Nodes(arr[0]);
                }
                for (int i = 1; i < arr.Length; i++)
                {
                    makeGraph(new Nodes(arr[i]), graph);
                }

                return tree;
            }
            else
            {
                throw new ArgumentNullException("Array is too small");
            }
        }
    
        //Creates binary tree without dublicates
        private void makeGraph(Nodes node, Nodes parent)
        {
            if (parent.value > node.value)
            {
                if (parent.Left != null)
                    makeGraph(node, parent.Left);
                else parent.Left = node;
            }
            if (parent.value < node.value)
            {
                if (parent.Right != null)
                    makeGraph(node, parent.Right);
                else parent.Right = node;
            }

            if (parent.value == node.value)
            {
                parent.count++;
            }
        }

        public class Nodes
            {
                public int value { get; set; }
                public int count { get; set; }
                public Nodes Right { get; set; }
                public Nodes Left { get; set; }

                private Nodes()
                {
                  
                }

                public Nodes(int value)
                {
                    count = 1;
                    this.value = value;

                }
                
            }
        //Utility for sorting array
        private void sortArray(ref int [] numbers)
        {
     
            for (var j = 0; j < numbers.Length; j++)
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                       
                    if(i+1 <= numbers.Length-1)
                        if (numbers[i] > numbers[i+1])
                        {
                                   
                            int temp = numbers[i];
                            numbers[i] = numbers[i+1];
                            numbers[i+1] = temp;
            
                        }
                }
            }

   

        }
        public void makeMeADefaultRandomArray()
        {
            numbers = new int [10];
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = r.Next(1, 100);
            }

        
        }
    }
    
}