using EfCore.Data;
using EfCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EfCore.Pages
{
    /// <summary>
    /// Логика взаимодействия для InterestGroupPage.xaml
    /// </summary>
    public partial class InterestGroupPage : Page
    {
        public InterestsService service { get; set; } = new();
        public InterestGroup? current { get; set; } = null;
        public InterestGroupPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupForm());
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить группу?",
                "Удалить группу?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления", "Выберите группу",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new GroupForm(current));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }
    }
    }

