namespace AmazingAmazon.Tests
{
    using AmazingAmazon.AutomationFramework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using Xunit;

    /// <summary>
    /// Test case that verifies authentication to Amazon.com using the Chrome browser.
    /// </summary>
    public sealed class SignInToAmazonUsingChromeBrowser
    {
        /// <summary>
        /// The instance of <see cref="ChromeDriver"/> that will automated the Chrome browser.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInToAmazonUsingChromeBrowser"/> class.
        /// </summary>
        /// <param name="driver">
        ///  An instance of <see cref="ChromeDriver"/> that will automated the Chrome browser.
        /// </param>
        public SignInToAmazonUsingChromeBrowser(ChromeDriver driver) =>
            this.driver = driver;

        /// <summary>
        /// Test method that verifies authentication to Amazon.com.
        /// </summary>
        [Trait(name: "Sign In", value: "Chrome")]
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
