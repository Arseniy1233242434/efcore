using EfCore.Data;
using EfCore.Pages.Service;
using Microsoft.Win32;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace EfCore.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        public static UserService _service = new();
        public static User _student = new();
        bool isEdit = false;

        public UserFormPage(User? _edituser = null)
        {
            InitializeComponent();
            if (_edituser != null)
            {
                _student = _edituser;
                isEdit = true;
                DataContext = _student;
                return;
            }
            _student = new();
            DataContext = _student;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_student);
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;
                if (!isEdit)
                {
                    _student.UserProfile=new UserProfile();
                    _student.UserProfile.AvatarUrl = selectedImagePath;
                    return;
                }
                _student.UserProfile.AvatarUrl = selectedImagePath;

            }
        }
    }
    public class IsPasswordCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 8)
            {

                return new ValidationResult(false, "В пароле должно быть минимум 8 символов!");
            }
            bool a = false, b1 = false, b2 = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]))
                {
                    a = true;

                }
                if (char.IsLower(input[i]))
                {
                    b1 = true;

                }
                if (char.IsUpper(input[i]))
                {
                    b2 = true;

                }
            }
            if (!a)
            {
                return new ValidationResult(false, "В пароле должны быть цифры!");
            }
            if (!b1)
            {
                return new ValidationResult(false, "В пароле должны быть буквы нижнего регистра!");
            }
            if (!b2)
            {
                return new ValidationResult(false, "В пароле должны быть буквы верхнего регистра!");
            }
            return ValidationResult.ValidResult;
        }
    }
    public class IsLoginCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 5)
            {

                return new ValidationResult(false, "В логине должно быть минимум 5 символов!");
            }
            
            for (int i = 0; i < UserFormPage._service.Users.Count; i++)
            {
                if (UserFormPage._service.Users[i].Login==input&& UserFormPage._student.Login!=input)
                {
                    return new ValidationResult(false, "Такой логин уже есть!");
                }
            }
        
            
            return ValidationResult.ValidResult;
        }
    }
    public class IsEmailCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            bool a = true;
            for(int i=0;i<input.Length;i++)
            {
                if(input[i] =='@')
                {
a=false;    
                }
            }
            if(a)
            {
                return new ValidationResult(false, "В почте должна присутствовать @!");
            }

            for (int i = 0; i < UserFormPage._service.Users.Count; i++)
            {
                if (UserFormPage._service.Users[i].Email == input && UserFormPage._student.Email != input)
                {
                    return new ValidationResult(false, "Такая почта уже есть!");
                }
            }


            return ValidationResult.ValidResult;
        }
    }
    public class IsDateCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = DateTime.Parse((value ?? "").ToString().Trim());
            bool a = true;

            if (DateTime.Now > input)
            {
                return new ValidationResult(false, "дата и время создания не могут быть ранее текущей даты!");




                
            }
            return ValidationResult.ValidResult;
        }
    }
}

