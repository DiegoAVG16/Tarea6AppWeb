using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tarea6AppWeb.Models;

public partial class Celulare
{
    [Key]
    [Column("ID_Celular")]
    public int IdCelular { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Marca { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Modelo { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    public int Stock { get; set; }

    [InverseProperty("IdCelularNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
