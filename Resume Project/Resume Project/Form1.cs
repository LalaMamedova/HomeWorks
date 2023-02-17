using Microsoft.VisualBasic.Devices;

namespace Resume_Project
{
    public partial class Resume : Form
    {
        public Resume()
        {
            InitializeComponent();
        }

        private void MainLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private int MessageBoxLenghtCounter(params string[] texts)
        {
            int count = 0;
            foreach (var item in texts)
            {
               count+=item.Length;
            }
            return count/5;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            string[] SplitAll = new string[3];
            SplitAll = FIOtextBox.Text.Split(" ");

            if (SplitAll.Length == 3)
            {
                Employee employee = new()
                {
                    Name = SplitAll[0],
                    SurName = SplitAll[1],
                    Patronymic = SplitAll[2],
                    Education = ExptextBox.Text,
                };


                if (employee.Education != null)
                {
                    int count = MessageBoxLenghtCounter(employee.ToString(), BiotextBox.Text);
                    MessageBox.Show(employee.Name, "Имя");
                    MessageBox.Show(employee.SurName, "Фамилия");
                    MessageBox.Show(employee.Patronymic, "Отчество");
                    MessageBox.Show(employee.Education, "Образование");

                    if (BiotextBox.Text.Length > 50)
                    {
                        MessageBox.Show(BiotextBox.Text, "Средне арифметическое: " + count.ToString());
                    }
                    else
                        MessageBox.Show("Пожалуйста, дополните биографию, сейчас она слишком короткая","Ошибка!!!");
                }

            }
            else if(SplitAll.Length > 3)
            {
                MessageBox.Show("Какое то поле переполненное");
            }
            else
                MessageBox.Show("Какое то поле пустое");
                
        }

       
    }
}