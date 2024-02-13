using System.ComponentModel.DataAnnotations;

namespace crud_productList.Data
{
    public class ShowCourse
    {
        [Key]
        public int ShowCourseId { get; set; }
        
        
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        

        
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;


    }
}


