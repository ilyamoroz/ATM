using System.Linq;
using ATM.DataModel;
using ATM.Interfaces;

namespace ATM
{
    public class CardRepository : ICardRepository
    {
        private ATMContext _context;

        public CardRepository(ATMContext context)
        {
            _context = context;
        }
        public int GetCardIDByNumber(string cardNumber)
        {
            return  _context.Cards.Single(x => x.Number == cardNumber).CardID;

        }
    }
}