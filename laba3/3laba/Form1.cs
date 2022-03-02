using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _3laba
{
    public partial class Form1 : Form
    {
        Queue<Student> students = new Queue<Student>();
        Queue<int> Fifo = new Queue<int>();
        ArrayList MyArr = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Count = students.Count;
            for (int i = 0; i < Count; i++)
            {
                Student First = students.Dequeue();
                if (First.Name != comboBox1.SelectedItem.ToString())
                {
                    textBox1.Text = (First.Name != comboBox1.SelectedItem.ToString()).ToString();
                    students.Enqueue(First);
                }
                else
                {
                    comboBox1.Items.Clear();
                    foreach (Student student in students)
                        comboBox1.Items.Add(student.Name);
                    textBox1.Text = "Удален";
                    break;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
                students.Enqueue(new Student(Student.Counter + 1 + ") " + textBox2.Text));
            else
                textBox1.Text = "Ошибка";
            comboBox1.Items.Clear();
            foreach (Student student in students)
                comboBox1.Items.Add(student.Name);
            textBox2.Text = $"{ Student.Counter}";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Student.Counter == 0)
                textBox1.Text = "список студентов пуст";
            else
            {
                if (comboBox1.SelectedIndex == -1)
                    textBox1.Text = "Пожалуйста,выберите студента";
                else
                    foreach (Student student in students)
                        if (student.Name == comboBox1.Text)
                        {
                            textBox1.Text = student.GetValue(checkedListBox1.Text);
                        }

            }
        }
        private void RenderList()
        {
            comboBox1.Items.Clear();
            foreach (Student s in students)
                comboBox1.Items.Add(s.Name);
        }

        private void EditVal(Student student)
        {
            string ToCheck = checkedListBox1.SelectedItem.ToString();
            switch (ToCheck)
            {
                case "Имя":
                    student.Name = textBox1.Text;
                    RenderList();
                    break;
                case "Университет":
                    student.University = textBox1.Text;
                    break;
                case "Факультет":
                    student.Faculty = textBox1.Text;
                    break;
                case "Кафедра":
                    student.Department = textBox1.Text;
                    break;
                case "Год обучения":
                    ToInt("Yearofstudy", student);
                    break;
                case "Номер группы":
                    ToInt("Groupnumber", student);
                    break;
                case "Академическая успеваемость":
                    ToInt("Academicperformance", student);
                    break;
                case "Количество пропущенных пар":
                    ToInt("Numberofmissedlectures", student);
                    break;
                case "Средний балл":
                    ToFloat("Averagescore", student);
                    break;
                default:
                    textBox1.Text = "Ошибка";
                    break;
            }

        }
        private void AddElem()
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                Random rn = new Random();
                int randNum = rn.Next();
                MyArr.Add(randNum);
                Random rn1 = new Random();
                int randNum1 = rn1.Next();
                Fifo.Enqueue(randNum1);
            }
            startTime.Stop();
            var resultTime = startTime.Elapsed;
            // elapsedTime - строка, которая будет содержать значение затраченного времени
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

        }

        private void ToInt(string key, Student st)
        {
            uint num;
            if (uint.TryParse(textBox1.Text, out num))
            {

                st.GetType().GetProperty(key).SetValue(st, num, null);
            }

            else
                textBox1.Text = "введен неверный формат";
        }
        private void ToFloat(string key, Student st)
        {
            double numd;
            if (double.TryParse(textBox1.Text, out numd))
            {
                st.GetType().GetProperty(key).SetValue(st, numd, null);
            }

            else
                textBox1.Text = "введен неверный формат";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Student student in students)
                if (student.Name == comboBox1.SelectedItem.ToString())
                {
                    EditVal(student);
                }
            RenderList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
