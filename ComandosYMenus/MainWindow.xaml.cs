using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace ComandosYMenus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock Copia { get; set; }
        ObservableCollection<TextBlock> Lista = new ObservableCollection<TextBlock>();
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            ListaListBox.DataContext = Lista;
            VentanaDockPanel.DataContext = this;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += dispatcherTimer_Tick;
            timer.Start();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            HoraTextBlock.Text = DateTime.Now.ToLongTimeString();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Item añadido a las " + DateTime.Now.Hour+":"+DateTime.Now.Minute+ ":" + DateTime.Now.Second;
            Lista.Add(textBlock);
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Lista.Count < 10)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void VaciarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lista.Clear();
        }

        private void VaciarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Lista.Count > 0;
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Copia = (TextBlock)ListaListBox.SelectedItem;
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Lista.Count()>0 && ListaListBox.SelectedItem != null;
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock aux = new TextBlock();
            aux.Text = Copia.Text;
            Lista.Add(aux);
            Copia = null;
        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Copia != null;
        }

        private void SalirCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

    }
}
