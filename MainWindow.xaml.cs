using System.Windows;
using System.Windows.Controls;

namespace HideraMatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetUpGame()

        {
            List<string> animalEmoji = new()
            {
                "🐍","🐍",
                "🐫","🐫",
                "🐇","🐇",
                "🐿","🐿",
                "🐬","🐬",
                "🐦","🐦",
                "🐔","🐔",
                "🦌","🦌",

            };
            Random random = new();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);

            }

        }
        TextBlock lastTextblockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextblockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextblockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;

            }
            else
            {
                lastTextblockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}