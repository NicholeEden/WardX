using EFCore.Domain;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class ClockingTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public ClockingTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        // provides an instance of EFCore DatabaseContext
        private readonly TestDatabaseContext context;

        public ClockingTests()
        {
            // configure EFCore DatabaseContext to be created in the memory
            var options = new DbContextOptionsBuilder<TestDatabaseContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            // apply the configurations to EFCore DatabaseContext
            context = new TestDatabaseContext(options);
            // creates the database if it does not exist
            context.Database.EnsureCreated();
        }

      

    }
}
