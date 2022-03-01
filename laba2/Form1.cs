using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2laba
{
    public partial class Form1 : Form
    {
        
        private List<Student> listOfStudents = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            GetCondBtn();
            textBox2.Text = $"{ Student.Counter}";
        }
        private void GetCondBtn()
        {
            if (comboBox1.SelectedIndex == -1)
                btn.Enabled = false;
            else
                btn.Enabled = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             GetCondBtn();
            if (Student.Counter == 0)
                textBox1.Text = "список студентов пуст";
            else
            {
                if (comboBox1.SelectedIndex == -1)
                    textBox1.Text = "Пожалуйста,выберите студента";
                else
                    textBox1.Text = listOfStudents[comboBox1.SelectedIndex]
                        .GetValue(checkedListBox1.Text);
            }
        }
        private void EditVal()
        {
            string ToCheck = checkedListBox1.SelectedItem.ToString();
            switch (ToCheck)
            {
                case "Имя":
                    listOfStudents[comboBox1.SelectedIndex]
                        .GetType().GetProperty("Name")
                        .SetValue(listOfStudents[comboBox1.SelectedIndex], textBox1.Text, null);
                    comboBox1.Items.Clear();
                    listOfStudents.ForEach(x => comboBox1.Items.Add(x.Name));
                    GetCondBtn();
                    break;
                case "Университет":
                    listOfStudents[comboBox1.SelectedIndex]
                        .GetType().GetProperty("University")
                        .SetValue(listOfStudents[comboBox1.SelectedIndex], textBox1.Text, null);
                    break;
                case "Факультет":
                    listOfStudents[comboBox1.SelectedIndex]
                        .GetType().GetProperty("Faculty")
                        .SetValue(listOfStudents[comboBox1.SelectedIndex], textBox1.Text, null);
                    break;
                case "Кафедра":
                    listOfStudents[comboBox1.SelectedIndex]
                        .GetType().GetProperty("Department")
                        .SetValue(listOfStudents[comboBox1.SelectedIndex], textBox1.Text, null);
                    break;
                case "Год обучения":
                    ToInt("Yearofstudy");
                    break;
                case "Номер группы":
                    ToInt("Groupnumber");
                    break;
                case "Академическая успеваемость":
                    ToInt("Academicperformance");
                    break;
                case "Количество пропущенных пар":
                    ToInt("Numberofmissedlectures");
                    break;
                case "Средний балл":
                    ToFloat("Averagescore");
                    break;
                default:
                    textBox1.Text = "Ошибка";
                    break;
            }

        }

        private void ToInt(string key)
        {
            uint num;
            if (uint.TryParse(textBox1.Text, out num))
                listOfStudents[comboBox1.SelectedIndex]
                    .GetType().GetProperty(key)
                    .SetValue(listOfStudents[comboBox1.SelectedIndex], Convert.ToInt32(num), null);
            else
                textBox1.Text = "введен неверный формат";
        }
        private void ToFloat(string key)
        {
            double numd;
            if (double.TryParse(textBox1.Text, out numd))
                listOfStudents[comboBox1.SelectedIndex]
                    .GetType().GetProperty(key)
                    .SetValue(listOfStudents[comboBox1.SelectedIndex], Convert.ToDouble(numd), null);
            else
                textBox1.Text = "введен неверный формат";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditVal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCondBtn();
            if (textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
                listOfStudents.Add(new Student(textBox3.Text, textBox4.Text));
            else
                textBox1.Text = "Ошибка";

            comboBox1.Items.Clear();
            listOfStudents.ForEach(x => comboBox1.Items.Add(x.Name));
            textBox2.Text = $"{ Student.Counter}";
        }
        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }
    }
}