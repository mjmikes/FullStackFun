using System.ComponentModel.DataAnnotations;

namespace FullStackFun.Data;

public class MarriottFood
{
    [Key]
    public int FoodId { get; set; }
    [Required]
    public string EventName { get; set; }
    [Required]
    public string Vendor { get; set; }
    [Required]
    public int FoodRating { get; set; }
}