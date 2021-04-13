namespace ATM.Interfaces
{
    public interface IPINCodeRepository
    {
        public int GetCode(int cardID);
    }
}