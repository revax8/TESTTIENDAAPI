using System;
using System.Collections.Generic;

namespace TestTiendaApi.Models;

public partial class Tienda
{
    public int Id { get; set; }

    public string Sucursal { get; set; }

    public string Direccion { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; } = new List<ArticuloTiendum>();
}
