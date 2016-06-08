using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IFlatPlanetExam.Model
{
    public class PressViewModel : IValidatableObject
    {
        /// <summary>
        /// Click count
        /// </summary>
        public int count { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (count > 10)
            {
                yield return new ValidationResult("Youve reach the maximum number of clicked!");
            }
        }
    }


}
