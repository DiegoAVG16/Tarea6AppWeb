using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tarea6AppWeb.Models;

[Index("Email", Name = "UQ__Clientes__A9D105349F652B02", IsUnique = true)]
public partial class Cliente
{
    [Key]
    [Column("ID_Cliente")]
    public int IdCliente { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
