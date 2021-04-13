namespace ATM.DataModel
{
    public class PINCode
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public int CardID { get; set; }
        public virtual Card card { get; set; }

    }
}