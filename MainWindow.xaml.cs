using System.Windows;
using System.Windows.Controls;

namespace HideraMatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
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
    }
}