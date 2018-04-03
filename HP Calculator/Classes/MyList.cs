using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
    /// <summary>
    /// zelf gemaakte list class voor MyListStack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyList<T>
    {
        private T item;
        private MyList<T> next;
        public int count;
        /// <summary>
        /// constructor voor mylist 
        /// </summary>
        /// <param name="item"></param>
        public MyList(T item)
        {
            this.item = item;
        }
        /// <summary>
        /// returned item op de mee gegeven locatie
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItem(int index)
        {
            if (index == 0)
                return item;
            else
                index = index - 1;
            return next.GetItem(index);
        }
        /// <summary>
        /// geeft de groote van de list terug
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }
        /// <summary>
        /// voegd een waarde toe aan de list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (next == null)
            {
                next = new MyList<T>(item);
                count++;
            }
            else
                next.Add(item);
        }
        /// <summary>
        /// verwijderd de laatste waarde van de list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T remove(int index)
        {
            if (index == 0)
            {
                count--;
                next = null;
                return item;               
            }
            else
                index = index - 1;
            return next.remove(index);
        }
    }
}
