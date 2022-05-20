using System;
using System.Linq;
using System.Windows.Forms;

namespace oop5lab
{
    public partial class Form1 : Form
    {
        Student st = new Student("Aipeeeri");

        public Form1() { InitializeComponent(); }

        private void RenderList(Student studs)
        {
            comboBox1.Items.Clear();
            foreach (var s in studs.Graduates)
                comboBox1.Items.Add(s.Direction);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            string direction = "Направление " + r.Next(1, 100) + "." + r.Next(1, 100) + "." + r.Next(1, 100);
            Graduate graduate = new Bachelor(false, direction, "", 1);
            st += graduate;
            RenderList(st);
        }

        private void button1_Click(object sender, EventArgs e) { timer1.Enabled = !timer1.Enabled; }

        private void button3_Click(object sender, EventArgs e)
        {
            if (st.Graduates.Count > 0)
                st -= (st.Graduates.Where(x => x.Direction == comboBox1.SelectedItem.ToString()).Select(x => x).First());
            comboBox1.Text = "";
            RenderList(st);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graduate graduate = new Bachelor(false, textBox2.Text, "", 1);
            st += graduate;
            RenderList(st);
            textBox2.Text = "";
        }
    }
}