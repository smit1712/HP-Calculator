using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Calculator
{/// <summary>
/// vertaald de de knop naar de bij behoorende functie
/// </summary>
    class Function
    {
        private string function;
        public string GetFunction(string tag)
        {         
            switch (tag)
            {
                case "0":
                case "D7":
                case "NumPad7":
                    function = "7";
                    break;
                case "1":
                case "D8":
                case "NumPad8":
                    function = "8";
                    break;
                case "2":
                case "D9":
                case "NumPad9":
                    function = "9";
                    break;
                case "3":
                case "D/":
                case "Divide":
                    function = "/";
                    break;
                case "4":
                case "D4":
                case "NumPad4":
                    function = "4";
                    break;
                case "5":
                case "D5":
                case "NumPad5":
                    function = "5";
                    break;
                case "6":
                case "D6":
                case "NumPad6":
                    function = "6";
                    break;
                case "7":
                case "D*":
                case "Multiply":
                    function = "*";
                    break;
                case "8":
                case "D1":
                case "NumPad1":
                    function = "1";
                    break;
                case "9":
                case "D2":
                case "NumPad2":
                    function = "2";
                    break;
                case "10":
                case "D3":
                    function = "3";
                    break;
                case "11":          
                case "Subtract":                
                    function = "-";
                    break;
                case "12":
                case "OemMinus":              
                    function = "(-)";
                    break;
                case "13":
                case "D0":
                case "NumPad0":
                    function = "0";
                    break;
                case "14":
                case "D,":
                case "Decimal":
                    function = ",";
                    break;
                case "15":
                case "D+":
                case "Add":
                    function = "+";
                    break;
            }
            return function;
        }
    }
}

