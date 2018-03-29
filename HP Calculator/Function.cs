using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator
{
    class Function
    {
        private string function;
        public Function() { }
        public string GetFunction(int tag) { 

        
            switch (tag)
            {
                case 0:
                    function = "7";
                    break;
                case 1:
                    function = "8";
                    break;
                case 2:
                    function = "9";
                    break;
                case 3:
                    function = "/";
                    break;
                case 4:
                    function = "4";
                    break;
                case 5:
                    function = "5";
                    break;
                case 6:
                    function = "6";
                    break;
                case 7:
                    function = "*";
                    break;
                case 8:
                    function = "1";
                    break;
                case 9:
                    function = "2";
                    break;
                case 10:
                    function = "3";
                    break;
                case 11:
                    function = "-";
                    break;
                case 12:
                    function = "(-)";
                    break;
                case 13:
                    function = "0";
                    break;
                case 14:
                    function = ",";
                    break;
                case 15:
                    function = "+";
                    break;

            }
            return function;

        }
    }
}

