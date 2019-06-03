namespace AmazingAmazon.Tests
{
    using AmazingAmazon.AutomationFramework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    using Xunit;

    /// <summary>
    /// Test case that verifies authentication to Amazon.com using the Firefox browser.
    /// </summary>
    public sealed class SignInToAmazonUsingFirefoxBrowser
    {
        /// <summary>
        /// The instance of <see cref="FirefoxDriver"/> that will automated the Firefox browser.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInToAmazonUsingFirefoxBrowser"/> class.
        /// </summary>
        /// <param name="driver">
        ///  An instance of <see cref="FirefoxDriver"/> that will automated the Firefox browser.
        /// </param>
        public SignInToAmazonUsingFirefoxBrowser(FirefoxDriver driver) =>
            this.driver = driver;

        /// <summary>
        /// Test method that verifies authentication to Amazon.com.
        /// </summary>
        [Trait(name: "Sign In", value: "Firefox")]
        [Fact(DisplayName = "Should sign in to Amazon.com")]
        public void _001()
        {
            AmazonAuthenticator
                .Initialize(this.driver)
                .SignInAs("ejaiyeola@outlook.com")
                .UsingPassword("amazon")
                .InitiateSignIn();

            Assert.True(AmazonAuthenticator
                            .Initialize(this.driver)
                            .IsSignedIn, "Failed to sign in to Amazon.com.");
        }
    }
}
