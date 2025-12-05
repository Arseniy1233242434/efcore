using EfCore.Data;
using EfCore.Pages.Service;
using EfCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public class a: ObservableObject
    {
        private User? student;
        public User Student
        {
            get => student;
            set => SetProperty(ref student, value);
        }
    }


    public partial class MainPage : Page
    {
        public UserService service { get; set; } = new();
        public  a student { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
           student=new a();
            DataContext=this;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (student.Student == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new UserFormPage(student.Student));
        }
        public void remove(object sender, EventArgs e)
        {
            if (student.Student == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(student.Student);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (student.Student == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            NavigationService.Navigate(new ProfilePage(student.Student));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            service.LoadRelation(2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            service.LoadRelation(3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            service.LoadRelation(1);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupPage());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(student.Student != null) 
            service.LoadRelation1(student.Student, "InterestGroups");

            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (student.Student == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            NavigationService.Navigate(new UserInterestGroupPage(student.Student));
        }
    }
}
