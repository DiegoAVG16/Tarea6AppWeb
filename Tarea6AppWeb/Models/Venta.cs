using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tarea6AppWeb.Models;

public partial class Venta
{
    [Key]
    [Column("ID_Venta")]
    public int IdVenta { get; set; }

    [Column("ID_Celular")]
    public int IdCelular { get; set; }

    [Column("ID_Cliente")]
    public int IdCliente { get; set; }

    [Column("Fecha_Venta", TypeName = "datetime")]
    public DateTime FechaVenta { get; set; }

    public int Cantidad { get; set; }

    [ForeignKey("IdCelular")]
    [InverseProperty("Venta")]
    public virtual Celulare IdCelularNavigation { get; set; } = null!;

    [ForeignKey("IdCliente")]
    [InverseProperty("Venta")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
