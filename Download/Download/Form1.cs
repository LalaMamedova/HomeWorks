using Download.Data;

namespace Download
{
    public partial class Form1 : Form
    {

        public AllGames GameList { get; set; } = new();
        private Game GameClone = new();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Add()
        {
            Mutex mutex = new(false, "MyMutex");
            mutex.WaitOne();

            string description = AllGames.Games[count].Description;
            GameClone = AllGames.Games[count];
            GameClone.Description = "";

            downloadList.Items.Add(GameClone);
            DescriptionTextBox.Text = (description);

            mutex.ReleaseMutex();
            ProgsseveBar();
        }

        private void ProgsseveBar()
        {
            downloadProgressBar.Maximum = 100;
            downloadProgressBar.Value = 0;
            downloadProgressBar.Step = 1;

            for (int i = 0; i <= downloadProgressBar.Maximum; i+=2)
            {
                downloadProgressBar.Value = i;
            }
        }
        private void downloadButton_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.Text = "";
            downloadList.Items.Clear();

            downloadList.Invoke(new Action(Download), GameClone);

            if (count < AllGames.Games.Count - 1)
                count++;
            else
                count = 0;
        }

        public void Download()
        {
            Thread thread = new(Add);
            thread.Start();
        }
    }
}