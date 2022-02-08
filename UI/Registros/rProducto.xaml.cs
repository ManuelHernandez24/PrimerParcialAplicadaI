using System;
using System.Windows;
using Victor_Estevez_Ap1_p1.Entidades;
using Victor_Estevez_Ap1_p1.BLL;
namespace Victor_Estevez_Ap1_p1.UI.Registros
{
    public partial class rProducto : Window
    {
        private Producto producto = new Producto();
        public rProducto(){
            InitializeComponent();
            Cargar();
        }

        void Cargar(){
            this.DataContext = null;
            this.DataContext = this.producto;
        }
        
        void Limpiar(){
            this.producto = new Producto();
            this.DataContext = producto;
        }

        void calcularInventario(){

            float existencia = float.Parse(TextBoxValorExistencia.Text);
            float costo = float.Parse(TextBoxCosto.Text);

            float valorInventario = existencia * costo;
            TextBoxValorInventario.Text = Convert.ToString(valorInventario);
            producto.ValorInventario = valorInventario;
            
        }
        private bool Validar(){
            bool esValido = true;
                if(string.IsNullOrWhiteSpace(producto.Descripcion)){
                    esValido = false;
                    TextBoxDescripcion.Focus();
                    MessageBox.Show("No puede dejar el campo de descripcion vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
                }            
                else if(string.IsNullOrWhiteSpace(Convert.ToString(producto.Existencia))){
                    esValido = false;
                    TextBoxValorExistencia.Focus();
                    MessageBox.Show("No puede dejar el campo de existencia vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
                }else if(string.IsNullOrWhiteSpace(Convert.ToString(producto.Costo))){
                    esValido = false;
                    TextBoxCosto.Focus();
                    MessageBox.Show("No puede dejar el campo de costo vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
                }            
            return esValido;         
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductoBLL.Buscar(this.producto.ProductoId);

            if(encontrado != null){
                this.producto = encontrado;
                Cargar();
            }else{
                Limpiar();
                MessageBox.Show("No se encontro el producto.","Fallo", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!ProductoBLL.ExisteDescripcion(producto.Descripcion)){
                bool paso = false;

                if(!Validar()){
                    return;
                }
                calcularInventario();
                
                paso = ProductoBLL.Guardar(producto);

                if(paso){
                    MessageBox.Show("El producto se guardó con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }else{
                    MessageBox.Show("El producto no se guardó", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else{
                 MessageBox.Show($"Ya hay un producto con la descripción {TextBoxDescripcion.Text}", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductoBLL.Eliminar(producto.ProductoId)){
                Limpiar();
                MessageBox.Show("El producto se eliminó con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            } else{
                 MessageBox.Show("No fue posible eliminar el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}