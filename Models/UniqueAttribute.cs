using System.ComponentModel.DataAnnotations;

namespace ITI.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        ITIEntity context=new ITIEntity();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           Course course = (Course)validationContext.ObjectInstance ;

            var existingCourse = context.Courses
                .FirstOrDefault(c => c.Dept_Id == course.Dept_Id && c.Name == course.Name);
            if (existingCourse == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Course already found in this department");
            }



        }
    }
}
