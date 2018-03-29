using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    class ArrayStack<T> : Stack<T>,IStack<T>
    { 

        T[] Array = new T[10];


        public void Push(T x)
        {
            top++;
            Array[top] = x;
        }
        public T Pop()
        {
            T rpop = Array[top];
            top--;
            return rpop;
 
        }
        public bool Isempty()
        {
            if (top == -1)
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
