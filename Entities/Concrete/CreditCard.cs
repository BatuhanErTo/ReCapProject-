using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Cvc { get; set; }
        public string CardHolderFullName { get; set; }
        public decimal Balance { get; set; }
    }
}
