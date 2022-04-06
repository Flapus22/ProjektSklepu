using BD;
using Microsoft.EntityFrameworkCore;
using ProjektSklepu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjektSklepu.Services;

public interface IRepositoryService<T> where T : IEntity<int>
{
    IQueryable<T> GetAllRecords();

    T GetSingle(int id);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    ServiceResult Add(T entity);
    ServiceResult Delete(T entity);
    ServiceResult Edit(T entity);
    ServiceResult Save();
}
