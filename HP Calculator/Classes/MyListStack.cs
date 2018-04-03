using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    /// <summary>
    /// Stack uitgebouwd vanaf MyList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyListStack<T> : Stack<T>, IStack<T>
    {
        
        MyList<T> stack = new MyList<T>(default(T));
        /// <summary>
        /// push een getal boven op de stack
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            top++;
            stack.Add(x);
        }
        /// <summary>
        /// haal het bovenste getal van de stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T rpop = stack.GetItem(top+1);
            stack.remove(top+1);
            stack.remove(top);
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
