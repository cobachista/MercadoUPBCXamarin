using ClienteMercadoUPBC.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteMercadoUPBC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaProducto : ContentPage
    {
        private HttpClient Client = new HttpClient();
        private List<Producto> Lista;
        private string IdCategoria;
        public CategoriaProducto(string Categoria)
        {
            InitializeComponent();
            IdCategoria = Categoria;
        }

        protected override async void OnAppearing()
        {
            string url1 = "https://upbcmercado2019.000webhostapp.com/CategoriaClave.php?id=" + IdCategoria;
            var content = await Client.GetStringAsync(url1);
            var productos = JsonConvert.DeserializeObject<List<Producto>>(content);
            products.ItemsSource = productos;
            base.OnAppearing();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listview = sender as ListView;
            var selecteItem = (Producto)listview.SelectedItem;
            string texto = selecteItem.Clave;
            string Nombre = selecteItem.Nombre;
            if (texto != null)
            {

                await Navigation.PushAsync(new ShoppingCar(Nombre,texto));
            }

        }
    }
}