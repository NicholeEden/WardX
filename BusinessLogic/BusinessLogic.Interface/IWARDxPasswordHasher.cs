namespace BusinessLogic.Interface
{
    public interface IWARDxPasswordHasher
    {
        /// <summary>
        ///  Creates a hash key from a password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        string Hash(string password, int iterations);

        /// <summary>
        /// Creates a hash key from a password. Default of 10000 iterations.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string Hash(string password);

        /// <summary>
        /// Check if passwordHash is supported
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        bool IsHashSupported(string passwordHash);

        /// <summary>
        ///  Verify a password against a hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        bool Verify(string password, string passwordHash);
    }
}
