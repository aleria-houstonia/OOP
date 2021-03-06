using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (comboBox1.SelectedItem == null) textBox1.Text = "Не выбрано поле студента для удаления";
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
                    comboBox1.Text = "";
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
        private void button4_Click(object sender, EventArgs e)
        {
            int N = 1000;
            MyArr.Clear();
            students.Clear();
            Student stVar;
            Student.Counter = 0;
            Random rn = new Random(DateTime.Now.Millisecond);
            Stopwatch sw = new Stopwatch(), sw1 = new Stopwatch();
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                students.Enqueue(new Student("Name" + rn.Next(),
                    "Univer" + rn.Next(), "faculty" + rn.Next(),
                    "Department" + rn.Next(), Convert.ToUInt32(rn.Next(0, 100000)),
                    Convert.ToUInt32(rn.Next(0, 100000)), Convert.ToUInt32(rn.Next(0, 100000)),
                    Convert.ToUInt32(rn.Next(0, 100000)), Convert.ToUInt32(rn.Next(0, 100000)), rn.Next()));

            }
            sw.Stop();
            long ticks = sw.ElapsedTicks;
            queueGen.Text = ticks.ToString();
            sw1.Start();
            for (int i = 0; i < N; i++)
            {
                MyArr.Add(new Student("Name" + rn.Next(),
                     "Univer" + rn.Next(), "faculty" + rn.Next(),
                     "Department" + rn.Next(), Convert.ToUInt32(rn.Next(0, N)),
                     Convert.ToUInt32(rn.Next(0, N)), Convert.ToUInt32(rn.Next(0,N)),
                     Convert.ToUInt32(rn.Next(0, N)), Convert.ToUInt32(rn.Next(0, N)), rn.Next()));
            }
            sw1.Stop();
            long ticks1 = sw1.ElapsedTicks;
            arrayGen.Text = ticks1.ToString();

            string res;
            Stopwatch swPosled = new Stopwatch(), swPosled2 = new Stopwatch();
            swPosled.Start();
            foreach (Student student in students)
                res = student.Name;
            swPosled.Stop();
            long ticks3 = swPosled.ElapsedTicks;
            queuePosled.Text = ticks3.ToString();

            swPosled2.Start();
            for (int i = 0; i <N; i++)
            {
                res = MyArr[i].ToString();
            }
            swPosled2.Stop();
            long ticks4 = swPosled2.ElapsedTicks;
            arrayPosled.Text = ticks4.ToString();

            Stopwatch swRand = new Stopwatch(), swRand2 = new Stopwatch();

            swRand.Start();
          
            for (int i = 0; i < N; i++)
            {
                stVar = students.ElementAt(rn.Next(0, 1000));

            }
            swRand.Stop();
            long ticks5 = swRand.ElapsedTicks;
            queueRandom.Text = ticks5.ToString();


            swRand2.Start();
            for (int i = 0; i < N; i++)
            {
                res = MyArr[rn.Next(0, 1000)].ToString();
            }
            swRand2.Stop();
            long ticks6 = swRand2.ElapsedTicks;
            arrayRandom.Text = ticks6.ToString();

            RenderList();
        }
    }
}
