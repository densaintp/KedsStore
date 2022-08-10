using System.ComponentModel.DataAnnotations;

namespace KedsStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Image Path")]
        public string ImgPath { get; set; }
        [Required,
        DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}
