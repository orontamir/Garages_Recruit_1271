using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garages_Recruit_1271.Utilities
{
    public class ValidationEmailDomainAttribute: ValidationAttribute
    {
        public ValidationEmailDomainAttribute(string allowedDomain)
        {

        }
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
