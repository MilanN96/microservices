using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ISurveyRepository Survey { get;}
        IQuestionRepository Question { get; }
        ITypeOfQuestionRepository TypeOfQuestion { get; }
        IAnswerRepository Answer { get; }
        IOfferedAnswerRepository OfferedAnswer { get; }
    }
}
