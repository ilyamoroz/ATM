using System.ComponentModel.DataAnnotations;

namespace ATM.DataModel
{
    public class RemoteCard
    {
        [Key]
        public int CardID { get; set; }
        public string Number { get; set; }
    }
}