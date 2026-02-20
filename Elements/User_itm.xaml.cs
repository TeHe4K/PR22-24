using ClassModule;
using PR22_24_Konevskii.Pages;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR22_24_Konevskii.Elements
{
    /// <summary>
    /// Логика взаимодействия для User_itm.xaml
    /// </summary>
    public partial class User_itm : UserControl
    {
        User user_loc;
        public User_itm(User _user)
        {
            InitializeComponent();
            user_loc = _user;
            if(_user.fio_user != null)
            {
                name_user.Content = _user.fio_user;
                phone_user.Content = "Номер: " + _user.phone_num;
            }

            DoubleAnimation orgridAnimation = new DoubleAnimation();
            orgridAnimation.From = 0;
            orgridAnimation.To = 1;
            orgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, orgridAnimation);
        }

        public void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.framme_main, MainWindow.main.scroll_main, null, null, Main.page_main.users);
        }
        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);
                call userFind = MainWindow.connect.calls.Find(x => x.user_id == user_loc.id);
                if (userFind != null)
                {
                    var click = MessageBox.Show("У данного клиента есть звонки, все равно его удалить?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (click == MessageBoxResult.No)
                        return;
                }
                string vs1 = $"DELETE FROM [calls] WHERE [user_id] = '{user_loc.id.ToString()}'";
                var pc1 = MainWindow.connect.QueryAccess(vs1);

                string vs = $"DELETE FROM [users] WHERE [Код] = " + user_loc.id.ToString() + "";
                var pc = MainWindow.connect.QueryAccess(vs);

                if (pc != null && pc1 != null)
                {
                    MessageBox.Show("Успешное удаление клиента", "Успешное", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(ClassConnection.Connection.tabels.users);
                    MainWindow.main.Anim_move(MainWindow.main.framme_main, MainWindow.main.scroll_main, null, null, Main.page_main.users);
                }
                else
                {
                    MessageBox.Show("Запрос на удаление клиента не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
