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
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, MinimumLength=10, ErrorMessage ="Name must be at least 10 characters")]
        public string Name { get => name; set => name = value; }
        
        [DisplayName("Activity Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Description must be at least 10 characters")]
        public string Description { get => description; set => description = value; }

        [DisplayName("Activity Type")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Type must be at least 10 characters")]
        public string Type { get => type; set => type = value; }

        [DisplayName("Activity DescriptionURL")]
        [Required(ErrorMessage = "DescriptionURL is required")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "DescriptionURL must be at least 10 characters")]
        public string DescriptionURL { get => descriptionURL; set => descriptionURL = value; }
    }
}
