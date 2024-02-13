using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace crud_productList.Models
{
    public class Product:DbContext
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lutfen açıklama sec")]
        public string? Description { get; set; }

     
        [Required(ErrorMessage = "Lutfen fiyat sec")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage ="Lutfen gorsel sec")]
        public string? inputGroupFile02 { get; set; }


        [Required(ErrorMessage = "Lutfen aktifliği sec")]
        public bool? IsActive { get; set; }

    }
}
