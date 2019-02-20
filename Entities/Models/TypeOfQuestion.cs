using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    [Table("TypeOfQuestion")]
    public class TypeOfQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TypeOfQuestionID { get; set; }

        [Required(ErrorMessage = "Type name is reqiured")]
        public string TypeName { get; set; }

        [Required(ErrorMessage = "Format is reqiured")]
        public string Format { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
 