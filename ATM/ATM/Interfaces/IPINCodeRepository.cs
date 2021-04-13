namespace ATM.Interfaces
{
    public interface IPINCodeRepository
    {
        public string GetCode(int cardID);
    }
}