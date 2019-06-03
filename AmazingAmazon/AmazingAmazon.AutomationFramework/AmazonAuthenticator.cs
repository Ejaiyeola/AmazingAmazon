namespace AmazingAmazon.AutomationFramework
{
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the process of authenticating to Amazon.com.
    /// </summary>
    public sealed class AmazonAuthenticator : IProvideUserId, IProvideUserPassword, IInitiateSignIn
    {
        /// <summary>
        /// The instance of <see cref="IWebDriver"/> that will automated a web browser.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// The user id for authenticating to Amazon.com.
        /// </summary>
        private string id;

        /// <summary>
        /// The password for authenticating to Amazon.com.
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonAuthenticator"/> class.
        /// </summary>
        /// <param name="driver">
        /// An instance of <see cref="IWebDriver"/> that will automated a web browser.
        /// </param>
        private AmazonAuthenticator(IWebDriver driver) =>
            this.driver = driver;

        /// <summary>
        /// Gets a value indicating whether or not a user is currently signed in to Amazon.com.
        /// </summary>
        /// <returns>
        /// Returns <c>true</c> if a user is currently signed into Amazon.com; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSignedIn =>
            IsAuthenticated(this.driver);

        /// <summary>
        /// Creates a new instance of <see cref="AmazonAuthenticator"/> that is initialized with an
        /// <see cref="IWebDriver"/>.
        /// </summary>
        /// <param name="driver">
        /// An instance of <see cref="IWebDriver"/> that will automated a web browser.
        /// </param>
        /// <returns>
        /// Returns an new instance of <see cref="AmazonAuthenticator"/>.
        /// </returns>
        public static IProvideUserId Initialize(IWebDriver driver) =>
            new AmazonAuthenticator(driver);

        /// <summary>
        /// Gets a value indicating whether or not a user is currently signed in to Amazon.com.
        /// </summary>
        /// <param name="driver">
        /// An instance of <see cref="IWebDriver"/> that will automated a web browser.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if a user is currently signed into Amazon.com; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsAuthenticated(IWebDriver driver) =>
            driver.FindElements(By.XPath(@"//*[@id=""nav-link-accountList""]/span[1]")).Count > 0
                ? !(driver.FindElement(By.XPath(@"//*[@id=""nav-link-accountList""]/span[1]")).Text == "Hello, Sign In")
                : false;

        /// <summary>
        /// Automates a web browser to sign in to Amazon.com.
        /// </summary>
        /// <param name="id">
        /// The user id for authenticating to Amazon.com.
        /// </param>
        /// <param name="password">
        /// The password for authenticating to Amazon.com.
        /// </param>
        /// <param name="driver">
        /// An instance of <see cref="IWebDriver"/> that will automated a web browser.
        /// </param>
        private static void SignIn(string id, string password, IWebDriver driver)
        {
            driver.Url = "http://www.amazon.com";

            // Navigate to the screen for sign on.
            IWebElement element = driver.FindElement(By.Id("nav-link-accountList"));
            element.Click();

            // Provide the user id
            element = driver.FindElement(By.Id("ap_email"));
            element.SendKeys(id);

            // Provide the password.
            element = driver.FindElement(By.Id("ap_password"));
            element.SendKeys(password);

            // Initiate sign in
            element = driver.FindElement(By.Id("signInSubmit"));
            element.Click();
        }

        /// <summary>
        /// Initiates authentication to Amazon.com.
        /// </summary>
        void IInitiateSignIn.InitiateSignIn() =>
            SignIn(this.id, this.password, this.driver);

        /// <summary>
        /// Sets the user id for authenticating to Amazon.com.
        /// </summary>
        /// <param name="userId">
        /// The value that uniquely identifies the user.
        /// </param>
        /// <returns>
        /// Returns an object that provides a method that sets the user id for authenticating to Amazon.com.
        /// </returns>
        IProvideUserPassword IProvideUserId.SignInAs(string userId)
        {
            this.id = userId;
            return this;
        }

        /// <summary>
        /// Sets the password for authenticating to Amazon.com.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Returns an object that provides a method that initiates authentication to Amazon.com.
        /// </returns>
        IInitiateSignIn IProvideUserPassword.UsingPassword(string password)
        {
            this.password = password;
            return this;
        }
    }
}
