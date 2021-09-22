using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Attributes
{
    public class UppercaseAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.GetType() == typeof(string)) 
            {
                string strValue = (string)value;
                return strValue.Equals(strValue.ToUpper(), StringComparison.Ordinal);
            }
            else
            {
                throw new ApplicationException("Attribute Uppercase only applicable to string");
            }
        }
    }
}
