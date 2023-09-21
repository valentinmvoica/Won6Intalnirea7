using System;

namespace Won6Intalnirea7.Bank
{
    interface IBankInstitution
    {
        void Plateste(Guid cardId, double sumaDePlata);
    }
}