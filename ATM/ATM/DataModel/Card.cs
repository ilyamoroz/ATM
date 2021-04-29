using System.Collections.Generic;

namespace ATM.DataModel
{
    public class Card
    {
        public int CardID { get; set; }
        public string Number { get; set; }
        public virtual ICollection<PINCode> PINCodes { get; set; }
        public virtual ICollection<CardCash> CardCash { get; set; }
    }
}