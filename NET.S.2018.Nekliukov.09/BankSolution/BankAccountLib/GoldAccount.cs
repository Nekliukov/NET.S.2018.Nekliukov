using Core;

namespace BankAccountLib
{
    /// <summary>
    /// Gold account with inherited functionality from Base Account
    /// </summary>
    /// <seealso cref="BankAccountLib.BaseAccount" />
    public class GoldAccount : BaseAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The acc holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public GoldAccount(AccountHolder AccHolder, IAccountNumberGenerator idGenerator) : base(AccHolder, idGenerator)
        {
            Holder = AccHolder;
            idNumber = idGenerator.Generate();
            maxLimit = 1000000;
            minLimit = -1000000;
            bonusMultiplier = 50;
        }
    }
}
