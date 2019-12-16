using ClienteMercadoUPBC.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
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

       

        }




        protected override async void OnAppearing()
        {
            var content = await Client.GetStringAsync(url);
            var categoria = JsonConvert.DeserializeObject<List<Categoria>>(content);
            CategoriaProductos.ItemsSource = categoria;
            base.OnAppearing();

        }



       /* private void Cantidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayCantidad.Text = Cantidad.Value.ToString();
        }*/

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listview = sender as ListView;
            var selecteItem = (Categoria)listview.SelectedItem;
            string texto = selecteItem.Clave;
            if (texto != null)
            {

                await Navigation.PushAsync(new CategoriaProducto(texto));
            }

        }




           
           



    }
          
}

    
