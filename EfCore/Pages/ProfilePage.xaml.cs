using EfCore.Data;
using EfCore.Pages.Service;
using Microsoft.Win32;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        User b;
        public static UserService _service = new();
        public ProfilePage(User a)
        {
            InitializeComponent();
            if(a.UserProfile == null)
            {
                a.UserProfile=new UserProfile();
            }
            b = a;
            DataContext = b.UserProfile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
               
                    
                    b.UserProfile.AvatarUrl = selectedImagePath;
                    
                
                    b.UserProfile.AvatarUrl = selectedImagePath;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _service.Commit();
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
    public class IsNumberCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length != 11)
            {
                
                return new ValidationResult(false, "Неправильный формат номера");
            }
            for (int i = 0; i < 11; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                   
                    return new ValidationResult(false, "Неправильный формат номера");
                }

            }
            
            return ValidationResult.ValidResult;
        }
    }
}
