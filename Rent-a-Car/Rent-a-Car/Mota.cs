using System;

namespace Rent_a_Car
{
    class Mota : Veiculo
    {


        public int Cilindrada { get; set; }

        public Mota():base()
        {
            Cilindrada = 0;
        }
        public Mota(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int cilindrada) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            Cilindrada = cilindrada;
        }

        
        public Mota(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int cilindrada, DateTime disponibilidade) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado, disponibilidade)
        {
            Cilindrada = cilindrada;
        }

       

        public static Mota InserirMota()
        {
            Mota mota = new Mota();
            bool erro;
            do
            {
                erro = false;
                try
                {
                    Veiculo.InserirVeiculo(mota);
                    Console.WriteLine("Insira o numero de cilindrada:");
                    mota.Cilindrada = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n"+e.Message);
                    Console.ReadKey();
                    erro = true;
                }
            } while (erro);
            return mota;
        }
        public override string ToString()
        {
            return base.ToString() + " Cilindrada: " + Cilindrada;
        }
    }
}
