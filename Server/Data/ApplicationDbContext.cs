﻿using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMSBlazor.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static LexiconLMSBlazor.Client.Pages.StudentAll;

namespace LexiconLMSBlazor.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Module> Module { get; set; } = default!;
        public DbSet<Activity> Activity { get; set; } = default!;
        public DbSet<ActivityType> ActivityType { get; set; } = default!;
        public DbSet<Document> Document { get; set; } = default!;
    }
}