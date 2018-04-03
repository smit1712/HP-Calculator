using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{/// <summary>
/// interface waar de verschillende stack's van erfen
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IStack<T>
    {
        void Push(T x);
        T Pop();
        bool Isempty();
    }
    /// <summary>
    /// Abstrackte class waar de verschillende Stack's van erfen
    /// </summary>
    /// <typeparam name="T">Generic variable type</typeparam>
    public abstract class Stack<T>
    {
        public int top = -1;
    }    
}
