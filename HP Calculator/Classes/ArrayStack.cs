using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace HP_Calculator.Classes
{
    /// <summary>
    /// Stack uitgebouwd vanaf een array, Max 50 waardes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArrayStack<T> : Stack<T>,IStack<T>
    { 
        T[] stack = new T[50];
        /// <summary>
        /// push een getal boven op de stack
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            top++;
            stack[top] = x;
        }
        /// <summary>
        /// haal het bovenste getal van de stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T rpop = stack[top];
            top--;
            return rpop; 
        }
        /// <summary>
        /// True als de stack leeg is
        /// </summary>
        /// <returns></returns>
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
