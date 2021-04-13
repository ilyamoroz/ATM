using System;
using System.Linq;
using System.Net.Sockets;
using ATM.DataModel;
using ATM.Interfaces;

namespace ATM
{
    public class PINCodeRepository : IPINCodeRepository
    {
        private ATMContext _context;
        public PINCodeRepository(ATMContext context)
        {
            _context = context;
        }
        public int GetCode(int cardID)
        {
            return _context.PINCodes.Single(x=>x.CardID == cardID).Code;
        }
    }
}