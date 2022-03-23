using System;
using System.Collections.Generic;
using System.IO;
//"https://spectreconsole.net/widgets/table"//
namespace Rent_a_Car
{
    class Empresa
    {
        static List<Veiculo> veiculos;
        static List<Reserva> reservas;
        static bool Atualizado=false;
        static DateTime DataAtual=DateTime.Now;
        //Funções
        private static void VereficarEstado()
        {
           
            if (Atualizado == false)
            {
                for (int i = 0; i < veiculos.Count; i++)
                {
                    if (veiculos[i].Estado != "Disponivel")
                    {
                        if (veiculos[i].Disponibilidade <= DataAtual)
                        {
                            veiculos[i].Estado = "Disponivel";
                            veiculos[i].Disponibilidade = DataAtual;
                        }
                    }
                }
                Atualizado = true;
            }
        }
        private static bool VereficarDisponiblidade(int id, string estado)
        {
            bool correto = false;


            if (veiculos[id].Estado == estado)
            {
                correto = true;
            }

            return correto;
        }
        private static void Listar(Type a, string estado)
        {
            Console.Clear();
            if (estado!= "") {
                Console.WriteLine("Veiculos " + estado);
            }
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (estado == "")
                {
                    Console.Write("ID: " + (i + 1) + " " + veiculos[i].ToString() + " Estado: " + veiculos[i].Estado);
                    if (veiculos[i].Estado != "Disponivel")
                    {
                        Console.Write(" Indisponivel até: " + veiculos[i].Disponibilidade.ToShortDateString());
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    
                    if ((veiculos[i].GetType() == a || a == typeof(Veiculo)) && veiculos[i].Estado == estado)
                    {
                        Console.WriteLine("ID: " + (i + 1) + " " + veiculos[i].ToString() + "\n");
                    } 
                }

            }
            Console.ReadKey();
        }
        private static void VeiculosAlugar()
        {
            switch (EscolherVeiculo())
            {
                case 1:
                    Console.WriteLine("Lista Camionetas");
                    Listar(typeof(Camioneta),"Disponivel");
                    break;
                case 2:
                    Console.WriteLine("Lista Motas");
                    Listar(typeof(Mota), "Disponivel");
                    break;
                case 3:
                    Console.WriteLine("Lista Carros");
                    Listar(typeof(Carro), "Disponivel");
                    break;
                case 4:
                    Console.WriteLine("Lista Camiaos");
                    Listar(typeof(Camiao), "Disponivel");
                    break;
            }
        }
        private static int EscolherVeiculo()
        {
            Console.Clear();
            int tipo;
            do
            {
                Console.WriteLine("Relembro que só temos 4 tipos de veiculos os quais:\n");
                Console.WriteLine("1-Camioneta\n");
                Console.WriteLine("2-Mota\n");
                Console.WriteLine("3-Carro\n");
                Console.WriteLine("4-Camiao\n");
                Console.Write("Que tipo de veiculo quer:");
                tipo = int.Parse(Console.ReadLine());
            } while (tipo < 1 || tipo > 4);
            Console.Clear();
            return tipo;
        }
        private static bool VerifData(int dia, int mes, int ano)
        {
            if (mes > 12) return false;
            if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia > 30) return false;
            if (mes == 2)
            {
                if (ano % 4 == 0)
                {
                    if (dia > 29)
                    {
                        return false;
                    }
                }
                else if (dia > 28) return false;
            }
            if (dia > 31) return false;
            return true;
        }
        public static void InserirData(ref DateTime disponibilidade)
        {
            bool erro; 
            int dia;
            int mes;
            int ano;
            do
            {
                erro = false;
                try
                {
                    do
                    {
                        do
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Escreva o  dia: ");
                                dia = int.Parse(Console.ReadLine());
                            } while (dia < 0 || dia > 31);
                            do
                            {
                                Console.WriteLine("Escreva o mes: ");
                                mes = int.Parse(Console.ReadLine());
                            } while (mes < 0 || mes > 12);
                            do
                            {
                                Console.WriteLine("Escreva o ano: ");
                                ano = int.Parse(Console.ReadLine());
                            } while (ano < DataAtual.Year);
                            if (VerifData(dia, mes, ano) == false)
                            {
                                Console.WriteLine("Escreva a data na forma correta!");
                                Console.ReadKey();
                            }
                        } while (VerifData(dia, mes, ano) == false);
                        disponibilidade = new DateTime(ano, mes, dia);
                       
                        if (disponibilidade <= DataAtual)
                        {
                            Console.WriteLine("A data tem que ser depois da data de hoje");
                            Console.ReadKey();
                        }
                    } while (disponibilidade <= DataAtual);
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(e.Message);
                }
            } while (erro == true);


            Console.ReadKey();
        }
        public static string InserirEstado(ref DateTime disponibilidade)
        {
            int opc;
            do
            {
                
                Console.WriteLine("Relembro que só temos 4 tipos de disponibilidade:\n");
                Console.WriteLine("1-Disponivel\n");
                Console.WriteLine("2-Alugado\n");
                Console.WriteLine("3-Reservado\n");
                Console.WriteLine("4-Em Manutenção:\n");
                Console.WriteLine("Que tipo de disponibilidade quer inserir:");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:

                        return "Disponivel";

                    case 2:
                        Console.WriteLine("Digite em que data vai estar disponviel:\n");
                        InserirData(ref disponibilidade);
                        return "Alugado";

                    case 3:
                        Console.WriteLine("Digite em que data vai estar disponviel:\n");
                        InserirData(ref disponibilidade);
                        return "Reservado";
                    case 4:
                        Console.WriteLine("Digite em que data vai estar disponviel:\n");
                        InserirData(ref disponibilidade);
                        return "Em Manutenção";
                }
            } while (opc < 1 || opc > 4);
            return "0";
        }
        private static void InicializarVeiculos() //Inicializa lista de Veiculos
        {
            veiculos = new List<Veiculo>();
            reservas = new List<Reserva>();
            veiculos.Add(new Carro("Audi", "A1", "Carro", 1, "Cinza", "Gasóleo", 20, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Audi", "A1", "Carro", 1, "Preto", "Gasóleo", 20, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Audi", "A1", "Carro", 1, "Branco", "Gasóleo", 20, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("BMW", "Serie1", "Carro", 1, "Cinza", "Gasóleo", 22, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("BMW", "Serie1", "Carro", 1, "Preto", "Gasóleo", 22, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("BMW", "Serie2", "Carro", 1, "Cinza", "Gasóleo", 24, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("BMW", "Serie1", "Carro", 1, "Preto", "Gasóleo", 24, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Mazda", "CX-3", "Carro", 2, "Vermelho", "Gasóleo", 18, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Mazda", "CX-3", "Carro", 2, "Azul", "Gasóleo", 18, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Mazda", "CX-5", "Carro", 2, "Vermelho", "Gasóleo", 20, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Mazda", "CX-3", "Carro", 1, "Azul", "Gasóleo", 20, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Porche", "911", "Carro", 1, "Cinza", "Gasolina", 40, "Disponivel", 3, "Automática"));
            veiculos.Add(new Carro("Renault", "Clio", "Carro", 2, "Branco", "Gasóleo", 12, "Disponivel", 3, "Manual"));
            veiculos.Add(new Carro("Renault", "Clio", "Carro", 2, "Preto", "Gasolina", 10, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Renault", "Megane", "Carro", 1, "Vermelho", "Gasóleo", 16, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Renault", "Megane", "Carro", 1, "Azul", "Gasóleo", 16, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Renault", "Megane", "Carro", 1, "Preto", "Gasóleo", 16, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Renault", "Megane", "Carro", 1, "Cinza", "Gasóleo", 16, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Renault", "Zoe", "Carro", 3, "Branco", "Elétrico", 25, "Disponivel", 5, "Automática"));
            veiculos.Add(new Carro("Toyota", "CH-R", "Carro", 1, "Preto", "Híbrido", 27, "Disponivel", 5, "Automática"));
            veiculos.Add(new Carro("Toyota", "CH-R", "Carro", 1, "Cinza", "Híbrido", 27, "Disponivel", 5, "Automática"));
            veiculos.Add(new Carro("Toyota", "Prius", "Carro", 2, "Vermelho", "Híbrido", 25, "Disponivel", 5, "Automática"));
            veiculos.Add(new Carro("Toyota", "Prius", "Carro", 1, "Azul", "Híbrido", 25, "Disponivel", 5, "Automática"));
            veiculos.Add(new Carro("Toyota", "Corolla", "Carro", 1, "Preto", "Gasolina", 15, "Disponivel", 5, "Manual"));
            veiculos.Add(new Carro("Seat", "Leon", "Carro", 2, "Preto", "Gasóleo", 17, "Disponivel", 3, "Manual"));
            veiculos.Add(new Mota("Honda", "CBR", "Mota", 2, "Amarelo", "Gasolina", 10, "Disponivel", 125));
            veiculos.Add(new Mota("Kawasaki", "ZXR", "Mota", 2, "Vermelho", "Gasolina", 10, "Disponivel", 300));
            veiculos.Add(new Camioneta("Irizar", "PB", "Camioneta", 1, "Preto", "Gasóleo", 100, "Disponivel", 3, 150));
            veiculos.Add(new Camiao("MAN", "", "Camião", 1, "Preto", "Gasóleo", 120, "Disponivel", 2000));
            veiculos.Add(new Camiao("Mercedes", "", "Camião", 1, "Preto", "Gasóleo", 180, "Disponivel", 2500));
            veiculos.Add(new Camiao("Scania", "", "Camião", 1, "Preto", "Gasóleo", 160, "Disponivel", 1750));
        }
        private static void InserirVeiculos() //Inserção de Veiculos
        {

            switch (EscolherVeiculo())
            {
                case 1:
                    Console.WriteLine("Inserir Camioneta");
                    veiculos.Add(Camioneta.InserirCamioneta());
                    break;
                case 2:
                    Console.WriteLine("Inserir Mota");
                    veiculos.Add(Mota.InserirMota());
                    break;
                case 3:
                    Console.WriteLine("Inserir Carro");
                    veiculos.Add(Carro.InserirCarro());
                    break;
                case 4:
                    Console.WriteLine("Inserir Camiao");
                    veiculos.Add(Camiao.InserirCamiao());
                    break;
            }
        }
        private static void AlterarEstado()
        {
            
            Listar(typeof(Veiculo),"");
            int id;
            do
            {
                Console.WriteLine("Indique o id do  veiculo que vai ser mudado?");
                id = int.Parse(Console.ReadLine());
            } while (id < 0 || id > veiculos.Count);
            Console.WriteLine("Agora vai mudar o estado do veiculo");
            DateTime disponibilidade = DataAtual;
            veiculos[id - 1].Estado = InserirEstado(ref disponibilidade);
            veiculos[id - 1].Disponibilidade = disponibilidade;
        }
        private static void AdicionarReserva(double valor)
        {
            bool existe = false;
          
            if (reservas.Count != 0) { 
            for (int i = 0; i < reservas.Count; i++)
                {
                if (reservas[i].Data == DataAtual)
                    {
                  
                        existe = true;
                        reservas[i].Valor += valor;
                    }
            }
            }
            if (existe == false)
            {
                reservas.Add(new Reserva (valor, DataAtual));
            }
        }
        private static void CalcularPreco()
        {
            Listar(typeof(Veiculo),"");
            Console.WriteLine("Reserva");
            Console.Write("Indique o id do veiculo: ");
            int id=int.Parse(Console.ReadLine());
            Console.Write("Digite a data de inicio: ");
        }
        private static void ReservarVeiculo()
        {
            
            int id;
            do
            {
                Listar(typeof(Veiculo),"");
                Console.WriteLine("Indique o id do  veiculo que vai ser reservado:");
                id = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (VereficarDisponiblidade(id-1, "Disponivel")==false|| (id<0 ||id>veiculos.Count));
            Console.WriteLine("Agora vai inserir a data em que vai alugar:");
            Console.ReadKey();
            DateTime disponibilidade = DataAtual;
            InserirData(ref disponibilidade);
            Console.WriteLine("Agora vai inserir a data em que vai  deixar o carro:");
            Console.ReadKey();
            DateTime disponibilidade2 = DataAtual;
            do
            {
                InserirData(ref disponibilidade2);
                if(disponibilidade2 <= disponibilidade)
                {
                    Console.WriteLine("Não pode por uma data anterior ou igual a data que vai alugar");
                    Console.ReadKey();
                }
            } while (disponibilidade2 <= disponibilidade);
            double valor = (disponibilidade2 - disponibilidade).Days * veiculos[id].PreçoDia;
            Console.WriteLine("Para reservar o veiculo desta data: "+disponibilidade.ToShortDateString() + " até esta data: " + disponibilidade2.ToShortDateString());
            Console.WriteLine("Como o valor por dia é: "+veiculos[id].PreçoDia+"\nO valor que vai pagar é: " + valor);
            int op;
            do
            {
                Console.WriteLine("Vai quer reservar (1 Sim 0 Não) : ");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 1);
            if (op == 1)
            {
                AdicionarReserva(valor);
                veiculos[id].Estado = "Reservado";
                veiculos[id].Disponibilidade = disponibilidade2;
                Console.WriteLine("Reserva feita com sucesso");
                Console.ReadKey();
            }
        }
        private static void TabelaVeiculo(StreamWriter wr,int tipo)
        {
            wr.WriteLine("<tr>");
            wr.WriteLine("<th> Marca</th>");
            wr.WriteLine("<th>Modelo</th>");
            wr.WriteLine("<th>Quantidade</th>");
            wr.WriteLine("<th>Cor</th>");
            wr.WriteLine("<th>Combustivel</th>");
            wr.WriteLine("<th>PreçoDia</th>");
            wr.WriteLine("<th>Estado</th>");
            wr.WriteLine("<th>Disponibilidade</th>");
            switch (tipo)
            {
                case 1:
                    wr.WriteLine("<th>PesoMaximo</th>");
                    break;
                case 2:
                    wr.WriteLine("<th>NumeroEixos</th>");
                    wr.WriteLine("<th>NumeroPassageiros</th>");
                    break;
                case 3:
                    wr.WriteLine("<th>NumeroPortas</th>");
                    wr.WriteLine("<th>Caixa</th>");
                    break; 
                case 4:
                    wr.WriteLine("<th>Cilindrada</th>");
                    break;
            }
            wr.WriteLine("</tr>");
        }
        private static void RowVeiculo(StreamWriter wr, int tipo,int i)
        {
            wr.WriteLine("<tr>");
            wr.WriteLine("<td>"+veiculos[i].Marca +"</td>");
            wr.WriteLine("<td>" + veiculos[i].Modelo + "</td>");
            wr.WriteLine("<td>" + veiculos[i].Quantidade + "</td>");
            wr.WriteLine("<td>" + veiculos[i].Cor + "</td>");
            wr.WriteLine("<td>" + veiculos[i].Combustivel + "</td>");
            wr.WriteLine("<td>" + veiculos[i].PreçoDia + "</td>");
            wr.WriteLine("<td>" + veiculos[i].Estado + "</td>");
            wr.WriteLine("<td>" + veiculos[i].Disponibilidade.ToShortDateString() + "</td>");
            switch (tipo)
            {
                case 1:
                    wr.WriteLine("<td>" + ((Camiao) veiculos[i]).PesoMaximo + "</td>");
                    break;
                case 2:
                    wr.WriteLine("<td>" + ((Camioneta)veiculos[i]).NumeroEixos + "</td>");
                    wr.WriteLine("<td>" + ((Camioneta)veiculos[i]).NumeroPassageiros + "</td>");
                    break;
                case 3:
                    wr.WriteLine("<td>" + ((Carro)veiculos[i]).NumeroPortas + "</td>");
                    wr.WriteLine("<td>" + ((Carro)veiculos[i]).Caixa + "</td>");
                    break;
                case 4:
                    wr.WriteLine("<td>" + ((Mota)veiculos[i]).Cilindrada + "</td>");
                    break;
            }
            wr.WriteLine("</tr>");
        }
        private static void ExportarHtml()
        {
//            <table>
//  <tr>
//    <th>Company</th>
//    <th>Contact</th>
//    <th>Country</th>
//  </tr>
//  <tr>
//    <td>Alfreds Futterkiste</td>
//    <td>Maria Anders</td>
//    <td>Germany</td>
//  </tr>
//  <tr>
//    <td>Centro comercial Moctezuma</td>
//    <td>Francisco Chang</td>
//    <td>Mexico</td>
//  </tr>
//</table>
            StreamWriter wr = new StreamWriter(@"veiculos.html");
            wr.WriteLine("<h1>Camiao</h1>");
            wr.WriteLine("<table>");
            
            TabelaVeiculo(wr,1);
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (veiculos[i].GetType() == typeof(Camiao))
                {
                    RowVeiculo(wr, 1, i);
                }
            }
            wr.WriteLine("</table>");
            wr.WriteLine("<h1>Camioneta</h1>");
            wr.WriteLine("<table>");
            TabelaVeiculo(wr, 2);
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (veiculos[i].GetType() == typeof(Camioneta))
                {
                    RowVeiculo(wr, 2, i);
                }
            }
            wr.WriteLine("</table>");
            wr.WriteLine("<table>");
            wr.WriteLine("<h1>Carro</h1>");
            TabelaVeiculo(wr, 3);
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (veiculos[i].GetType() == typeof(Carro))
                {
                    RowVeiculo(wr, 3, i);
                }
            }
            wr.WriteLine("</table>");
            wr.WriteLine("<table>");
            wr.WriteLine("<h1>Mota</h1>");
            TabelaVeiculo(wr, 4);
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (veiculos[i].GetType() == typeof(Mota))
                {
                    RowVeiculo(wr, 4, i);
                }
            }
            wr.WriteLine("</table>");
            wr.Close();
        }
        private static void AvançarDia()
        {
            Random rand = new Random();
            int number;
            int id;
            double dia;
            bool erro;
            do
            {
                erro = false;
                try
                {
                    Console.WriteLine("Quantos dias quer avançar: ");
                    dia = double.Parse(Console.ReadLine());
                   DataAtual=  DataAtual.AddDays(dia);
                    Atualizado = false;
                    for(int i = 0; i < dia; i++)
                    {
                       number = rand.Next(0, 10);
                        id = rand.Next(0, veiculos.Count+1);
                        if (number > 6 && veiculos[id].Estado=="Disponivel")
                        {
                            veiculos[id].Estado = "Em Manutenção";
                            veiculos[id].Disponibilidade = DataAtual.AddMonths(1);
                            Console.WriteLine("O veiculo com o id " + (id +1) + " sofreu um acidente");
                            Console.ReadKey();
                        }

                    }                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    erro = true;
                }
            } while (erro == true);
        }
        public static void InserirDataFuturo(ref DateTime disponibilidade)
        {
            bool erro;
            int dia;
            int mes;
            int ano;
            do
            {
                erro = false;
                try
                {
                    
                        do
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Escreva o  dia: ");
                                dia = int.Parse(Console.ReadLine());
                            } while (dia < 0 || dia > 31);
                            do
                            {
                                Console.WriteLine("Escreva o mes: ");
                                mes = int.Parse(Console.ReadLine());
                            } while (mes < 0 || mes > 12);
                            do
                            {
                                Console.WriteLine("Escreva o ano: ");
                                ano = int.Parse(Console.ReadLine());
                            } while (ano < DataAtual.Year);
                            if (VerifData(dia, mes, ano) == false)
                            {
                                Console.WriteLine("Escreva a data na forma correta!");
                                Console.ReadKey();
                            }
                        } while (VerifData(dia, mes, ano) == false);
                        disponibilidade = new DateTime(ano, mes, dia);
     
                }
                catch (Exception e)
                {
                    erro = true;
                    Console.WriteLine(e.Message);
                }
            } while (erro == true);

        }
        private static void CalcularLucro()
        {
            DateTime disponibilidade = DateTime.Now;
            double valortotal=0;
            Console.WriteLine("Agora vai inserir a data em que vai começar:");
            Console.ReadKey();
            InserirDataFuturo(ref disponibilidade);
            Console.WriteLine("Agora vai inserir a data em que vai  acabar:");
            Console.ReadKey();
            DateTime disponibilidade2 = DataAtual;
            do
            {
                InserirDataFuturo(ref disponibilidade2);
                if (disponibilidade2 < disponibilidade)
                {
                    Console.WriteLine("Não pode por uma data anterior  a data que vai começar");
                    Console.ReadKey();
                }
            } while (disponibilidade2 < disponibilidade);
           for(int i = 0; i < reservas.Count; i++)
            {
                if (reservas[i].Data  >= disponibilidade && reservas[i].Data <= disponibilidade2)
                {
                   Console.WriteLine("Total ganho no dia " + reservas[i].Data.ToShortDateString() + ": " + reservas[i].Valor);
                   valortotal += reservas[i].Valor;
                     
                }
             }
                    Console.WriteLine("Total ganho nestas datas: " + valortotal);
                    Console.ReadKey();
                    return;
                }
        private static void MenuEmpresa() //Menu
        {
            
            int op;
            bool erro;
            InicializarVeiculos();
            do
            {
                erro = false;
                try
                {
                    
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Data atual: " + DataAtual.ToShortDateString());
                        Console.WriteLine("1--Inserir Veiculo");
                        Console.WriteLine("2--Alterar Estado Veiculo");
                        Console.WriteLine("3--Ver veiculos para alugar");
                        Console.WriteLine("4--Listar veiculos em manutenção");
                        Console.WriteLine("5--Reservar Veiculo");
                        Console.WriteLine("6--Exportar para html");
                        Console.WriteLine("7--Avançar  dia");
                        Console.WriteLine("8--Calcular lucro");
                        Console.WriteLine("0--Sair");
                        Console.Write("Insira:");
                        op = int.Parse(Console.ReadLine());
                        switch (op)
                        {
                            case 1:
                                Console.Clear();
                                
                                InserirVeiculos();
                                break;
                            case 2:
                                VereficarEstado();
                                AlterarEstado();
                                break;
                            case 3:
                                VereficarEstado();
                                VeiculosAlugar();
                                break;
                            case 4:
                                VereficarEstado();
                                Listar(typeof(Veiculo), "Em Manutenção");
                                break;
                            case 5:
                                VereficarEstado();
                                ReservarVeiculo();
                                break;
                            case 6:
                                VereficarEstado();
                                ExportarHtml();
                                Console.WriteLine("Exportado com sucesso");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 7:
                                AvançarDia();
                                break;
                            case 8:
                                CalcularLucro();
                                break;
                        }
                    } while (op != 0);
                }
                
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message);
                    Console.ReadKey();
                    erro = true;
                }
            }while(erro);
        }
        public static void IniciarEmpresa()
        {

            DateTime data = DateTime.Now;
            Console.WriteLine("Insira a data desta simulação não pode ser a data de hoje");
            InserirData(ref data);
            DataAtual = data;
            MenuEmpresa();
        }
    }
}
