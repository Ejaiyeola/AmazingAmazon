namespace AmazingAmazon.AutomationFramework
{
    /// <summary>
    /// Interface that provides a method that sets the user id for authenticating to a service.
    /// </summary>
    public interface IProvideUserId
    {
        /// <summary>
        /// Sets the user id for authenticating to a service.
        /// </summary>
        /// <param name="userId">
        /// The value that uniquely identifies the user.
        /// </param>
        /// <returns>
        /// Returns an object that provides a method that sets the user id for authenticating to a service.
        /// </returns>
        IProvideUserPassword SignInAs(string userId);

        bool IsSignedIn { get; }
    }
}
