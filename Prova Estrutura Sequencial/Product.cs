using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_Estrutura_Sequencial
{
    public class Product
    {

        public class productVO
        {
            public int Codigo { get; set; }
            public int Qtd { get; set; }
            public decimal Valor { get; set; }

            public productVO() { }
            public productVO(int cod, int qtd, decimal val)
            {
                this.Codigo = cod;
                this.Qtd = qtd;
                this.Valor = val;
            }
        }
    }
}
