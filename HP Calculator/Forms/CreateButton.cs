using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HP_Calculator.Classes
{
   public class CreateButton
    {
        public CreateButton()
        {
            Button Button1 = new Button();
        Button1.Name = "Test";
            Button1.Text = "clickme";
            Button1.Location = new Point(20, 150);
        Button1.Height = 100;
            Button1.Width = 50;
            Button1.BackColor = Color.Red;
            Button1.Click += new EventHandler(Button1_Click);
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my first program");

        }
    }

}
