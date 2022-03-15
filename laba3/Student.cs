using System;


namespace _3laba
{
    internal class Student
    {
        public string Name { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public uint Yearofstudy { get; set; }
        public uint Dateofadmission { get; set; }
        public uint Groupnumber { get; set; }
        public uint Academicperformance { get; set; }
        public int Id { get; set; }
        public uint Numberofmissedlectures { get; set; }
        public double Averagescore { get; set; }
        public static int Counter = 0;

        public Student()
        {
            Name = "name";
            Counter++;
        }

        public Student(string name)
        {   
            Name = name;
            Counter++;
            Id = Counter;
        }
        public Student(string name, string university, string faculty, string department, uint yearofstudy, uint dateofadmission, uint groupnumber, uint academicperformance, uint numberofmissedlecture, float averagescore)
        {
            Counter++;
            Name = name;
            University = university;
            Faculty = faculty;
            Department = department;
            Yearofstudy = yearofstudy;
            Dateofadmission = dateofadmission;
            Groupnumber = groupnumber;
            Academicperformance = academicperformance;
            Numberofmissedlectures = numberofmissedlecture;
            Averagescore = averagescore;
        }


        public Student(string name, string university)
        {
            Name = name;
            University = university;
            Counter++;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
        public void ConvertToHexadecimal()
        {
            Console.WriteLine(Convert.ToString(Numberofmissedlectures, 16));

        }
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
