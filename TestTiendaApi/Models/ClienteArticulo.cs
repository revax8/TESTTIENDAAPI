using System;
using System.Collections.Generic;

namespace TestTiendaApi.Models;

public partial class ClienteArticulo
{
    public int IdCliente { get; set; }

    public int IdArticulo { get; set; }

    public int Fecha { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }
}
