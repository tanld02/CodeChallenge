﻿using Microsoft.EntityFrameworkCore;
using CodeChallenge.App.Core.Entities;

namespace CodeChallenge.App.Core.Interfaces;

public interface IDbContext
{
    /// <summary>
    /// Asynchronously saves the changes to DB.
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();
    /// <summary>
    /// Context will not track entities. This will increase performance for readonly scenarios.
    /// </summary>
    void SetAsNoTracking();
    /// <summary>
    /// Map model of <typeparamref name="T"/> to table in database
    /// </summary>
    /// <typeparam name="T">Type of model</typeparam>
    /// <returns></returns>
    DbSet<T> GetSet<T>() where T : class;

    DbSet<Movie> Movies { get; set; }
    DbSet<Director> Directors { get; set; }
}
