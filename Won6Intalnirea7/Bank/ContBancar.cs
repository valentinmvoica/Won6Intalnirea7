using System;
using System.Collections.Generic;
using System.Text;

namespace Won6Intalnirea7.Bank
{
    class ContBancar
    {
        private double sold = 0.0;
        public Guid Id { get; private set; }
        public ContBancar()
        {
            this.Id = Guid.NewGuid();
        }

        public void DepunereNumerar(double sumaDepusa) { 
            if (sumaDepusa<=0)
            {
                throw new InvalidSumException($"suma depusa invalida: {sumaDepusa}");
            }
        }
        public void ExtragereNumerar(double sumaExtrasa)
        {
            if (sumaExtrasa <= 0)
            {
                throw new InvalidSumException($"suma depusa invalida: {sumaExtrasa}");
            }
            if (sold <= sumaExtrasa)
            {
                throw new InsufficientFundsException("Fonduri insuficiente");
            }

            sold -= sumaExtrasa;
        }
    }
}
