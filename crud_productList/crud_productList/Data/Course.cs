using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace crud_productList.Data
{
    public class Course 
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
       
    }
}
