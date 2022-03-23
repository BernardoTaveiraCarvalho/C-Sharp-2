using System;

namespace Rent_a_Car
{
    class Veiculo
    {


        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public double PreçoDia { get; set; }
        public string Estado { get; set; }
        public DateTime Disponibilidade { get; set; }
        public Veiculo()
        {
            Marca = "";
            Modelo = "";
            Tipo = "";
            Quantidade = 0;
            Cor = "";
            Combustivel = "";
            PreçoDia = 0;
            Estado = "";
        }
        public Veiculo(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado)
        {
            Marca = marca ?? throw new ArgumentNullException(nameof(marca));
            Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            Quantidade = quantidade;
            Cor = cor ?? throw new ArgumentNullException(nameof(cor));
            Combustivel = combustivel ?? throw new ArgumentNullException(nameof(combustivel));
            PreçoDia = preçoDia;
            Estado = estado ?? throw new ArgumentNullException(nameof(estado));
        }
        public Veiculo(string marca, string modelo, string tipo, int quantidade, string cor, string combustivel, double preçoDia, string estado, DateTime disponibilidade) : this(marca, modelo, tipo, quantidade, cor, combustivel, preçoDia, estado)
        {
            Disponibilidade = disponibilidade;
        }
        public static void InserirVeiculo(Veiculo veiculo)
        {
            bool erro;
            do
            {
                Console.Clear();
                erro = false;
                try
                {
                    Console.Write("Insira a Marca: ");
                    veiculo.Marca = Console.ReadLine();
                    Console.Write("Insira o Modelo:");
                    veiculo.Modelo = Console.ReadLine();
                    string[] vet = veiculo.GetType().ToString().Split('.');
                    veiculo.Tipo =  vet[1];
                    do
                    {
                        Console.Write("Insira a quantidade:");
                        veiculo.Quantidade = int.Parse(Console.ReadLine());
                    } while (veiculo.Quantidade < 1);
                    Console.Write("Insira a cor:");
                    veiculo.Cor = Console.ReadLine();
                    Console.Write("Insira o Combustivel:");
                    veiculo.Combustivel = Console.ReadLine();
                    Console.Write("Insira o Preço por dia:");
                    veiculo.PreçoDia = double.Parse(Console.ReadLine());
                    DateTime Disponibiliade = DateTime.Now;
                    Console.ReadKey();
                    veiculo.Estado = Empresa.InserirEstado(ref Disponibiliade);
                    Console.ReadKey();
                    veiculo.Disponibilidade = Disponibiliade;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n"+e.Message);
                    Console.ReadKey();
                    erro = true;
                }
            } while (erro);
            
        }
        public override string ToString()
        {
            return "Marca: " + Marca + " Modelo: " + Modelo + " Tipo: " + Tipo + " Quantidade: " + Quantidade + " Cor: " + Cor + " Combustivel: " + Combustivel + " Preço por dia: " + PreçoDia;
        }
    }
}
