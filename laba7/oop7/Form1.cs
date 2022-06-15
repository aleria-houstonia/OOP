using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace oop7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        delegate int LengthName(string n);
        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            bool isWrong = false;
            if (textBox1.Text == "" ||
           maskedTextBox1.Text == "" || textBox3.Text == "" || textBox3.Text == "") isWrong = true;
            if (isWrong)
            {
                textBox1.BackColor = (textBox1.Text == "") ? Color.Red : Color.White;
                maskedTextBox1.BackColor = (maskedTextBox1.Text == "") ? Color.Red : Color.White;
                textBox3.BackColor = (textBox3.Text == "") ? Color.Red : Color.White;
                textBox3.BackColor = (textBox3.Text == "") ? Color.Red : Color.White;
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                textBox1.BackColor = Color.White;
                maskedTextBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                LengthName lengthName = n => n.Length;  

                if (lengthName(maskedTextBox1.Text) > 15)
                {
                    MessageBox.Show("Пожалуйста,введите корректный номер группы");
                }
                else
                {
                    st.Name = textBox1.Text;
                    st.Faculty = textBox2.Text;
                    st.Direction = textBox3.Text;
                    st.Group = maskedTextBox1.Text;

                    st.Added += ShowMess;
                    st.addStudent();
                    RenderList();
                }
            }
        }
        class StudentEventArgs
        {
            //Сообщение 
            public string Message { get; }

            public StudentEventArgs(string mes)
            {
                Message = mes;
            }

        }
        private static void ShowMess(object sender, StudentEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
        private void RenderList()
        {
            comboBox1.Items.Clear();
            foreach (Student s in Student.students)
                comboBox1.Items.Add(s.ToString());
        }
        class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public string Faculty { get; set; }
            public string Direction { get; set; }
            public static List<Student> students = new List<Student>();
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

            public delegate void CompanyStateHandler(object sender, StudentEventArgs e);

            public event CompanyStateHandler Added;

            public event CompanyStateHandler Deleted;

            public void addStudent()
            {
                students.Add(this);
                Added?.Invoke(this, new StudentEventArgs($"Добавлен студент: '{Name}'!"));
            }
            public void DeleteStudent()
            {
                Deleted?.Invoke(this, new StudentEventArgs($"Удален студент: '{students.First().Name}'!"));
                students.RemoveAt(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Deleted += ShowMess;
            st.DeleteStudent();
            RenderList();
        }
    }
}
