using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swagger.API.Models;
/// <summary>
/// Ürün Nesnesi
/// </summary>
public partial class Product
{
    /// <summary>
    /// Ürün id'si
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Ürün İsmi
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Ürün Fiyatı
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Ürün eklenme tarihi
    /// </summary>
    public DateTime? Date { get; set; }
    /// <summary>
    /// Ürün Kategorisi
    /// </summary>
    public string? Category { get; set; }
}
