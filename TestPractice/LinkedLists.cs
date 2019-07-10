using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayWithLists
{
    //Simple LinkedList <T> 
    public class LL<T> : IEnumerable<T>
    {
  
        private DoublyItem<T> root;
        
        private DoublyItem<T> last;
        
        private int count;
 

        public int Count
        {
            get => count;
        }
 

        public void Add(T data)
        {
          
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
 
            var item = new DoublyItem<T>(data);
            
            if(root == null)
            {
                root = item;
            }
            else
            {
                item.Previous = last;
            }
 
        
            last = item;
            
            count++;
        }
 

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
    
            var current = last;
            
            DoublyItem<T> previous = null;
 

            while(current != null)
            {
 
                if(current.Data.Equals(data))
                {
    
                    if (previous != null)
                    {
                       
                        previous.Previous = current.Previous;
                        
                        if(current.Previous == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        
                        last = last.Previous;
                        
                        if(last == null)
                        {
                            root = null;
                        }
                    }
 
                 
                    count--;
                    break;
                }
 
         
                previous = current;
                current = current.Previous;
            }
        }
        
        public void Clear()
        {
            root = null;
            last = null;
            count = 0;
        }
 

        public IEnumerator<T> GetEnumerator()
        {
            var current = last;
            while(current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
 

        IEnumerator IEnumerable.GetEnumerator()
        {
 
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    
        
    }

    
    
    //DoublyLinkedList <T> 
    public class DLL<T> : IEnumerable<T>
    {
  
        private DoublyItem<T> root;
        
        private DoublyItem<T> last;
        
        private int count;
 

        public int Count
        {
            get => count;
        }
 

        public void Add(T data)
        {
          
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
 
            var item = new DoublyItem<T>(data);
            
            if(root == null)
            {
                root = item;
            }
            else
            {   
                last.Next = item;
                item.Previous = last;
                
            }
 
        
            last = item;
            
            count++;
        }
 

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
    
            var current = last;
            
            DoublyItem<T> previous = null;
 

            while(current != null)
            {
 
                if(current.Data.Equals(data))
                {
    
                    if (previous != null)
                    {
                        
                        previous.Previous = current.Previous;
                        current.Previous.Next = previous;
                        
                        if(previous.Next == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        
                        last = last.Previous;
                        last.Next = null;
                        
                        if(last == null)
                        {
                            root = null;
                        }
                    }
 
                 
                    count--;
                    break;
                }
 
         
                previous = current;
                current = current.Previous;
            }
        }
        
        public void Clear()
        {
            root = null;
            last = null;
            count = 0;
        }
 

        public IEnumerator<T> GetEnumerator()
        {
            var current = last;
            while(current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
 

        IEnumerator IEnumerable.GetEnumerator()
        {
 
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    
        
    }
    
    
    
    
    public class DoublyItem<T>
    {

        public T Data { get; set; }
 

        public DoublyItem<T> Previous { get; set; }
 
        public DoublyItem<T> Next { get; set; }
        
        
        public DoublyItem(T data)
        {
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
            Data = data;
        }
 
        private DoublyItem(){}
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    
    
    
    //CircularLinkedList <T> 
    public class CLL<T> : IEnumerable<T>
    {
  
        private DoublyItem<T> root;
        
        private DoublyItem<T> last;
        
        private int count;
 

        public int Count
        {
            get => count;
        }
 

        public void Add(T data)
        {
          
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
 
            var item = new DoublyItem<T>(data);
            
            if(root == null)
            {
                root = item;
                
            }
            else
            {
                last.Next = null;
                item.Previous = last;
                
            }

            item.Next = root;
            last = item;
            
            count++;
        }
 

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
 
    
            var current = last;
            
            DoublyItem<T> previous = null;
 

            while(current != null)
            {
 
                if(current.Data.Equals(data))
                {
    
                    if (previous != null)
                    {
                       
                        previous.Previous = current.Previous;
                        previous.Next = root;
                        
                        if(current.Previous == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        
                        last = last.Previous;
                        
                        if(last == null)
                        {
                            root = null;
                        }
                    }
 
                 
                    count--;
                    break;
                }
 
         
                previous = current;
                current = current.Previous;
            }
        }
        
        public void Clear()
        {
            root = null;
            last = null;
            count = 0;
        }
 

        public IEnumerator<T> GetEnumerator()
        {
            var current = last;
            while(current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
 

        IEnumerator IEnumerable.GetEnumerator()
        {
 
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    
        
    }
    
    
}