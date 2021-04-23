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
        public int GetCardIDByNumber(string cardNumber)
        {
            return _context.Cards.Single(x => x.Number == cardNumber).CardID;

        }
        public string GetCode(int cardID)
        {
            return _context.PINCodes.Single(x => x.CardID == cardID).Code.ToString();
        }
    }
}
