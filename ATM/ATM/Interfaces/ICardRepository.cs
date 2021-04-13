namespace ATM.Interfaces
{
    public interface ICardRepository
    {
        public int GetCardIDByNumber(string cardNumber);

    }
}