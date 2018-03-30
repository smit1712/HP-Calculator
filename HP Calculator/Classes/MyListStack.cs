using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    class MyListStack<T> : Stack<T>, IStack<T>
    {
        
        MyList<T> stack = new MyList<T>(default(T));
        

        public void Push(T x)
        {
            top++;
            stack.Add(x);
        }
        public T Pop()
        {
            T rpop = stack.GetItem(top+1);
            stack.remove(top+1);
            stack.remove(top);
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
