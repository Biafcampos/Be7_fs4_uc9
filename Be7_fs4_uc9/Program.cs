// See https://aka.ms/new-console-template for more information1
using Be7_fs4_uc9.Classes;
using Be7_fs4_uc9.Interfaces;

Console.WriteLine(@$"
===============================================================================
|                    Bem vindo ao sistema de cadastro de                      |
|                       Pessoas Físicas e Jurídicas                           |
===============================================================================
");

BarraCarregamento("Carregando",100);

List<PessoaF> listaPf = new List<PessoaF>();


string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
===============================================================================
|                    Escolha uma das opções a seguir:                         |
|_____________________________________________________________________________|
|                                                                             |
|                          1 - Pessoa Física                                  |
|                          2 - Pessoa Jurídica                                |
|                                                                             |
|                          0 - Sair                                           |
===============================================================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaF metodoPf = new PessoaF();

            string? opcaoPf;
            do
            {
                    Console.Clear();
                    Console.WriteLine(@$"
===============================================================================
|                    Escolha uma das opções a seguir:                         |
|_____________________________________________________________________________|
|                                                                             |
|                          1 - Cadastrar Pessoa Física                        |
|                          2 - Mostrar Pessoa Física                          |
|                                                                             |
|                          0 - Sair                                           |
===============================================================================
");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaF novaPf = new PessoaF();
                        Endereco novoEnd = new Endereco();
            
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();

                        
                            Console.WriteLine($"Digite o número do CPF");
                            novaPf.cpf = Console.ReadLine();
                      
                            using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                            {
                                sw.WriteLine($"{novaPf.nome}");
                                sw.WriteLine($"{novaPf.cpf}");
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"Cadastro Realizado com Sucesso!!!");
                            Console.ResetColor();
                            Thread.Sleep(3000);
                        break;
                    case "2":
                        Console.Clear();

                   
                        using (StreamReader sr = new StreamReader($"Bia.txt"))
                            {
                                string linha;
                                while((linha = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine($"{linha}");
                                }
                            }
                        Console.WriteLine($"Aperte 'Enter'para continuar...");
                        Console.ReadLine();
                        

                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção Inválida, por favor digite outra opção.");
                        Thread.Sleep(2000);
                        break;
                }
                

            } while (opcaoPf != "0");

            break;
        case "2":
            PessoaJ metodoPj = new PessoaJ();

            PessoaJ novaPj = new PessoaJ();
            Endereco novoEndPj = new Endereco();


            novaPj.nome = "NomePj";
            novaPj.cnpj = "00000000000100";
            novaPj.razaoSocial = "Razao Social Pj";
            novaPj.rendimento = 8000.5f;

            novoEndPj.logradouro = "Alameda BArao de Limeira";
            novoEndPj.numero = 539;
            novoEndPj.complemento = "Senai Informatica";
            novoEndPj.endComercial = true;

            novaPj.endereco = novoEndPj;

            metodoPj.Inserir(novaPj);

            List<PessoaJ> listaPj = metodoPj.Ler();

            foreach(PessoaJ cadaItem in listaPj)
            {
                Console.Clear();
                Console.WriteLine(@$"
                    Nome: {novaPj.nome}
                    Razao Social: {novaPj.razaoSocial}
                    CNPJ: {novaPj.cnpj}
                ");
                
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            }

            break;
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");
            
          
            BarraCarregamento("Finalizando",200);
            break;
        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(3000);
            break;
    }
} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo){
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{texto}");

    for (var contador = 0; contador < 34; contador++)
        {
        Console.Write(". ");
        Thread.Sleep(tempo);
        }
    Console.ResetColor();
}

