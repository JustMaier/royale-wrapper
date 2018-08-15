using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RoyaleWrapper.Test {
    public class TestBase {
        protected readonly RoyaleWrapper.Client client;
        protected readonly TestConfiguration config;
        public TestBase() {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            config = new TestConfiguration();
            configuration.GetSection(nameof(config)).Bind(config);
            client = new Client(config.Key);
        }
    }
}
