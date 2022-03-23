using System;

namespace Rent_a_Car
{
    class Carro : Veiculo
    {


        public int NumeroPortas { get; set; }
        public string Caixa { get; set; }


        public Carro():base()
        {
            NumeroPortas = 0;
            Caixa = "";
        }
        public Carro(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int numeroPortas, string caixa) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            NumeroPortas = numeroPortas;
            Caixa = caixa ?? throw new ArgumentNullException(nameof(caixa));
        }
        public Carro(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int numeroPortas, string caixa,DateTime disponibilidade) :base( marca, modelo,  tipo, quantidade, cor, combustivel, preçoDia,estado, disponibilidade)
        {
            NumeroPortas = numeroPortas;
            Caixa = caixa ?? throw new ArgumentNullException(nameof(caixa));
        }

        

        public static Carro InserirCarro()
        {
            Carro carro = new Carro();
            bool erro;
            do
            {
               erro = false;
                try
                {
                    Veiculo.InserirVeiculo(carro);
                    Console.Write("Insira o numero de portas:");
                    carro.NumeroPortas = int.Parse(Console.ReadLine());
                    Console.Write("Insira a caixa:");
                    carro.Caixa = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.Write("\n"+e.Message);
                    Console.ReadKey();
                    erro = true;
                }
            } while (erro);
            return carro;
        }

        public override string ToString()
        {
            return base.ToString() + " Numero de Portas: " + NumeroPortas + " Caixa: " + Caixa;
        }

    }
}
