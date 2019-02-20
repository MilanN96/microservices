using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QuestionID { get; set; }

        [Required(ErrorMessage = "Question is reqiured")]
        public string QuestionValue { get; set; }

        [ForeignKey("Survey")]
        public long SurveyID { get; set; }

        [ForeignKey("TypeOfQuestion")]
        public long TypeOfQuestionID { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual TypeOfQuestion TypeOfQuestion { get; set; }

        public ICollection<OfferedAnswer> OfferedAnswars { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
