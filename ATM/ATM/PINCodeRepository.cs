using System.Linq;
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
        public string GetCode(int cardID)
        {
            return _context.PINCodes.Single(x =>x.CardID.CardID == cardID).ToString();
        }
    }
}