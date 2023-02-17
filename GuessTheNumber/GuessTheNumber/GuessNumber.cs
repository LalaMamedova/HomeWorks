using System.Security.Cryptography;

namespace GuessTheNumber
{
    public partial class GuessNumber : Form
    {
        private Random rnd = new();
        private int RandomNumber { get; set; }
        
        public GuessNumber()
        {
            InitializeComponent();
            Randomizer();
        }

        private int Randomizer() => RandomNumber = rnd.Next(1,2000);  
        
        private void OKbutton_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(GuessTextBox.Text);

            if (RandomNumber == num)
            {
                var reuslt = MessageBox.Show(
                    "������ ������?",
                    "�� ��������!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (reuslt == DialogResult.Yes)
                    Randomizer();
                
                else
                    return;
            }

            else if (num > RandomNumber)
            {
                MessageBox.Show("������","����",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (num < RandomNumber)
            {
                MessageBox.Show("�������", "���", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Guesslabel_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(RandomNumber.ToString(),"���������");
        }

        private void GuessTextBox_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("����� �� ������ �����!");
        }
    }
}