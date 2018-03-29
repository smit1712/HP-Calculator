using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator.Classes
{
     class MyList<T>
    {
        private T item;
        private MyList<T> next;

        public MyList(T item)
        {
            this.item = item;
        }
        public T GetItem(int index)
        {
            if (index == 0)
           
                return item;
            else
                index = index - 1;
                return next.GetItem(index);
        }


        public void Add(T item)
        {
            if (next == null)
                next = new MyList<T>(item);
            else
                next.Add(item);
        }

        public T remove(int index)
        {
            if (index == 0)
            {
                next = null;
                return item;
                
            }
            else
                index = index - 1;
            return next.remove(index);

        }


    }
}
