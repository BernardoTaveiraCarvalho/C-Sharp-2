using System;
namespace Rent_a_Car
{
    class Camiao : Veiculo
    {
       

        public double PesoMaximo { get; set; }
        public Camiao() : base()
        {
            PesoMaximo = 0;
        }
        public Camiao(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, double pesoMaximo) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            PesoMaximo = pesoMaximo;
        }

        public static Camiao InserirCamiao()
        {
            Camiao camiao = new Camiao();
            bool erro;
            do
            {
               erro = false;
                try
                {
                    Veiculo.InserirVeiculo(camiao);
                    Console.Write("Insira o peso máximo:");
                    camiao.PesoMaximo = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Write("\n"+e.Message);
                    Console.ReadKey();
                    Console.Clear();
                    erro = true;
                }
            } while (erro);
            return camiao;
        }
        public override string ToString()
        {
            return base.ToString() + " Peso Maximo: " + PesoMaximo;
        }
    }
}
