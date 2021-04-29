using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATM.DataModel;
using ATM.Interfaces;

namespace ATM
{
    class ATMRepository : IATMRepository
    {
        private ATMContext _context;
        public ATMRepository(ATMContext context)
        {
            _context = context;
        }

        public string GetBalanse(int CardId)
        {
            return _context.CardCash.Single(x => x.CardID == CardId).Cash.ToString();
        }

        public int GetCardIDByNumber(string cardNumber)
        {
            return _context.Cards.Single(x => x.Number == cardNumber).CardID;

        }
        public string GetCode(int cardID)
        {
            return _context.PINCodes.Single(x => x.CardID == cardID).Code.ToString();
        }

        public void SetCardToRemote(string cardNumber)
        {
            RemoteCard card = new RemoteCard();
            card.Number = cardNumber;
            _context.RemoteCards.Add(card);
            _context.Cards.Remove(_context.Cards.Single(x => x.Number == cardNumber));
            _context.SaveChanges();
        }
    }
}
