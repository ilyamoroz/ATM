namespace ATM.DataModel
{
    public class CardCash
    {
        public int id { get; set; }
        public int Cash { get; set; }

        public int CardID { get; set; }
        public virtual Card card { get; set; }
    }
}
