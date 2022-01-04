// See https://aka.ms/new-console-template for more information
using System;


namespace DIO.Series 
{
    class Program 
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
         {
           string opcaoUser = ObterOpcaoUser();
           while(opcaoUser.ToUpper() != "X")
           {
             switch(opcaoUser){
                 case "1": 
                        ListarSeries();
                        break;
                     case "2": 
                         InserirSerie();
                         break;
                     case "3": 
                        AtualizarSerie();
                         break;
                     case "4": 
                          ExcluirSerie();
                         break;
                     case "5": 
                         VisualizarSerie();
                         break;
                     case "C": 
                         Console.Clear();
                         break;
                     default: 
                         throw new ArgumentOutOfRangeException();
             }

                opcaoUser = ObterOpcaoUser();
            }

                Console.WriteLine("Obrigada por usar nossos serviços");
                Console.WriteLine();
         }


         private static void ListarSeries()
         {
             Console.WriteLine("Listar series");

             var lista = repositorio.Lista();

             if(lista.Count == 0)
             {
                 Console.WriteLine("Nenhuma Série encontrada");
                 return;
             }

             foreach(var serie in lista)
             {
                 var excluido = serie.retornaExcluido();

                 Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId()  , serie.retornaTitulo(), (excluido ? "*Excluido*": ""));
             }
         }


         private static void InserirSerie()
            {
             Console.WriteLine("Inserir nova Série ");    

             foreach(int i in Enum.GetValues(typeof(Genero)))
                  {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
                  }

                  Console.WriteLine("Escolha o Gênero");
                  int entradaGenero = int.Parse(Console.ReadLine());

                  Console.WriteLine("Digite o Título");
                  string entradaTitulo = Console.ReadLine();

                  Console.WriteLine("Digite o ano de inicio da série");
                  int entradaAno = int.Parse(Console.ReadLine());

                  Console.WriteLine("Digite a descrição da Série");
                  string entradaDescricao = Console.ReadLine();

                  Series novaSerie = new Series(id: repositorio.ProximoId(), 
                                   genero: (Genero)entradaGenero,
                                   titulo: entradaTitulo,
                                   ano: entradaAno,
                                   descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
           }


           private static void AtualizarSerie()
           {
                
                Console.Write("Digite o Id da Série ");
                int indiceSerie = int.Parse(Console.ReadLine());

                 foreach(int i in Enum.GetValues(typeof(Genero)))
                  {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
                  }

                  Console.WriteLine("Escolha o Gênero");
                  int entradaGenero = int.Parse(Console.ReadLine());

                  Console.WriteLine("Digite o Título");
                  string entradaTitulo = Console.ReadLine();

                  Console.WriteLine("Digite o ano de inicio da série");
                  int entradaAno = int.Parse(Console.ReadLine());

                  Console.WriteLine("Digite a descrição da Série");
                  string entradaDescricao = Console.ReadLine();

                  
                  Series atualizaSerie= new Series(id: indiceSerie, 
                                   genero: (Genero)entradaGenero,
                                   titulo: entradaTitulo,
                                   ano: entradaAno,
                                   descricao: entradaDescricao);

                repositorio.atualiza(indiceSerie, atualizaSerie);

           }
          private static void ExcluirSerie()
           {
                Console.Write("Digite o Id da Série ");
                int indiceSerie = int.Parse(Console.ReadLine());
                
                Console.Write("Tem certeza que desaja excluir? Digite S - sim ou  N - Não ");
                string resposta = Console.ReadLine();

                if (resposta.ToUpper() == "S") 
                  {
                    repositorio.Exclui(indiceSerie);
                  }

                 else if (resposta.ToUpper() == "N")
                 {
                    ObterOpcaoUser();
                 }


           }


           public static void VisualizarSerie()
           {
               Console.Write("Digite o Id da Série");
               int indiceSerie = int.Parse(Console.ReadLine());

               var serie = repositorio.RetornaPorId(indiceSerie);

               Console.WriteLine(serie);
           }

         private static string ObterOpcaoUser()
         {
               Console.WriteLine();
               Console.WriteLine("DIO series disponíveis");   
               Console.WriteLine("Informe a ação desejada:");  

               Console.WriteLine("1- Listar Series"); 
               Console.WriteLine("2- Inserir nova Serie");          
               Console.WriteLine("3- Atualizar Serie");
               Console.WriteLine("4- Excluir Serie");
               Console.WriteLine("5- Visualizar Serie");
               Console.WriteLine("C- Limpar Tela");
               Console.WriteLine("X- Sair");       
               Console.WriteLine();   


               string opcaoUser = Console.ReadLine().ToUpper();   
               Console.WriteLine();
               return opcaoUser;             
      }
    }
}



