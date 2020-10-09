﻿using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Item> Items { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
