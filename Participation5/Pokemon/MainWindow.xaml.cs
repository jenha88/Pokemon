using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1118").Result;

                PP call = JsonConvert.DeserializeObject<PP>(jsonData);
                foreach (var item in call.results)
                {

                    lstbox.Items.Add(item);
                }
            }

        }

        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokie P = (Pokie)lstbox.SelectedItem;
            using (var client = new HttpClient())
            {
                string Jdata = client.GetStringAsync(P.url).Result;
                info2 PI = JsonConvert.DeserializeObject<info2>(Jdata);
                imgBox.Source = new BitmapImage(new Uri(PI.sprites.front_default));
                txtH.Text = PI.height;
                txtW.Text = PI.weight;

            }
            
        }

        private void btb1_Click(object sender, RoutedEventArgs e)
        {
            Pokie P = (Pokie)lstbox.SelectedItem;
            using (var client = new HttpClient())
            {
                string Jdata = client.GetStringAsync(P.url).Result;
                info2 PI = JsonConvert.DeserializeObject<info2>(Jdata);
                imgBox.Source = new BitmapImage(new Uri(PI.sprites.front_default));
               

            }

        }

        private void btb2_Click(object sender, RoutedEventArgs e)
        {
            Pokie P = (Pokie)lstbox.SelectedItem;
            using (var client = new HttpClient())
            {
                string Jdata = client.GetStringAsync(P.url).Result;
                info2 PI = JsonConvert.DeserializeObject<info2>(Jdata);
                imgBox.Source = new BitmapImage(new Uri(PI.sprites.back_default));
          

            }
        }
    }
}
