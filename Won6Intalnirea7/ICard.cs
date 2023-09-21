using System;

namespace Won6Intalnirea7
{
   public interface ICard
    {
        Guid Id { get; }

        void ExtrageCard();
        void IntroduCard();
    }
}