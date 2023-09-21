using System;
using System.Collections.Generic;
using System.Text;

namespace Won6Intalnirea7
{
    class PoS
    {
        public void Plateste(Card card, double sumaDePlata)
        {
            
            card.IntroduCard();
            try
            {
                Bank.Bank.Instance.Plateste(card.Id, sumaDePlata);
            }
            finally
            {
                card.ExtrageCard();
            }
    }
}
