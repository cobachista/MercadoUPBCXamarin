using ClienteMercadoUPBC.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClienteMercadoUPBC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string url = "https://upbcmercado2019.000webhostapp.com/Categoriaweb.php";
        private HttpClient Client = new HttpClient();
        private ObservableCollection<Categoria> Categorias;
        public MainPage()
        {
            InitializeComponent();
            DisplayCantidad.Text = "0";
        }

        


        protected override async void OnAppearing()
        {
            var content = await Client.GetStringAsync(url);
            var categoriaJson = JsonConvert.DeserializeObject<List<Categoria>>(content);
            Categorias = new ObservableCollection<Categoria>(categoriaJson);
            lsCategoria.ItemsSource = Categorias;
            base.OnAppearing();

        }

        private void lsCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            string llave;
        }

        private void Cantidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayCantidad.Text = Cantidad.Value.ToString();
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {

        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
