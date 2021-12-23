using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SampleRESTAPI.Dtos;

namespace SampleRESTAPI.ValidationAttributes
{
    public class StudentFirstLastMustBeDifferentAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (StudentForCreateDto)validationContext.ObjectInstance;
            if (student.FirstName == student.LastName)
                return new ValidationResult("Firstname dan lastname tidak boleh sama",
                    new[] {nameof(StudentForCreateDto) });
            return ValidationResult.Success;
        }

    }
}
