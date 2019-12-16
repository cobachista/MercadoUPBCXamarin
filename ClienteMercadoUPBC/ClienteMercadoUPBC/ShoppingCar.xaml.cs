using ClienteMercadoUPBC.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteMercadoUPBC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCar : ContentPage
    {
        private string IdProducto;
        private string NombreProducto;
        private List<Pedido> pedido = new List<Pedido>();

        public ShoppingCar(string Nombre,string texto)
        {
            InitializeComponent();
            IdProducto = texto;
            NombreProducto = Nombre;
            var np = NombreProducto.ToString();
            Titulo.Text = np;
            DisplayCantidad.Text = "0";

        }

        private void Cantidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
           DisplayCantidad.Text = Cantidad.Value.ToString();
        }

        private void Registrar_Clicked(object sender, EventArgs e)
        {
            var cantidad = DisplayCantidad.Text;
           

        pedido.Add(new Modelo.Pedido
                {
                    Clave = IdProducto.ToString(),
                    Nombre = NombreProducto,
                    cantidad = cantidad.ToString(),

                });
            foreach (var a in pedido) {
                Console.WriteLine(a);
            }

            
      

        }
    }
}