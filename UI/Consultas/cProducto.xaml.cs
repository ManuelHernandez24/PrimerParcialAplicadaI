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
            var listado = new List<Producto>();

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text)) //si no hay criterio, busco todos         
                listado = ProductoBLL.GetList(l => true);
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = ProductoBLL.GetList(l => l.ProductoId == int.Parse(CriterioTextBox.Text));
                        break;
                    case 1: 
                        listado = ProductoBLL.GetList(l => l.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            ProductoDataGrid.ItemsSource = null;
            ProductoDataGrid.ItemsSource = listado;
        }
    }
}

        
