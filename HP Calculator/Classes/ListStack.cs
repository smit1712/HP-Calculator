﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    class ListStack<T> : IStack<T>
    {

        List<T> stack = new List<T>();

        public void Push(T x)
        {
            stack.Add(x);
        }
        public T Pop()
        {
            T rpop = stack.Last<T>();
            int last = Convert.ToInt32(stack.Count<T>()) -1;
            stack.RemoveAt(last);
            return rpop;
        }
        public bool Isempty()
        {
            if (stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
