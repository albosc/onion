﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; } = null!;

    public async Task<int> SaveChangesAsync() =>
        await base.SaveChangesAsync();
}
