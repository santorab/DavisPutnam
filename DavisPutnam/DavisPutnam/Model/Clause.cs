﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavisPutnam.Model
{
    class Clause
    {
        public List<string> Elements { get; set; }
        public List<string> Vocabulary
        {
            get
            {
                var toReturn = new List<string>(Elements);
                for(var i=0;i<toReturn.Count;i++)
                {
                    toReturn[i] = toReturn[i].Replace("!", "");
                }
                return toReturn;
            }
        }

        public Clause() { }

        public void AddElement(string element)
        {
            if (!Elements.Contains(element))
            {
                Elements.Add(element);
            }
        }

        public static Clause Concat(Clause a, Clause b)
        {
            var toReturn = new Clause();
            toReturn.Elements = new List<string>(a.Elements);
            foreach(var s in b.Elements)
            {
                toReturn.AddElement(s);
            }
            return toReturn;
        }
        
        public bool Tautologia()
        {
            foreach(var s in Elements)
            {
                if(s.Contains("!"))
                {
                    if (Elements.Contains(s.Replace("!", ""))) ;
                    {
                        return true;
                    }
                }
                else
                {
                    if (Elements.Contains("!" + s)) ;
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Clause Join(Clause join)
        {
            var toReturn = new Clause();
            foreach (var element in Elements)
            {
                if (element.Contains('!'))
                {
                    if (!join.Elements.Contains(element.Replace("!", "")))
                    {
                        toReturn.AddElement(element);
                    }
                }
                else
                {
                    if (!join.Elements.Contains("!" + element))
                    {
                        toReturn.AddElement(element);
                    }
                }
            }
            return toReturn;
        }
    }
}
