using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop8
{
    public partial class Form1 : Form
    {
        List<string> studentList = new List<string>();
        List<string> studentFindedList = new List<string>();
        Dictionary<int, Student>[] students = new Dictionary<int, Student>[10];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) students[i] = new Dictionary<int, Student>();
        }
        class Student : IComparable<Student>
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public string Faculty { get; set; }
            public string Direction { get; set; }
            public int Score { get; set; }
            public static int Count = 0;
            public Student()
            {
                Count++;
                Name = "";
                Group = "";
                Faculty = "";
                Score = 0;
                Direction = "";
            }
            public Student(string name, string group, string faculty, string direction, int score)
            {
                Count++;
                Name = name;
                Group = group;
                Faculty = faculty;
                Direction = direction;
                Score = 0;
            }

            ~Student() { }

            public override string ToString()
            {
                return $"{Name} | {Group}{Faculty.FirstOrDefault()}{Direction.FirstOrDefault()}| {Score}";
            }

            public int CompareTo(Student other)
            {
                throw new NotImplementedException();
            }
        }
        class StudentComparer : IComparer<Student>
        {
            public int Compare(Student t1, Student t2)
            {
                if (t1.Score > t2.Score)
                    return -1;
                if (t1.Score < t2.Score)
                    return 1;
                else
                    return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            bool isWrong = false;
            if (textBox1.Text == "" || textBox4.Text == "" ||
           maskedTextBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") isWrong = true;
            if (isWrong)
            {
                textBox1.BackColor = (textBox1.Text == "") ? Color.Red : Color.White;
                textBox4.BackColor = (textBox4.Text == "") ? Color.Red : Color.White;
                maskedTextBox1.BackColor = (maskedTextBox1.Text == "") ? Color.Red : Color.White;
                textBox3.BackColor = (textBox3.Text == "") ? Color.Red : Color.White;
                textBox2.BackColor = (textBox2.Text == "") ? Color.Red : Color.White;
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                maskedTextBox1.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox2.BackColor = Color.White;

                st.Name = textBox1.Text;
                st.Faculty = textBox2.Text;
                st.Direction = textBox3.Text;
                st.Score = Convert.ToInt32(textBox4.Text);
                st.Group = maskedTextBox1.Text;

                Random rand = new Random();
                students[rand.Next(0, 10)].Add(Student.Count, st);
                studentList.Add(st.ToString());
                RenderList();
            }
            allCollectionRender();
        }
        private void RenderList()
        {
            comboBox1.Items.Clear();
            foreach (string s in studentList)
                comboBox1.Items.Add(s);
        }
        private void RenderList2()
        {
            comboBox2.Items.Clear();
            foreach (string s in studentFindedList)
                comboBox2.Items.Add(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<int> studentMax = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                int max = 0;
                if (students[i].Count > 0)
                {
                    foreach (var st in students[i])
                    {
                        if (st.Value.Score == Convert.ToInt32(textBox5.Text)) max++;
                    }

                }
                studentMax.Add(max);
            }
            comboBox2.Items.Clear();
            comboBox2.Items.Add($"коллекция - {studentMax.IndexOf(studentMax.Max())}");
            allCollectionRender();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (students[i].Count > 0)
                {
                    foreach (var st in students[i])
                    {
                        if (st.Value.Score == Convert.ToInt32(textBox5.Text))
                        {
                            studentFindedList.Add(st.Value.ToString());
                        }
                    }
                }

            }
            RenderList2();
            allCollectionRender();
        }

        private void allCollectionRender()
        {
            List<string> ColItem = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if (students[i].Count > 0)
                {
                    ColItem.Add($"{i})---------------------");
                    foreach (var st in students[i]) ColItem.Add(st.Value.ToString());
                }

            }
            string result = "";
            foreach (string p in ColItem)
            {
                result += p + "\r\n";
            }
            textBox7.Text = result;
        }
    }
}
