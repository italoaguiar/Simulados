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

namespace Simulado_Remote_Administration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EF.LocalDBEntities ef = new EF.LocalDBEntities();
            foreach(var item in ef.Subcategorias)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = item.Nome;
                i.Tag = item.Id;

                cat.Items.Add(i);
            }
        }

        private void alternativas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(alternativas.SelectedItem != null)
            {
                try
                {
                    var item = (ListBoxItem)alternativas.SelectedItem;
                    Title = item.Tag.ToString();
                }
                catch { }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(alt.Text))
            {
                EF.LocalDBEntities ef = new EF.LocalDBEntities();
                EF.Alternativas a = new EF.Alternativas()
                {
                    Valor = alt.Text
                };
                ef.Alternativas.Add(a);
                ef.SaveChanges();
                alternativas.Items.Add(new ListBoxItem()
                {
                    Content = a.Valor,
                    Tag = a.Id
                });
                alt.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EF.LocalDBEntities ef = new EF.LocalDBEntities();
            EF.Questoes q = new EF.Questoes()
            {
                Enunciado = Enunciado.Text,
                Correta = int.Parse(Title),
                Cat = int.Parse((cat.SelectedItem as ComboBoxItem).Tag.ToString())
            };
            foreach(ListBoxItem i in alternativas.Items)
            {
                q.Alternativas1.Add(new EF.Alternativas()
                {
                    Id = int.Parse(i.Tag.ToString())
                });
            }
            ef.Questoes.Add(q);
            ef.SaveChanges();
            Enunciado.Clear();
            alternativas.Items.Clear();

            
        }
    }
}
