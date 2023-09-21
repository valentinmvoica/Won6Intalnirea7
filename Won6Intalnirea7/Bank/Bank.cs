using System;
using System.Collections.Generic;
using System.Text;

namespace Won6Intalnirea7.Bank
{
    class Bank
    {
        #region singleton
        private Bank()
        {

        }
        private static Bank instance;
        public static Bank Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bank();
                }
                return instance;
            }
        }
        #endregion

        private Dictionary<Guid, ContBancar> conturi = new Dictionary<Guid, ContBancar>();
        private Dictionary<Guid, int> carduriPerCont = new Dictionary<Guid, int>();
        private Dictionary<Guid, Guid> cardToAccountMapping = new Dictionary<Guid, Guid>();
        public Guid CreeazaCont()
        {
            var cont = new ContBancar();

            conturi.Add(cont.Id, cont);
            carduriPerCont.Add(cont.Id, 0);

            return cont.Id;
        }

        public Card EmiteCard(Guid idCont)
        {
            if (!conturi.ContainsKey(idCont))
            {
                throw new InvalidIdException($"Invalid account id {idCont}");
            }

            var cont = conturi[idCont];

            if (carduriPerCont[idCont] >= 2)
            {
                throw new TooManyCardsException($"Too many cards emitted for account id {idCont}");
            }

            var card = new Card();
            carduriPerCont[idCont]++;

            cardToAccountMapping.Add(card.Id, idCont);

            return card;
        }

        public void Plateste(Guid cardId, double sumaDePlata)
        {
            if (!cardToAccountMapping.ContainsKey(cardId))
            {
                throw new InvalidIdException($"invalid card id {cardId}");
            }

            var contId = cardToAccountMapping[cardId];
            conturi[contId].ExtragereNumerar(sumaDePlata);
        }

    }
}
