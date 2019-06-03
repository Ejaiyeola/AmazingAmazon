namespace AmazingAmazon.Tests
{
    /// <summary>
    /// Interface that provides a method that sets the password for authenticating to a service.
    /// </summary>
    public interface IProvideUserPassword
    {
        /// <summary>
        /// Sets the password for authenticating to a service.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Returns an object that provides a method that initiates authentication to a service.
        /// </returns>
        IInitiateSignIn UsingPassword(string password);
    }
}
