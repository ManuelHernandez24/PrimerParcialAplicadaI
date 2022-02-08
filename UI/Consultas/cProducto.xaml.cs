using System.Windows;
using Victor_Estevez_Ap1_p1.Entidades;
using Victor_Estevez_Ap1_p1.BLL;
using System.Linq;
using System.Collections.Generic;
using Victor_Estevez_Ap1_p1.UI.Registros;

namespace Victor_Estevez_Ap1_p1.UI.Consultas
{
    public partial class cProducto : Window
    {
        public cProducto()
        {
            InitializeComponent();
        } 

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            var listado = new List<Producto>();
            
            if(string.IsNullOrWhiteSpace(CriterioTextBox.Text)){
                listado = ProductoBLL.GetList(l >= true);
            }
            */

            ProductoDataGrid.ItemsSource = ProductoBLL.GetLista();
        }
    }
}

        
