using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    /// <summary>
    /// stack opgebouwd vanuit een list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ListStack<T> : IStack<T>
    {
        List<T> stack = new List<T>();
        /// <summary>
        /// push een getal boven op de stack
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            stack.Add(x);
        }
        /// <summary>
        /// haal het bovenste getal van de stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T rpop = stack.Last<T>();
            int last = Convert.ToInt32(stack.Count<T>()) -1;
            stack.RemoveAt(last);
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
