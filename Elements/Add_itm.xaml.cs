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
    /// Логика взаимодействия для Add_itm.xaml
    /// </summary>
    public partial class Add_itm : UserControl
    {
        Page page_str;
        public Add_itm(Page _page_str)
        {
            InitializeComponent();
            page_str = _page_str;

            DoubleAnimation orgridAnimation = new DoubleAnimation();
            orgridAnimation.From = 0;
            orgridAnimation.To = 1;
            orgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, orgridAnimation);
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_Move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, page_str);
        }
    }
}
