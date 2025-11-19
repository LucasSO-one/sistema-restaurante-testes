using System.Net.Http;
using System;
using System.Threading.Tasks;
using Dominio;

class Program
{
    static async Task Main(string[] args)
    {
        string escolhaMenu = " ";
        HttpClient client = new HttpClient();
        ApiService servicoApi = new ApiService(client);

        do
        {
            Console.Clear();
            MostraMenu();
            escolhaMenu = Console.ReadLine();
            switch (escolhaMenu)
            {
                case "1":
                    Console.Clear();
                    await ProcuraCardapioAsync();
                    Console.ReadLine();

                    break;
                case "2":
                    do
                    {
                        MostraMenuCardapio();
                        escolhaMenu = Console.ReadLine();
                        switch (escolhaMenu)
                        {
                            case "1":

                                Console.Clear();
                                var cardapio = new Cardapio();
                                Console.WriteLine("Digite o tipo do Cardapio deseja Cadastrar:");
                                cardapio.TipoCardapio = Console.ReadLine();

                                try
                                {
                                    await servicoApi.CriarNovoCardapioAsync(cardapio);

                                }
                                catch (HttpRequestException ex)
                                {
                                    Console.WriteLine("Error:" + ex.Message);
                                }

                                Console.Clear();
                                Console.WriteLine("Deseja Adicionar algum Produto agora? (S/N)");
                                string escolha = Console.ReadLine();

                                if (escolha == "s" || escolha == "S")
                                {
                                    do
                                    {
                                        Console.WriteLine("Digite o ID do produto que deseja Adicionar: ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        try
                                        {
                                            Produto produtos = await servicoApi.ObterProdutoAsync(id);
                                            Console.WriteLine($"Deseja adiconar {produtos.Nome}?");
                                            escolha = Console.ReadLine();
                                            if (escolha == "s" || escolha == "S")
                                            {
                                                ProdutoCardapio produtoCardapio = new ProdutoCardapio()
                                                {
                                                    ProdutoID = produtos.Id,
                                                    CardapioID = cardapio.Id
                                                };
                                                cardapio.Produtos.Add(produtoCardapio);
                                                try
                                                {
                                                    await servicoApi.CriarNovoProdutoCardapioAsync(produtoCardapio);
                                                    Console.WriteLine("Produto Adicionado com Sucesso!");
                                                }
                                                catch (HttpRequestException ex)
                                                {
                                                    Console.WriteLine("Error:" + ex.Message);
                                                }
                                            }
                                        }
                                        catch (HttpRequestException ex)
                                        {
                                            Console.WriteLine("Error:" + ex.Message);
                                        }
                                        Console.WriteLine("Deseja adicionar Mais algum Produto?");
                                        escolha = Console.ReadLine();
                                    } while (escolha != "n" && escolha != "N");
                                }

                                break;
                            case "2":
                                try
                                {
                                    List<Produto> produtos = await servicoApi.ListarProdutoAsync();
                                    foreach (var produtoList in produtos)
                                    {
                                        if (produtoList.Id != 0)
                                        {
                                            Console.WriteLine($"\nID: {produtoList.Id}\nProduto: {produtoList.Nome}\nPreço: {produtoList.Preco}\n");
                                        }
                                    }
                                }
                                catch (HttpRequestException ex)
                                {
                                    Console.WriteLine("Error:" + ex.Message);
                                }

                                Console.WriteLine("Aperte Qualquer Tecla para contunuar");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.Clear();
                                var produto = new Produto();
                                Console.WriteLine("Digite o Nome do produto que deseja Cadastrar:");
                                produto.Nome = Console.ReadLine();

                                Console.Clear();
                                Console.WriteLine("Digite o Valor do produto que deseja Cadastrar:");
                                double.TryParse(Console.ReadLine(), out double Preco);
                                if (Preco != 0)
                                {
                                    produto.Preco = Preco;
                                }

                                try
                                {
                                    await servicoApi.CriarNovoProdutoAsync(produto);
                                    Console.WriteLine("Cadastrado com Sucesso");
                                    Console.ReadKey();
                                }
                                catch (HttpRequestException ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error:" + ex.Message);
                                }

                                break;
                            case "4":

                                break;
                            case "5":

                                break;
                            case "6":

                                break;
                            case "7":
                                escolhaMenu = "7";
                                break;
                        }
                    } while (escolhaMenu != "7");
                    break;
                case "3":
                    do
                    {
                        MostraMenuComanda();
                        escolhaMenu = Console.ReadLine();
                        switch (escolhaMenu)
                        {
                            case "1":
                                Console.Clear();
                                var comanda = new Comanda();
                                Console.WriteLine("Digite o nome Do cliente:");
                                comanda.ClienteNome = Console.ReadLine();

                                Console.Clear();
                                Console.WriteLine("Deseja Adicionar algum Produto na comanda agora? (S/N)");
                                string escolha = Console.ReadLine();

                                if (escolha == "s" || escolha == "S")
                                {
                                    do
                                    {
                                        Console.WriteLine("Digite o ID do produto que deseja Adicionar: ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        try
                                        {
                                            Produto produtos = await servicoApi.ObterProdutoAsync(id);
                                            Console.WriteLine($"Deseja adiconar {produtos.Nome}?");
                                            escolha = Console.ReadLine();
                                            if (escolha == "s" || escolha == "S")
                                            {
                                                ProdutoComanda produtoComanda = new ProdutoComanda
                                                {
                                                    ProdutoID = produtos.Id,
                                                    ComandaID = comanda.Id,
                                                    Produto = produtos
                                                };
                                                comanda.Produtos.Add(produtoComanda);
                                            }
                                        }
                                        catch (HttpRequestException ex)
                                        {
                                            Console.WriteLine("Error:" + ex.Message);
                                        }
                                        Console.WriteLine("Deseja adicionar Mais algum Produto?");
                                        escolha = Console.ReadLine();
                                    } while (escolha != "n" && escolha != "N");
                                }
                                try
                                {
                                    await servicoApi.CriarNovaComandaAsync(comanda);
                                    Console.WriteLine("Comanda Criada com Sucesso!");
                                }
                                catch (HttpRequestException ex)
                                {
                                    Console.WriteLine("Error:" + ex.Message);
                                }
                                break;
                            case "2":

                                break;
                            case "3":

                                break;
                            case "4":
                                escolhaMenu = "4";
                                break;
                        }
                    } while (escolhaMenu != "4");
                    break;
                case "4":
                    escolhaMenu = "CavaloAlado";
                    break;
            }
        } while (escolhaMenu != "CavaloAlado");

        void MostraMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================Menu==============================");
            Console.WriteLine("1 - Visualizar Cardápio");
            Console.WriteLine("2 - Adicionar Cardapio");
            Console.WriteLine("3 - Criar/Visualizar Comandas");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("===========================================================");
        }
        void MostraMenuCardapio()
        {
            Console.Clear();
            Console.WriteLine("=========================Cardapio==============================");
            Console.WriteLine("1 - Criar Novo Cardapio");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Adicionar Novo Produto");
            Console.WriteLine("4 - Adicionar Produto ao Cardapio");
            Console.WriteLine("5 - Remover um Produto");
            Console.WriteLine("6 - Remover um Cardapio");
            Console.WriteLine("7 - Voltar ao Menu Principal");
            Console.WriteLine("================================================================");
        }
        void MostraMenuComanda()
        {
            Console.Clear();
            Console.WriteLine("=========================Comanda==============================");
            Console.WriteLine("1 - Abrir Nova Comanda");
            Console.WriteLine("2 - Adicionar Produto à Comanda");
            Console.WriteLine("3 - Fechar Comanda");
            Console.WriteLine("4 - Voltar ao Menu Principal");
            Console.WriteLine("==============================================================");
        }
        async Task ProcuraCardapioAsync()
        {
            Console.WriteLine("Digite o ID do cardapio que deseja Visualizar: ");
            int.TryParse(Console.ReadLine(), out int id);
            try
            {
                Cardapio cardapio = await servicoApi.ObterCardapioAsync(id);
                Console.WriteLine($"\nID: {cardapio.Id}\nTipo do Cardapio: {cardapio.TipoCardapio}\nProdutos: {cardapio.Produtos}\n");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        // async void ListarCardapiosAsync()
        // {
        //     try
        //     {
        //         List<Cardapio> cardapio = await servicoApi.ListarCardapiosAsync();
        //         foreach (var card in cardapio)
        //         {
        //             Console.WriteLine($"\nID: {card.Id}\nTipo do Cardapio: {card.TipoCardapio}\nProdutos: {card.Produtos}\n");
        //         }
        //     }
        //     catch (HttpRequestException ex)
        //     {
        //         Console.WriteLine("Error:" + ex.Message);
        //     }
        // }
    }
}