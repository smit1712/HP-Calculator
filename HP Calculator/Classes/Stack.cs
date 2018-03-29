using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    public interface IStack<T>
    {
        void Push(T x);
        T Pop();
        bool Isempty();


    }


    public  abstract class Stack<T>
    {
        public int top = -1;
    }
    


}
