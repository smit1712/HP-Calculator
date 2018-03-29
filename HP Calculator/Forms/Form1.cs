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

namespace HP_Calculator
{
    public partial class Form1 : Form
    {
        string selectedStack = "arraystack";
        Button[] buttonarray = new Button[16];
        ArrayStack<decimal> Astack = new ArrayStack<decimal>();
        ListStack<decimal> Lstack = new ListStack<decimal>();
        MyListStack<decimal> MLstack = new MyListStack<decimal>();
        Label label = new Label();
        ListBox listbox = new ListBox();
        List<decimal> listboxlist = new List<decimal>();
        string input = "";
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
        public void Buttons()
        {            
            int count = 0;
            Point Location = new Point(0, 100);
            foreach (Button Buttons in buttonarray)
            {
                ButtonName Bname = new ButtonName();
                Button button = new Button();                
                button.Name = "Button"+count;
                button.Text = Bname.GetButtonName(count);
                button.Height = 50;
                button.Width = 50;
                button.BackColor = Color.Gray;
                button.ForeColor = Color.LightGray;
                button.Location = Location;
                button.Click += new EventHandler(Button_Click);
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
            button.Click += new EventHandler(Submit_Click);
            Controls.Add(button);
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            if (text != "")
            { 
            listbox.Items.Add(Convert.ToDecimal(text));
                switch (selectedStack)
                {
                    case "arraystack":
                     Astack.Push(Convert.ToDecimal(text));
                    break;
                    case "Liststack":
                        Lstack.Push(Convert.ToDecimal(text));
                        break;
                    case "MyListStack":
                        MLstack.Push(Convert.ToDecimal(text));
                        break;

            }
            text = "";
            label.Text = "";
             }
        }



        private void Button_Click(object sender, EventArgs e)
        {
            int Buttoncount;
            Buttoncount = Convert.ToInt32((((Control)sender).Tag));
            Function gfunc = new Function();
            input = gfunc.GetFunction(Buttoncount);
            if (input != "(-)")
            { 
            text = text + input;
            label.Text = text;
            }
            int size;
            switch (input)
            {
                case "/":
                    size = listbox.Items.Count;
                    listbox.Items.RemoveAt(size - 1);
                    listbox.Items.RemoveAt(size - 2);
                    decimal calc1 = Convert.ToDecimal(Calculate("/"));
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
                    label.Text = "";
                    text = "";
                    break;
                case "*":
                    size = listbox.Items.Count;
                    listbox.Items.RemoveAt(size - 1);
                    listbox.Items.RemoveAt(size - 2);
                    decimal calc2 = Convert.ToDecimal(Calculate("*"));
                    listbox.Items.Add(calc2);
                    switch (selectedStack)
                    {
                        case "arraystack":

                            Astack.Push(calc2);
                            break;
                        case "Liststack":

                            Lstack.Push(calc2);
                            break;
                        case "MyListStack":
                            MLstack.Push(calc2);
                            break;

                    }
                    label.Text = "";
                    text = "";
                    break;
                case "-":
                    size = listbox.Items.Count;
                    listbox.Items.RemoveAt(size - 1);
                    listbox.Items.RemoveAt(size - 2);
                    decimal calc3 = Convert.ToDecimal(Calculate("-"));
                    listbox.Items.Add(calc3);
                    switch (selectedStack)
                    {
                        case "arraystack":

                            Astack.Push(calc3);
                            break;
                        case "Liststack":

                            Lstack.Push(calc3);
                            break;
                        case "MyListStack":
                            MLstack.Push(calc3);
                            break;
                    }
                    label.Text = "";
                    text = "";
                    break;
                case "+":
                    size = listbox.Items.Count;
                    listbox.Items.RemoveAt(size - 1);
                    listbox.Items.RemoveAt(size - 2);
                    decimal calc4 = Convert.ToDecimal(Calculate("+"));
                    listbox.Items.Add(calc4);
                    switch (selectedStack)
                    {
                        case "arraystack":

                            Astack.Push(calc4);
                            break;
                        case "Liststack":

                            Lstack.Push(calc4);
                            break;
                        case "MyListStack":
                            MLstack.Push(calc4);
                            break;
                    }
                    label.Text = "";
                    text = "";
                    break;
                case "(-)":
                    text = "-" + text;
                    label.Text = text;

                    break;
            }
            
        }
        private string Calculate(string operation)
        {
            decimal two = 1;
            decimal one = 2;
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


            switch (operation)
            {
                case "/":
                    decimal tree = one /  two;
                    return Convert.ToString(tree);
                case "*":
                    decimal four = one * two;
                    return Convert.ToString(four); 
                case "-":
                    decimal five = one -  two;
                    return Convert.ToString(five); 
                case "+":
                    decimal six = one +  two;
                    return Convert.ToString(six); 
            }
            return null;        
        }

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
            Controls.Add(label);
        }
        private void Lbox()
        {
            Point Location = new Point(250, 60);
            listbox.Height = 300;
            listbox.Width = 150;
            listbox.Location = Location;
            listbox.BackColor = Color.Beige;
            listbox.ForeColor = Color.Black;
            
            Controls.Add(listbox);
        }
        private void Radiobutton()
        {
            
            
            RadioButton arraystack = new RadioButton();
            arraystack.Text = "arraystack";
            arraystack.AutoSize = true;
            arraystack.BackColor = Color.Beige;
            arraystack.ForeColor = Color.Black;
            arraystack.Location = new Point(400, 300);
            arraystack.Click += new EventHandler(SelectRadiobutton);
            Controls.Add(arraystack);

            RadioButton Liststack = new RadioButton();
            Liststack.Text = "Liststack";
            Liststack.AutoSize = true;
            Liststack.BackColor = Color.Beige;
            Liststack.ForeColor = Color.Black;
            Liststack.Location = new Point(400, 315);
            Liststack.Click += new EventHandler(SelectRadiobutton);
            Controls.Add(Liststack);

            RadioButton MyListstack = new RadioButton();
            MyListstack.Text = "MyListstack";
            MyListstack.AutoSize = true;
            MyListstack.BackColor = Color.Beige;
            MyListstack.ForeColor = Color.Black;
            MyListstack.Location = new Point(400, 330);
            MyListstack.Click += new EventHandler(SelectRadiobutton);
            Controls.Add(MyListstack);


        }

        private void SelectRadiobutton(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.ButtonBase)sender).Text)
            {
                case "arraystack":
                    selectedStack = "arraystack";
                    break;
                case "Liststack":
                    selectedStack = "Liststack";
                    break;
                case "MyListstack":
                    selectedStack = "MyListStack";
                    break;
            }
        }
    }
}
