﻿using Bogus;
using DAL.Entities;

namespace CoursesWeb.Data.BogusSeed.Fakers
{
    public class EnrollmentFaker : Faker<EnrollmentEntity>
    {
        public EnrollmentFaker() {
            RuleFor(e => e.EnrolledAt, f => f.Date.Past());

        }
    }
}
