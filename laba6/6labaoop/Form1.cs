using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _6labaoop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        [DllImport("user32.dll")]
        public static extern int MessageBox(int hWnd, string text, string caption, uint type);
        class MyException : Exception
        {
            public MyException(string message) : base(message) { }
        }
        class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public string Faculty { get; set; }
            public string Direction { get; set; }
            public Student()
            {
                Name = "";
                Group = "";
                Faculty = "";
                Direction = "";
            }

            public override string ToString()
            {
                return $"{Name} | {Group}{Faculty.FirstOrDefault()}{Direction.FirstOrDefault()}";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            bool isWrong = false;

            if (textBox1.Text == "" ||
                maskedTextBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "") isWrong = true;
            if (isWrong)
            {
                textBox1.BackColor = (textBox1.Text == "") ? Color.Red : Color.White;
                maskedTextBox1.BackColor = (maskedTextBox1.Text == "") ? Color.Red : Color.White;
                textBox3.BackColor = (textBox3.Text == "") ? Color.Red : Color.White;
                textBox4.BackColor = (textBox4.Text == "") ? Color.Red : Color.White;
                MessageBox(0, "Заполните все поля!", "Сообщение", 0);
            }
            else
            {
                textBox1.BackColor = Color.White;
                maskedTextBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;

                st.Name = textBox1.Text;
                st.Faculty = textBox3.Text;
                st.Direction = textBox4.Text;
                st.Group = maskedTextBox1.Text;
                students.Add(st);
                RenderList();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] mass = new string[5];
            Object[] obMass = (Object[])mass;

            Student st = new Student();
            bool false1 = false;

            if (textBox1.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "") false1 = true;

            if (false1)
            {
                textBox1.BackColor = (textBox1.Text == "") ? Color.Red : Color.White;
                textBox3.BackColor = (textBox3.Text == "") ? Color.Red : Color.White;
                maskedTextBox1.BackColor = (maskedTextBox1.Text == "") ? Color.Red : Color.White;
                textBox4.BackColor = (textBox4.Text == "") ? Color.Red : Color.White;
                MessageBox(0, "Заполните все поля!", "Сообщение", 0);
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                maskedTextBox1.BackColor = Color.White;
                textBox4.BackColor = Color.White;

                st.Name = textBox1.Text;
                try
                {
                    Object ob = (Object)(maskedTextBox1.Text);
                    obMass[0] = ob;
                    throw new MyException("Произведена попытка добавления object переменной в массив string!");

                }
                catch (MyException me)
                {
                    MessageBox(0, "Сгенерированно исключение: " + me.Message, "Сообщение", 0);
                }
                finally
                {
                    obMass[0] = maskedTextBox1.Text;
                    st.Group = maskedTextBox1.Text.ToString();
                    MessageBox(0, "Было обработано значение поля 'Номер группы': " + Convert.ToString(obMass[0]), "Сообщение", 0);
                }
                st.Faculty = textBox3.Text;
                st.Direction = textBox4.Text;

                students.Add(st);
                RenderList();
                MessageBox(0, "Данные сохранены!", "Сообщение", 0);
            }
        }
        private void RenderList()
        {
            comboBox1.Items.Clear();
            foreach (Student s in students)
                comboBox1.Items.Add(s.ToString());
        }
    }
}
