using System.Windows;
using System.Windows.Controls;
using BookManager.Core;
using BookManager.Pages;

namespace BookManager
{
    public partial class BookManagerPage : Page
    {

        public BookManagerPage()
        {
            InitializeComponent();
            DataContext = new BookManagerPageModel();
        }

        private void OpenSecondWindowButton_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dialogWindow = new DialogWindow();
            dialogWindow.DataContext = DataContext;
            dialogWindow.ShowDialog(); 
        }
    }
}
