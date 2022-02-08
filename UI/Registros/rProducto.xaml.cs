using System;
using System.Windows;
using Victor_Estevez_Ap1_p1.Entidades;
using Victor_Estevez_Ap1_p1.BLL;
namespace Victor_Estevez_Ap1_p1.UI.Registros
{
    public partial class rProducto : Window
    {
        private Producto Producto = new Producto();
        public rProducto(){
            InitializeComponent();
            Cargar();
        }

        void Cargar(){
            this.DataContext = null;
            this.DataContext = this.Producto;
        }
        
        void Limpiar(){
            this.Producto = new Producto();
            this.DataContext = Producto;
        }

        void calcularInventario(){
            float ValorInventario = float.Parse(TextBoxValorExistencia.Text) * float.Parse(TextBoxCosto.Text);
            TextBoxValorInventario.Text = Convert.ToString(ValorInventario);
        }
        private bool Validar(){
            bool esValido = true;
            calcularInventario();

            if(string.IsNullOrWhiteSpace(Producto.Descripcion)){
                esValido = false;
                TextBoxDescripcion.Focus();
                MessageBox.Show("No puede dejar el campo de descripcion vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
            }            
            else if(string.IsNullOrWhiteSpace(Convert.ToString(Producto.Existencia))){
                esValido = false;
                TextBoxValorExistencia.Focus();
                MessageBox.Show("No puede dejar el campo de existencia vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
            }else if(string.IsNullOrWhiteSpace(Convert.ToString(Producto.Costo))){
                esValido = false;
                TextBoxCosto.Focus();
                MessageBox.Show("No puede dejar el campo de costo vacio.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if(string.IsNullOrWhiteSpace(Convert.ToString(Producto.ValorInventario))){ 
                esValido = false;
                TextBoxValorInventario.Focus();
                MessageBox.Show("No se pudo calcular el valor de inventario.","Validación", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            return esValido;            
        }
            
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductoBLL.Buscar(this.Producto.ProductoId);

            if(encontrado != null){
                this.Producto = encontrado;
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
            bool paso = false;

            if(!Validar()){
                return;
            }

            paso = ProductoBLL.Guardar(Producto);

            if(paso){
                MessageBox.Show("El producto se guardó con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }else{
                MessageBox.Show("El producto no se guardó", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductoBLL.Eliminar(Producto.ProductoId)){
                Limpiar();
                MessageBox.Show("El producto se eliminó con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            } else{
                 MessageBox.Show("No fue posible eliminar el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}