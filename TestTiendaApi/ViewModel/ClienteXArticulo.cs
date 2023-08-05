namespace TestTiendaApi.ViewModel
{
    public class ClienteXArticulo
    {
        public int idArticulo { get; set; }
        public string Articulo { get; set; }
        public string Cliente { get; set; }
        public int idCliente { get; set; }
        public int idTienda { get; set; }
        public bool Asignada { get; set; }
    }
}
