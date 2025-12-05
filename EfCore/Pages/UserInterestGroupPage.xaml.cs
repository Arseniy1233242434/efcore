using EfCore.Data;
using EfCore.Pages.Service;
using EfCore.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для UserInterestGroupPage.xaml
    /// </summary>
    public partial class UserInterestGroupPage : Page
    {

        public InterestsService service { get; set; } = new();
        public UserInteresrtsServicecs _service { get; set; } = new();
        public  User _student { get; set; } = new();
        public  InterestGroup group { get; set; } = null;
        public  UserInterestGroup group1 { get; set; } = new();
        public UserInterestGroupPage(User a)
        {
           
            InitializeComponent();
            _student = a;
            group1=new UserInterestGroup();
            group1.JoinedAt = DateTime.Now;
            
            DataContext = this;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (group == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            group1.InterestGroup = group;
            group1.InterestGroupId=group.Id;
            group1.User=_student;
            group1.UserId=_student.Id;  

            _service.Add(group1);
            NavigationService.GoBack(); 
        }
    }
    public class Converter3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
           if(value is bool)
            {
                return "Участник";
            }

            var t = (String)value;
            if (t == "Участник")
            {
                return false;
            }


            return true;

        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
