using System;
namespace _2laba
{

    internal class Student
    {
        public string Name { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Yearofstudy { get; set; }
        public int Groupnumber { get; set; }
        public int Academicperformance { get; set; }
        public int Numberofmissedlectures { get; set; }
        public double Averagescore { get; set; }
        public static int Counter = 0;

        public Student()
        {
            Counter++;
        }

        public Student(string name)
        {
            Name = name;
            Counter++;
        }

        public Student(string name, string university)
        {
            Name = name;
            University = university;
            Counter++;
        }
        /// <summary>
        /// выводит одержимое его полей: с использование переопределенного метода ToString() для класса вцелом;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name},{University},{Faculty},{Department},{Yearofstudy},{Groupnumber},{Academicperformance},{Numberofmissedlectures},{Averagescore}";
        }
        /// <summary>
        /// метод выводит поле Numberofmissedlectures в шестнадцатеричном представлении
        /// </summary>
        /// <returns></returns>
        public void ConvertToHexadecimal()
        {
            Console.WriteLine(Convert.ToString(Numberofmissedlectures, 16));

        }
        /// <summary>
        /// метод для получения определенного поля
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GetValue(string field)
        {
            switch (field)
            {
                case "Имя": return Name;
                case "Университет": return University;
                case "Факультет": return Faculty;
                case "Кафедра": return Department;
                case "Год обучения": return Yearofstudy.ToString();
                case "Номер группы": return Groupnumber.ToString();
                case "Академическая успеваемость": return Academicperformance.ToString();
                case "Количество пропущенных пар": return Numberofmissedlectures.ToString();
                case "Средний балл": return Averagescore.ToString();
                default: return "err";
            }
        }


    }
}
