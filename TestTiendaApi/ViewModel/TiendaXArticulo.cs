namespace TestTiendaApi.ViewModel
{
    public class TiendaXArticulo
    {
        public int idArticulo { get; set; }
        public string Descripcion { get; set; }    
        public string Sucursal { get; set; } 
        public int idTienda { get; set; }    
        public bool Asignada { get; set; }         
    }
}
