using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlayWithAnagrams
{
    public class ExamleAnagrams
    {
        class Anagram
        {
            public List<Anagram> Anagrams { get; set; }
            public char Ch { get; set; }

            public Anagram()
            {
                Anagrams = new List<Anagram>();
            }
        }


        private List<char []> anagrams = new List<char[]>();

        public List<char []>  getAllAnagrams(string initial)
        {
            Stack<char> stack = new Stack<char>();
            Anagram anagram = new Anagram();
            composeAnagrams(initial, stack, anagram);
            
            return anagrams;
        }

        //Create all possible anagrams
        private void composeAnagrams(string str, Stack<char> stack, Anagram anagram)
        {
            if (str.Length <= 0)
            {
                anagrams.Add(stack.Select(a=>a).ToArray());
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (anagram != null && !anagram.Anagrams.Exists(ch => ch.Ch == str[i]))
                {
                    Anagram a = new Anagram();
                    a.Ch = str[i];
                    stack.Push(str[i]);
                    anagram.Anagrams.Add(a);
                    string temp = str.Remove(i, 1);
                    composeAnagrams(temp, stack, a);
                    stack.Pop();
                }
            }
        }
        
        //Checks the strings are anagrams
        public  bool differentStringChecking(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            
            List<char> dic = new List< char>();

            foreach (char c in s1)
            {
                if (!dic.Contains(c))
                {
                    dic.Add(c);
                }
            }

            foreach (char c in s2)
            {
                if (!dic.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}