using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AnswerID { get; set; }

        [Required(ErrorMessage = "Answer is reqiured")]
        public string AnswerValue { get; set; }

        [ForeignKey("Question")]
        public long QuestionID { get; set; }

        public virtual Question Question { get; set; }
    }
}
