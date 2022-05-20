using System.Collections.Generic;

namespace oop5lab
{
    public class Student
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
        public List<Graduate> Graduates { get; set; } = new List<Graduate>();

        public Student(string name)
        {
            Name = name;
            Counter++;
           
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
        public static Student operator +(Student st, Graduate graduate)
        {
            st.Graduates.Add(graduate);
            return st;
        }

        public static Student operator -(Student st, Graduate graduate)
        {
            st.Graduates.Remove(graduate);
            return st;
        }

        public override string ToString() { return $"{Name}"; }
    }

   public abstract class Graduate
    {
        public string Direction { get; set; }
        public string Fullname { get; set; }
        public string TypeOfDiploma { get; set; }
        public int Scholarship { get; set; }
        public Graduate(string direction, string typeofdiploma, int scolarship)
        {
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
        }
        public abstract string GetInfo();
        public string GetFullName() { return $"Fullname: {Fullname}"; }
    }

    class Bachelor : Graduate
    {

        public bool PlansForMaster { get; set; }
        public Bachelor( bool plans, string direction, string typeofdiploma, int scolarship) : base(direction, typeofdiploma, scolarship)
        {
            PlansForMaster = plans;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
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
        public Master(bool plans, int numberOfResearchPapers, string direction, string typeofdiploma, int scolarship) : base(direction, typeofdiploma, scolarship)
        {
            PlansForPostGraduate = plans;
            NumberOfResearchPapers = numberOfResearchPapers;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
            Scholarship = scolarship;
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
        public PostGraduate(bool becomeATeacher, bool engageInScientificActivity, bool getADoctorOfScience, string direction, string typeofdiploma, int scolarship) : base(direction, typeofdiploma, scolarship)
        {
            BecomeATeacher = becomeATeacher;
            EngageInScientificActivity = engageInScientificActivity;
            GetADoctorOfScience = getADoctorOfScience;
            Direction = direction;
            TypeOfDiploma = typeofdiploma;
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
