using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReportGenerator.Models
{
     public class ActivityModel
    {
        //Fields
        private int id;
        private string name;
        private string description;
        private string type;
        private string descriptionURL;

        // Properties - Validations
        [DisplayName("Activity ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Activity Name")]
        [Required(ErrorMessage = "Campo Nome é requerido")]
        public string Name { get => name; set => name = value; }
        
        [DisplayName("Activity Description")]
        [Required(ErrorMessage = "Campo Descrição é requerido")]
        public string Description { get => description; set => description = value; }

        [DisplayName("Activity Type")]
        public string Type { get => type; set => type = value; }

        [DisplayName("Activity DescriptionURL")]
        [Required(ErrorMessage = "Campo DescriçãoURL é requerido")]
        public string DescriptionURL { get => descriptionURL; set => descriptionURL = value; }
    }
}
