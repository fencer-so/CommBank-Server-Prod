using System;
using CommBank.Models;
using Microsoft.Extensions.Options;

namespace CommBank.Tests
{
    public class FakeDatabaseSettings : IOptions<DatabaseSettings>
    {
        DatabaseSettings IOptions<DatabaseSettings>.Value => throw new NotImplementedException();
    }
}

