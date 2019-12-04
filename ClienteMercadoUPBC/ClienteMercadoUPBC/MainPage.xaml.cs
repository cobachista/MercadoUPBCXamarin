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
        private ObservableCollection<Producto> Productos;
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



        private void Cantidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayCantidad.Text = Cantidad.Value.ToString();
        }


        private async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient Client1 = new HttpClient();
            Picker picker = sender as Picker;
            var selectedItem = (Categoria)picker.SelectedItem;
            string texto = selectedItem.Clave.ToString();
            string url1 = "https://upbcmercado2019.000webhostapp.com/CategoriaClave.php?id="+texto;
            var content = await Client.GetStringAsync(url1);
            var productosJson = JsonConvert.DeserializeObject<List<Producto>>(content);
            Productos = new ObservableCollection<Producto>(productosJson);
            if (Productos == null)
            {
                await DisplayAlert("Mensaje","No Valores Seleccionar","Ok");
            }
            else
            {
                lsProducto.ItemsSource = Productos;
            }
            base.OnAppearing();

           
           



        }
          
    }
}
    
