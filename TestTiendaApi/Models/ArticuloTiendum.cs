using System;
using System.Collections.Generic;

namespace TestTiendaApi.Models;

public partial class ArticuloTiendum
{
    public int Id { get; set; }

    public int IdArticulo { get; set; }

    public int IdTienda { get; set; }

    public string Fecha { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; }

    public virtual Tienda IdTiendaNavigation { get; set; }
}
