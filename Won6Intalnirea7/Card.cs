using System;
using System.Collections.Generic;
using System.Text;

namespace Won6Intalnirea7
{
    class Card : ICard
    {
        public Guid Id { get; private set; }
        public Card()
        {
            this.Id = Guid.NewGuid();
        }
        public void IntroduCard()
        {
            Console.WriteLine("Cardul a fost introdus");
        }
        public void ExtrageCard()
        {
            Console.WriteLine("Cardul a fost extras");
        }
    }
}
