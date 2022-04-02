using System;
using System.Reflection;
using System.Windows.Forms;

namespace inheritance
{
    public partial class Form1 : Form
    {
        TreeView tree = new TreeView();
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(tree);
            tree.Dock = DockStyle.Fill;
            Type StudentInfo = typeof(Student);
            Type GraduateInfo = typeof(Graduate);
            Type MasterInfo = typeof(Master);
            Type BachelorInfo = typeof(Bachelor);
            Type PostGraduateInfo = typeof(PostGraduate);
            tree.Nodes.Add(StudentInfo.Name);
            tree.Nodes.Add(GraduateInfo.Name);
            tree.Nodes.Add(BachelorInfo.Name);
            tree.Nodes.Add(MasterInfo.Name);
            tree.Nodes.Add(PostGraduateInfo.Name);
            Render(StudentInfo, 0);
            Render(BachelorInfo, 1);
            Render(MasterInfo, 2);
            Render(GraduateInfo, 3);
            Render(PostGraduateInfo, 4);
        }
        private void Render(Type Info, int row)
        {
            PropertyInfo[] myPropertyInfo = Info.GetProperties();
            FieldInfo[] myField = Info.GetFields();
            MethodInfo[] myMethods = Info.GetMethods();

            tree.Nodes[row].Nodes.Add("Поля");
            tree.Nodes[row].Nodes.Add("Свойства");
            tree.Nodes[row].Nodes.Add("Методы");

            for (int i = 0; i < myField.Length; i++)
                tree.Nodes[row].Nodes[row].Nodes.Add(myField[i].IsPrivate ? "private " : "public " + (myField[i].IsStatic ? "static " : "") + myField[i].Name);

            for (int i = 0; i < myPropertyInfo.Length; i++)
                tree.Nodes[row].Nodes[1].Nodes.Add(myPropertyInfo[i].PropertyType.Name.ToLower() + " " + myPropertyInfo[i].Name);

            string params2 = "";
            for (int i = 0; i < myMethods.Length; i++)
            {
                ParameterInfo[] parameters = myMethods[i].GetParameters();
                for (int j = 0; j < parameters.Length; j++)
                    params2 += parameters[j].ParameterType.Name.ToLower() + ",";

                if (params2.Length != 0)
                    params2 = params2.TrimEnd(',');

                tree.Nodes[row].Nodes[2].Nodes.Add(myMethods[i].IsAbstract ? "abstract " : " " +
                    (myMethods[i].IsPublic ? "public " : " ") +
                     (myMethods[i].IsVirtual ? "virtual" : " ") + " " + myMethods[i].ReturnType.Name.ToLower() + " " +
                    myMethods[i].Name + " ( " + params2 + " )");
                params2 = "";
            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}
