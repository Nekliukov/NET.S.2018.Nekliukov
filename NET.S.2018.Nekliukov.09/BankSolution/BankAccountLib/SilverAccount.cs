using Core;

namespace BankAccountLib
{
    /// <summary>
    /// Silver account with inherited functionality from Base Account
    /// </summary>
    /// <seealso cref="BankAccountLib.BaseAccount" />
    public class SilverAccount : BaseAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The acc holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public SilverAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator) : base(AccHolder, idGenerator)
        {
            Holder = AccHolder;
            idNumber = idGenerator.Generate();
            maxLimit = 10000;
            minLimit = -10000;
            bonusMultiplier = 6;
        }
    }
}
