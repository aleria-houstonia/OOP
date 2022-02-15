
namespace laba1
{
    internal class Student
    {
        public string Name { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Yearofstudy { get; set; }
        public int Dateofadmission { get; set; }
        public int Groupnumber { get; set; }
        public int Academicperformance { get; set; }
        public int Numberofmissedlectures { get; set; }
        public float Averagescore { get; set; }

        public Student() { }

        public Student(string name)
        {
            Name = name;
        }

        public Student(string name, int groupnumber)
        {
            Name = name;
            Groupnumber = groupnumber;
        }
        public Student(string name, string university, string faculty, string department, int yearofstudy, int dateofadmission, int groupnumber, int academicperformance, int numberofmissedlecture, float averagescore)
        {
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

        public override string ToString()
        {
            return $"{Name},{University},{Faculty},{Department},{Yearofstudy},{Dateofadmission},{Groupnumber},{Academicperformance},{Numberofmissedlectures},{Averagescore}";
        }
        public void ConvertToHexadecimal()
        {
            Console.WriteLine(Convert.ToString(Numberofmissedlectures, 16));

        }
        public String[] GetInfo()
        {
            String[] totalRes = new string[2];
            Console.WriteLine("=====================================" + "\r\n"
            + "Select a command to get the desired field:" + "\r\n" + "0 - stop" + "\r\n" +
            "1 - Name" + "\r\n" + "2 - University" + "\r\n" + "3 - Faculty" +
            "\r\n" + "4 - Department" + "\r\n" + "5 - Year of Study" +
            "\r\n" + "6 - Date of admission" + "\r\n" + "7 - Group number" +
            "\r\n" + "8 - Academic performance" +
            "\r\n" + "9 - Number of missed lectures" +
             "\r\n" + "10 - Average core" + "\r\n" + "11 - Back" + "\r\n" + "=====================================");

            string? field = Console.ReadLine();

            int number;

            bool result = Int32.TryParse(field, out number);
            if (result)
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine($"name: {Name}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 2:
                        Console.WriteLine($"university: {University}");
                        totalRes[0] = "true";
                        break;
                    case 3:
                        Console.WriteLine($"Faculty: {Faculty}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 4:
                        Console.WriteLine($"Department:{ Department}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 5:
                        Console.WriteLine($"Year of study:{Yearofstudy}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 6:
                        Console.WriteLine($"Date of admission: {Dateofadmission}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 7:
                        Console.WriteLine($"Group number:{ Groupnumber}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 8:
                        Console.WriteLine($"Academic performance:{ Academicperformance}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 9:
                        Console.WriteLine($"Number of missed lectures:{ Numberofmissedlectures}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 10:
                        Console.WriteLine($"Average score:{ Averagescore}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 11:
                        totalRes[0] = "false";
                        totalRes[1] = "back";
                        break;
                    case 0:
                        totalRes[1] = "none";
                        totalRes[0] = "false";
                        break;
                    default:
                        Console.WriteLine("This command was not found");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                }
            }
            else
            {
                if (field == null) field = "";
                Console.WriteLine("Invalid character");
                totalRes[0] = "true"; ;
                totalRes[1] = "none";
            }
            return totalRes;
        }


        public String[] EditInfo()
        {
            String[] totalRes = new string[2];
            Console.WriteLine("=====================================" + "\r\n"
                + "Select a command to edit the desired field:" + "\r\n" + "0 - stop" + "\r\n" +
                "1 - Name" + "\r\n" + "2 - University" + "\r\n" + "3 - Faculty" +
                "\r\n" + "4 - Department" + "\r\n" + "5 - Year of Study" +
                "\r\n" + "6 - Date of admission" + "\r\n" + "7 - Group number" +
                "\r\n" + "8 - Academic performance" +
                "\r\n" + "9 - Number of missed lectures" +
                 "\r\n" + "10 - Average core" + "\r\n" + "11 - See changes" + "\r\n" + "12 - Back" + "\r\n" + " =====================================");

            string? field = Console.ReadLine();

            int number;
            int num;
            float numberf;
            bool result = Int32.TryParse(field, out number);
            if (result)
            {
                switch (number)
                {
                    case 1:
                        Name = Console.ReadLine();
                        Console.WriteLine($"The 'Name ' field has been changed to: {Name}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 2:
                        University = Console.ReadLine();
                        Console.WriteLine($"The 'University' field has been changed to: {University}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 3:
                        Faculty = Console.ReadLine();
                        Console.WriteLine($"The 'Faculty' field has been changed to: {Faculty}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 4:
                        Department = Console.ReadLine();
                        Console.WriteLine($"The 'Department' field has been changed to: {Department}");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 5:
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            Yearofstudy = Convert.ToInt32(num);

                            Console.WriteLine($"The 'Year of study' field has been changed to: {Yearofstudy}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";
                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }
                        break;
                    case 6:
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            Dateofadmission = Convert.ToInt32(num);
                            Console.WriteLine($"The 'Date of admission' field has been changed to: {Dateofadmission}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";
                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }

                        break;
                    case 7:
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            Groupnumber = Convert.ToInt32(num);
                            Console.WriteLine($"The 'Group number' field has been changed to: {Groupnumber}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";
                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }

                        break;
                    case 8:
                        if (int.TryParse(Console.ReadLine(), out num))
                        {

                            Academicperformance = Convert.ToInt32(num);
                            Console.WriteLine($"The 'Academic performance' field has been changed to: {Academicperformance}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";
                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }

                        break;
                    case 9:
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            Numberofmissedlectures = Convert.ToInt32(num);
                            Console.WriteLine($"The 'Number of missed lectures' field has been changed to: {Numberofmissedlectures}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";

                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }

                        break;
                    case 10:
                        if (Single.TryParse(Console.ReadLine(), out numberf))
                        {
                            Averagescore = Convert.ToSingle(numberf);
                            Console.WriteLine($"The 'Average score' field has been changed to: {Averagescore}");
                            totalRes[1] = "none";
                            totalRes[0] = "true";
                        }
                        else
                        {
                            Console.WriteLine("Invalid character");
                        }




                        break;
                    case 11:
                        Console.WriteLine($"Name:{Name}" + "\r\n"
               + $"University:{University}" + "\r\n" + $"Faculty:{Faculty}"
               + "\r\n" + $"Department:{Department}" + "\r\n"
               + $"Year of study:{Yearofstudy}" + "\r\n" + $"Date of admission:{Dateofadmission}" +
               "\r\n" + $"Group number:{Groupnumber}" + "\r\n" + $"Academic performance:{Academicperformance}"
               + "\r\n" + $"Number of missed lectures:{Numberofmissedlectures}"
               + "\r\n" + $"Average score:{Averagescore}" + "\r\n");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                    case 12:
                        totalRes[0] = "false";
                        totalRes[1] = "back";
                        break;
                    case 0:
                        totalRes[1] = "none";
                        totalRes[0] = "false";
                        break;
                    default:
                        Console.WriteLine("This command was not found");
                        totalRes[1] = "none";
                        totalRes[0] = "true";
                        break;
                }
            }
            else
            {
                if (field == null) field = "";
                Console.WriteLine("Invalid character");
                totalRes[1] = "none";
                totalRes[0] = "true";
            }
            return totalRes;

        }

    }

}
