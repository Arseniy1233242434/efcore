using EfCore.Data;
using EfCore.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для GroupForm.xaml
    /// </summary>
    /// Group _group = new();
    
    public partial class GroupForm : Page
    {
       public static InterestGroup _group = new();
        public InterestsService service { get; set; } = new();
        bool IsEdit = false;
        public GroupForm(InterestGroup? group = null)
        {
            InitializeComponent();
            if (group != null)
            {
                _group = group;
                IsEdit = true;
                DataContext = _group;
                service.LoadRelation(group, "Users");
                return;
            }
            
            _group = new InterestGroup();
            DataContext = _group;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_group);

            Button_Click_1(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
    public class IsTitleCorrect : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            

            for (int i = 0; i < InterestsService.Cources.Count; i++)
            {
                if (InterestsService.Cources[i].Title == input && GroupForm._group.Title != input)
                {
                    return new ValidationResult(false, "Такая группа уже есть!");
                }
            }


            return ValidationResult.ValidResult;
        }
    }
    public class Converter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            var t = (bool)value;
            if (t==false)
            {
                return "Участник";
            }

            
            return "Модератор";

        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
