using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace HP_Calculator.Classes
{
    class ArrayStack<T> : Stack<T>,IStack<T>
    { 
        T[] stack = new T[10];
        public void Push(T x)
        {
            top++;
            stack[top] = x;
        }
        public T Pop()
        {
            T rpop = stack[top];
            top--;
            return rpop;
 
        }
        public bool Isempty()
        {
            if (stack.Count() == 0)
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
