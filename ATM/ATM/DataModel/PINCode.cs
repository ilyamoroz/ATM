namespace ATM.DataModel
{
    public class PINCode
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CardID { get; set; }
        public virtual Card card { get; set; }

    }
}