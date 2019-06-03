[assembly: Xunit.TestFramework("AmazingAmazon.Tests.Startup", "AmazingAmazon.Tests")]
namespace AmazingAmazon.Tests
{
    using Microsoft.Extensions.DependencyInjection;

    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    using Xunit.Abstractions;
    using Xunit.DependencyInjection;

    public sealed class Startup : DependencyInjectionTestFramework
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="messageSink">
        /// An endpoint for the reception of messages produced by tests.
        /// </param>
        public Startup(IMessageSink messageSink) : base(messageSink)
        {
        }

        /// <summary>
        /// Configures dependency injection.
        /// </summary>
        /// <param name="services">
        /// A collection of service descriptors.
        /// </param>
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(
                x => new ChromeDriver(@"C:\Projects\AmazingAmazon\AmazingAmazon.Tests\bin\Debug\netcoreapp2.1"));

            services.AddTransient(
                x => new FirefoxDriver(@"C:\Projects\AmazingAmazon\AmazingAmazon.Tests\bin\Debug\netcoreapp2.1"));

        }
    }
}
