using StudentRegistrationSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class EntityHelper
    {
        public StudentRegistrationContext _dbContext { get; set; }

        public EntityHelper()
        {
            _dbContext = new StudentRegistrationContext();

        }
    }
}