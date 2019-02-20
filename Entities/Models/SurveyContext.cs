using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservices.Models
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<OfferedAnswer> OfferedAnswers { get; set; }
        public DbSet<TypeOfQuestion> TypeOfQuestions { get; set; }
    }
}
