using System;
namespace Rent_a_Car
{
    class Camioneta : Veiculo
    {


        public int NumeroEixos { get; set; }
        public int NumeroPassageiros { get; set; }

        public Camioneta():base()
        {
            NumeroEixos = 0;
            NumeroPassageiros = 0;
        }
        public Camioneta(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int numeroEixos, int numeroPassageiros) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            NumeroEixos = numeroEixos;
            NumeroPassageiros = numeroPassageiros;
        }
        public Camioneta(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, int numeroEixos, int numeroPassageiros, DateTime disponibilidade) : base(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            NumeroEixos = numeroEixos;
            NumeroPassageiros = numeroPassageiros;
        }

       

        public static Camioneta InserirCamioneta()
        {
            Camioneta camioneta = new Camioneta();
            bool erro;
            do
            {
                erro = false;
                try
                {
                    Veiculo.InserirVeiculo(camioneta);
                    Console.Write("Insira o numero de exios:");
                    camioneta.NumeroEixos = int.Parse(Console.ReadLine());
                    Console.Write("Insira o numero de passageiros:");
                    camioneta.NumeroPassageiros = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n"+e.Message);
                    Console.ReadKey();
                    erro = true;
                }
            } while (erro);
            return camioneta;
        }
        public override string ToString()
        {
            return base.ToString() + " Numero eixos:" + NumeroEixos + " Numero Passageiros: " + NumeroPassageiros;
        }
    }
}
