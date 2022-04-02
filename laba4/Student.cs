
using System;

namespace inheritance
{
    abstract class Student
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
        public double Score { get; set; }
        public static int Counter = 0;

        public Student(string name)
        {
            Name = name;
            Counter++;
            Id = Counter;
        }
        public Student(string name, string university, string faculty, string department, uint yearofstudy, uint dateofadmission, uint groupnumber, uint academicperformance, uint numberofmissedlecture, float score)
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
            Score = score;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
        public string PassTheExam()
        {
            return Score > 63 ? "Сдан" : "Не сдан";
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
                case "Балл": return Score.ToString();
                default: return "err";
            }
        }
    }

    abstract class Graduate
    {
        public string Direction { get; set; }
        public string Fullname { get; set; }
        public string TypeOfDiploma { get; set; }
        public int Scholarship { get; set; }
        public Graduate(string direction, string typeofdiploma, int scolarship,string fullName)
        {
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
            Fullname=fullName;
        }
        public abstract string GetInfo();
        public  string GetFullName()
        {
            return $"Fullname: {Fullname}";
        }
        public void FindOutTheScholarship()
        {
            System.Console.WriteLine(Scholarship);
        }
    }

    class Bachelor : Graduate
    {

        public bool PlansForMaster { get; set; }
        public Bachelor(string fullname, bool plans, string direction, string typeofdiploma, int scolarship) : base(direction, typeofdiploma, scolarship,fullname)
        {
            Fullname = fullname;
            PlansForMaster = plans;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
            Fullname = fullname;
        }

        public override string GetInfo()
        {
            var res = PlansForMaster ? "Есть" : "Нет";
            return $"Планы на получение степени Магистра:  {res} + \nНаправление: {Direction}\n Вид диплома: {TypeOfDiploma}\n Стипендия: {Scholarship}";
        }
    

    }

    class Master : Graduate
    {
        public int NumberOfResearchPapers { get; set; }
        public bool PlansForPostGraduate { get; set; }
        public Master(bool plans, int numberOfResearchPapers, string direction, string typeofdiploma, int scolarship,string fullname) : base(direction, typeofdiploma, scolarship,fullname)
        {
            PlansForPostGraduate = plans;
            NumberOfResearchPapers = numberOfResearchPapers;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
            Fullname = fullname;
        }

        public override string GetInfo()
        {
            var res = PlansForPostGraduate ? "Есть" : "Нет";
            return $"Планы получить степень Аспиранта: {res} \n Количество исследовательских работ: {NumberOfResearchPapers}  \nНаправление: {Direction}\n Вид диплома: {TypeOfDiploma}\n Стипендия: {Scholarship}";
        }

    }
    class PostGraduate : Graduate
    {
        public bool BecomeATeacher { get; set; }
        public bool EngageInScientificActivity { get; set; }
        public bool GetADoctorOfScience { get; set; }
        public PostGraduate(bool becomeATeacher, bool engageInScientificActivity, bool getADoctorOfScience, string direction, string typeofdiploma, int scolarship, string fullname) : base(direction, typeofdiploma, scolarship, fullname)
        {
            BecomeATeacher = becomeATeacher;
            EngageInScientificActivity = engageInScientificActivity;
            GetADoctorOfScience = getADoctorOfScience;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Fullname = fullname;
            Scholarship = scolarship;
        }
        public string IsBecomeADoctorOfScience()
        {
            var res = GetADoctorOfScience ? "Есть" : "Нет";
            return "Планы на получение Докторской степени: "+res;
        }

        public void IsBecomeATeacher()
        {
            Console.WriteLine("Планы после выпуска стать преподавателем: "+(BecomeATeacher ? "Есть" : "Нет"));
        }
        public void GetScientificWork()
        {
            Console.WriteLine("Желание участвовать в научных исследованиях: "+(EngageInScientificActivity ? "Есть" : "Нет"));
        }
        public override string GetInfo()
        {
            var res = BecomeATeacher ? "Да" : "Нет";
            var res2 = EngageInScientificActivity ? "Да" : "Нет";
            var res3 = GetADoctorOfScience ? "есть" : "Нет";
            return $"Планы стать преподавателем:  {res}\n Заняться научными исследованиями: {res2}\n Планы на получение Докторской степени: {res3}  \nНаправление: {Direction}\n Вид диплома: {TypeOfDiploma}\n Стипендия: {Scholarship}";
        }
    }
}
