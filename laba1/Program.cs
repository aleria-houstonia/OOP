using laba1;
Student student1 = new Student("Aiperi", "PSU", "FVT", "MkjgpioO", 17800, 77879, 178900, 808900, 17900, 23.3f);

Console.WriteLine("=====================================" + "\r\n"
    + "Лабораторная работа 1 " + "\r\n"
    + "Класс. Создание объекта" + "\r\n" + "Предметная область: Студент"
    + "\r\n" + "Группа:20ВП1" + "\r\n" + "Кубанычбекова Айпери" + "\r\n"
    + "=====================================");
static void Instructions()
{
    Console.WriteLine("=====================================" + "\r\n"
               + "Choose a number to execute the command:" +
               "\r\n" + "0 - stop" + "\r\n" +
               "1 - view data" + "\r\n" + "2 - to edit data" + "\r\n"
               + "=====================================");
}
Instructions();

static string[] TryToParse(string value)
{


    int number;
    bool result = Int32.TryParse(value, out number);
    if (result)
    {
        String[] resOfArr = new string[2] { "true", number.ToString() };
        return resOfArr;
    }
    else
    {
        if (value == null) value = "";
        Console.WriteLine("Invalid character"); 
        Instructions();
        String[] resOfArr = new string[2] { "false", "Invalid character" };
        return resOfArr;
    }
}


String[] a = TryToParse(Console.ReadLine());
static void StartProg1(String[] a, Student student1)
{
    if (a[1] == "Invalid character")
    {
        while (a[1]! == "Invalid character")
        {
            a = TryToParse(Console.ReadLine());
        }
        StartProg2(a, student1);

    }
    StartProg2(a, student1);
}
StartProg1(a, student1);



static void StartProg2(String[] a, Student student1)
{
    if (Convert.ToBoolean(a[0]))
    {
        bool condGet = true;
        bool condEdit = true;

        switch (Convert.ToInt16(a[1]))
        {
            case 0:
                Console.WriteLine("Exit the program....");
                break;
            case 1:
                while (condGet)
                {

                    string[] a3 = new string[2];
                    a3 = student1.GetInfo();
                    if (a3[1] == "back")
                    {
                        Instructions();
                        String[] a4 = TryToParse(Console.ReadLine());
                        StartProg1(a4, student1);

                    }
                    condGet = Convert.ToBoolean(a3[0]);
                }
                break;
            case 2:
                while (condEdit)
                {
                    string[] a3 = new string[2];
                    a3 = student1.EditInfo();
                    if (a3[1] == "back")
                    {
                        Instructions();
                        String[] a4 = TryToParse(Console.ReadLine());
                        StartProg1(a4, student1);

                    }
                    condEdit = Convert.ToBoolean(a3[0]);

                }
                break;
            default:
                Console.WriteLine("This command was not found");
                Instructions();
                String[] a2 = TryToParse(Console.ReadLine());
                StartProg1(a2, student1);
                break;
        }
    }
    else Console.WriteLine(a[1]);
}

