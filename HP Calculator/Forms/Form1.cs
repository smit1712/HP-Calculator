using HP_Calculator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace HP_Calculator
{
    public partial class Form1 : Form
    {
        
        /// <summary>
        /// Array waar de knopping in worden bewaard
        /// </summary>
        Button[] buttonarray = new Button[16];
        /// <summary>
        /// object van ArrayStack decimal
        /// </summary>
        ArrayStack<decimal> Astack = new ArrayStack<decimal>();
        /// <summary>
        /// object van ListStack decimal
        /// </summary>
        ListStack<decimal> Lstack = new ListStack<decimal>();
        /// <summary>
        /// object van MyListStack decimal
        /// </summary>
        MyListStack<decimal> MLstack = new MyListStack<decimal>();
        /// <summary>
        /// object waar het getal gemaakt wordt
        /// </summary>
        Label label = new Label();
        /// <summary>
        /// object waar de stacks in weergegeven worden
        /// </summary>
        ListBox listbox = new ListBox();
        /// <summary>
        /// datasource list die bij de listbox hoort
        /// </summary>
        List<decimal> listboxlist = new List<decimal>();
        /// <summary>
        /// string waarmee bepaald wordt welke stack geselecteerd is
        /// </summary>
        string selectedStack = "arraystack";
        /// <summary>
        /// string die een waarde van de label naar de listbox brengt
        /// </summary>
        string input = "";
        /// <summary>
        /// string met waarde in de label
        /// </summary>
        string text = "";
        public Form1()
        {
            InitializeComponent();
            Label();
            Buttons();
            Submit_button();
            Lbox();
            Radiobutton();            
        }
        /// <summary>
        /// Functie die 16 knoppen aanmaakt voor de numerice waarden en operaties 
        /// </summary>
        public void Buttons()
        {
            int count = 0;
            Point Location = new Point(0, 100);            
            foreach (Button Buttons in buttonarray)
            {
                Function Bname = new Function();
                Button button = new Button();
                button.Name = "Button" + count;
                button.Text = Bname.GetFunction(Convert.ToString(count));
                button.Height = 50;
                button.Width = 50;
                button.BackColor = Color.Gray;
                button.ForeColor = Color.LightGray;
                button.Location = Location;
                button.Click += new EventHandler(Button_Click);
                button.KeyDown += new KeyEventHandler(Form1_KeyDown);
                Controls.Add(button);
                button.Tag = count;
                if (Location.X <= 125)
                {
                    Location.X = Location.X + 50;
                }
                else
                {
                    Location.X = 0;
                    Location.Y = Location.Y + 60;
                }
                buttonarray[count] = button;
                count++;
            }
        }
        /// <summary>
        /// event handler voor toetsenbord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Focus();
            Button Buttonpressed = new Button();
            if (Convert.ToString(e.KeyData) == "Space")
            {
                Submitevent();
            }
            else
            {
                Buttonpressed.Tag = e.KeyData;

                Button_event(Buttonpressed);
            }
        }

        /// <summary>
        /// event handler voor muis click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button_event(sender);
        }
        /// <summary>
        /// functie die de operatie uitvoord of getallen in de label zet
        /// </summary>
        /// <param name="sender"></param>
        private void Button_event(object sender)
        {       
            ///vertaald button.tag naar de bij behorende input
            string Buttoncount = Convert.ToString((((Control)sender).Tag));
            Function gfunc = new Function();
            input = gfunc.GetFunction(Convert.ToString(Buttoncount));

            if (input == "(-)")
            {
                text = text + "-";
                label.Text = text;
                goto END;
            }            
            if (input == "/" || input == "+" || input == "-" || input == "*")
            {
                int size;
                size = listbox.Items.Count;
                if (size < 2)
                {
                    label.Text = null;
                    input = null;
                    goto END;

                }
                listbox.Items.RemoveAt(size - 1);
                listbox.Items.RemoveAt(size - 2);
                decimal calc1 = Convert.ToDecimal(Calculate(input));
                listbox.Items.Add(calc1);
                switch (selectedStack)
                {
                    case "arraystack":

                        Astack.Push(calc1);
                        break;
                    case "Liststack":

                        Lstack.Push(calc1);
                        break;
                    case "MyListStack":
                        MLstack.Push(calc1);
                        break;
                }
                input = null;
                text = "";
            }
            else
            {
                text = text + input;
                label.Text = text;
            }
            END:;
        }
        /// <summary>
        /// functie die de submit knop aanmaakt
        /// </summary>
        private void Submit_button()
        {
            Point Location = new Point(220, 30);
            Button button = new Button();
            button.Name = "submitbutton";
            button.Text = ">";
            button.Font = new Font("Arial", 5);
            button.Height = 15;
            button.Width = 15;
            button.BackColor = Color.Gray;
            button.ForeColor = Color.LightGray;
            button.Location = Location;
            button.MouseClick += new MouseEventHandler(Submit_Click);
            button.KeyDown += new KeyEventHandler(Form1_KeyDown);
            Controls.Add(button);            
        }

        /// <summary>
        /// eventhandler voor de sumbit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, EventArgs e)
        {
            Submitevent();
        }
        /// <summary>
        /// functie die de text in de label verplaatst naar de listbox en de geselecteerde stack
        /// daarna wordt de label weer geleegd 
        /// </summary>
        private void Submitevent()
        {
            if (text != "" && text != "+" && text != "-" && text != "*" && text != "/")
            {
                listbox.Items.Add(Convert.ToDecimal(text));
                switch (selectedStack)
                {
                    case "arraystack":
                        if (Astack == null)
                        {
                            Astack = new ArrayStack<decimal>();
                        }
                        Astack.Push(Convert.ToDecimal(text));
                        break;
                    case "Liststack":
                        if (Lstack == null)
                        {
                            Lstack = new ListStack<decimal>();
                        }
                        Lstack.Push(Convert.ToDecimal(text));
                        break;
                    case "MyListStack":
                        if (MLstack == null)
                        {
                            MLstack = new MyListStack<decimal>();
                        }
                        MLstack.Push(Convert.ToDecimal(text));
                        break;
                }
            text = "";
            label.Text = "";
            }
        }
        /// <summary>
        /// functie die twee getallen uit de stack haald en juist operatie uitvoord en het antwoord terug op de stack zet 
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        private string Calculate(string operation)
        {
            label.Text = null;
            decimal two = 1;
            decimal one = 2;
            decimal awnser;
            switch (selectedStack)
            {
                case "arraystack":
                     two = Astack.Pop();
                     one = Astack.Pop();
                    break;
                case "Liststack":

                     two = Lstack.Pop();
                     one = Lstack.Pop();
                    break;
                case "MyListStack":

                    two = MLstack.Pop();
                    one = MLstack.Pop();
                    break;
            }
            try
            {
                switch (operation)
                {
                    case "/":
                        awnser = one / two;
                        return Convert.ToString(awnser);
                    case "*":
                        awnser = one * two;
                        return Convert.ToString(awnser);
                    case "-":
                        awnser = one - two;
                        return Convert.ToString(awnser);
                    case "+":
                        awnser = one + two;
                        return Convert.ToString(awnser);
                }
            }
             catch (System.DivideByZeroException e)
            {
                listbox.Items.Remove(0);
                MessageBox.Show("Tried to devide by zero");
                return null;
            }
            return null;        
        }
        /// <summary>
        /// functie die een label aanmaakt waarin het getal gemaakt kan worden
        /// </summary>
        private void Label()
        {
            Point Location = new Point(0, 100);           
            label.Height = 50;
            label.Width = 200;
            Location.X = 10;
            Location.Y = 10;
            label.Location = Location;
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            label.KeyDown += new KeyEventHandler(Form1_KeyDown);
            Controls.Add(label);
        }
        /// <summary>
        /// functie die een listbox aanmaakt die de stack vertegenwoordigt 
        /// </summary>
        private void Lbox()
        {
            Point Location = new Point(250, 60);
            listbox.Height = 300;
            listbox.Width = 150;
            listbox.Location = Location;
            listbox.BackColor = Color.Beige;
            listbox.ForeColor = Color.Black;
            listbox.KeyDown += new KeyEventHandler(Form1_KeyDown);
            Controls.Add(listbox);
        }
        /// <summary>
        /// functie die 3 radiobuttons aanmaakt uit de verschillende stack typen te kiezen
        /// </summary>
        private void Radiobutton()
        {
            Point Location = new Point(400, 300);
            int count = 1;
            while (count <= 3)
            {
                RadioButton RadioButton = new RadioButton();
                switch (count)
                {
                    case 1:
                        RadioButton.Text = "arraystack";                        
                        break;
                    case 2:
                        RadioButton.Text = "Liststack";
                        RadioButton.Select();
                        break;
                    case 3:
                        RadioButton.Text = "MyListstack";

                        break;
                }
                if (count ==1)
                {
                    RadioButton.Checked=true;
                }
                RadioButton.AutoSize = true;
                RadioButton.ForeColor = Color.Black;
                Location.Y = Location.Y + 15;
                RadioButton.Location = Location;
                RadioButton.Click += new EventHandler(SelectRadiobutton);
                RadioButton.KeyDown += new KeyEventHandler(Form1_KeyDown);
                Controls.Add(RadioButton);
                count++;
            }
        }
        /// <summary>
        /// event handler de geselecteerde stack laad en de andere stacks leeg maakt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectRadiobutton(object sender, EventArgs e)
        {
            switch (((Control)sender).Text)
            {
                case "arraystack":
                    selectedStack = "arraystack";
                    listbox.Items.Clear();
                    MLstack = null;
                    Lstack = null;
                    break;
                case "Liststack":
                    selectedStack = "Liststack";
                    listbox.Items.Clear();
                    MLstack = null;
                    Astack = null;
                    break;
                case "MyListstack":
                    selectedStack = "MyListStack";
                    listbox.Items.Clear();
                    Astack = null;
                    Lstack = null;
                    break;
            }
        }
    }
}
