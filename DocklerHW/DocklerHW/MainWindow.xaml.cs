using System;
using DataProvider;
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
using System.ComponentModel;

namespace DocklerHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBaseDataProvider m_DataProvider = new AWEmpireDataProvider();
        public MainWindow()
        {
            DataContext = m_DataProvider;

            m_DataProvider.FetchDataAsync();
            InitializeComponent();
        }
    }
}
