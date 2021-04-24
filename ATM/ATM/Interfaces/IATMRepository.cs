namespace ATM.Interfaces
{
    public interface IATMRepository
    {
        public int GetCardIDByNumber(string cardNumber);
        public string GetCode(int cardID);
        public void SetCardToRemote(string cardNumber);
    }
}