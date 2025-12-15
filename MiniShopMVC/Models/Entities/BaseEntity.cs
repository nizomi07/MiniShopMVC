using System.ComponentModel.DataAnnotations;

namespace MiniShopMVC.Models.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}