public class AccountAmount
{
    public readonly bool Success;
    public readonly double Amount;

    public AccountAmount(bool success, double amount)
    {
        Success = success;
        Amount = amount;
    }
}
