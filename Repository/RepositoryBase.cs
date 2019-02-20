using Contracts;
using Microsoft.EntityFrameworkCore;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SurveyContext SurveyContext { get; set; }

        public RepositoryBase(SurveyContext surveyContext)
        {
            this.SurveyContext = surveyContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.SurveyContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await this.SurveyContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public void Create(T entity)
        {
            this.SurveyContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.SurveyContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.SurveyContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this.SurveyContext.SaveChangesAsync();
        }
    }
}
