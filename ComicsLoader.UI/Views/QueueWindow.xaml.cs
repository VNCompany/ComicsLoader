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
using System.Windows.Shapes;

namespace ComicsLoader.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для QueueWindow.xaml
    /// </summary>
    public partial class QueueWindow : Window
    {
        public QueueWindow()
        {
            InitializeComponent();
        }
    }

    public record TestCollectionItem(string Url, int Percent);

    public class TestCollection : List<TestCollectionItem>
    {
        public TestCollection()
        {
            Add(new TestCollectionItem("http://localhost/test/2", 50));
            Add(new TestCollectionItem("https://telegra.ph/Ohota-za-golovami--Bounty-Hunted-06-04", 100));
        }
    }
}
