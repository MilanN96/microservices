using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    [Table("Survey")]
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SurveyID { get; set; }

        [Required(ErrorMessage = "SurveyName is reqiured")]
        public string SurveyName { get; set; }

        [Required(ErrorMessage = "Description is reqiured")]
        public string Description { get; set; }

        [Required(ErrorMessage = "UserID is reqiured")]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "IsActive is reqiured")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Language is reqiured")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Creation date is reqiured")]
        public DateTime CreationDate { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
