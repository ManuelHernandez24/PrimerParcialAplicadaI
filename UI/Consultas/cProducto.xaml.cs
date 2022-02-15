using System.Windows;
using Victor_Estevez_Ap1_p1.Entidades;
using Victor_Estevez_Ap1_p1.BLL;
using System.Linq;
using System.Collections.Generic;
using Victor_Estevez_Ap1_p1.UI.Registros;
using System.Text.RegularExpressions;

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
            bool validacion = true;

            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text)) //si no hay criterio, busco todos        
                listado = ProductoBLL.GetList(l => true);
            else
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        if (Regex.IsMatch(CriterioTextBox.Text, "[^0-9.-]")){
                            validacion = false;
                            MessageBox.Show($"Solo se permite ingresar números para buscar por ID.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }                            
                        listado = ProductoBLL.GetList(l => l.ProductoId == int.Parse(CriterioTextBox.Text));
                        break;
                    case 1: 
                        listado = ProductoBLL.GetList(l => l.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }
            }
            if(validacion){
                ProductoDataGrid.ItemsSource = null;
                ProductoDataGrid.ItemsSource = listado;
            }
            
        }
    }
}

        
