using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesWeb.DTOs.Request.TeacherEntity;
using FluentValidation;

namespace CoursesWeb.BLL.FluentValidation
{
    public class TeacherCreateDTOValidator : AbstractValidator<TeacherCreateReqDTO>
    {
        public TeacherCreateDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Incorrect format of email!");

            RuleFor(n => n.FirstName)
                .NotEmpty().WithMessage("First name is required!")
                .Length(2,50).WithMessage("Name must be in range 3-50 symbols!!!");
            RuleFor(n => n.LastName)
                .NotEmpty().WithMessage("Last name is required!")
                .Length(2, 50).WithMessage("Last name must be in range 3-50 symbols!!!");


        }
    }
}
