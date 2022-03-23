using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car
{
    class Reserva
    {
       

        public double Valor { get; set; }
        public DateTime Data { get; set; }

        public Reserva(double valor, DateTime data)
        {
            Valor = valor;
            Data = data;
        }
    }
}
