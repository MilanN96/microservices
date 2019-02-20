using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    [Table("OfferedAnswer")]
    public class OfferedAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OfferedAnswerID { get; set; }

        [Required(ErrorMessage = "Answer is reqiured")]
        public string Answer { get; set; }

        [ForeignKey("Question")]
        public long QuestionID { get; set; }

        public virtual Question Question { get; set; }

    }
}
