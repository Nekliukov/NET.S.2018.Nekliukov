namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface that allows to generate unique account number
    /// </summary>
    public interface IAccountNumberGenerator
    {
        /// <summary>
        /// Generates account number
        /// </summary>
        /// <returns>The number</returns>
        string Generate();
    }
}