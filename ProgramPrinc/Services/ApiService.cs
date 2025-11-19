using Dominio;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _client;
    public ApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Produto> ObterProdutoAsync(int procura)
    {
        HttpResponseMessage response = await _client.GetAsync($"https://localhost:7049/api/Produto/{procura}");
        response.EnsureSuccessStatusCode();
        string Json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Produto>(Json);
    }
    public async Task<Cardapio> ObterCardapioAsync(int procura)
    {
        HttpResponseMessage response = await _client.GetAsync($"https://localhost:7049/api/Cardapio/{procura}");
        response.EnsureSuccessStatusCode();
        string Json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Cardapio>(Json);
    }
    public async Task<Comanda> ObterComandaAsync(int procura)
    {
        HttpResponseMessage response = await _client.GetAsync($"https://localhost:7049/api/Comanda/{procura}");
        response.EnsureSuccessStatusCode();
        string Json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Comanda>(Json);
    }
    public async Task<List<Produto>> ListarProdutoAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("https://localhost:7049/api/Produto");
        response.EnsureSuccessStatusCode();
        string Json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Produto>>(Json);
    }
    public async Task<List<Cardapio>> ListarCardapiosAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("https://localhost:7049/api/Cardapio");
        response.EnsureSuccessStatusCode();
        string Json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Cardapio>>(Json);
    }
    public async Task CriarNovoProdutoAsync(Produto produto)
    {
        string json = JsonConvert.SerializeObject(produto);
        StringContent texto = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync("https://localhost:7049/api/Produto", texto);
        response.EnsureSuccessStatusCode();
    }
    public async Task CriarNovoCardapioAsync(Cardapio cardapio)
    {
        try
        {
            string json = JsonConvert.SerializeObject(cardapio, Formatting.Indented);
            StringContent texto = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"https://localhost:7049/api/Cardapio", texto);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao enviar requisição HTTP: {ex.Message}");
        }
    }
    public async Task CriarNovaComandaAsync(Comanda comanda)
    {
        string json = JsonConvert.SerializeObject(comanda);
        StringContent texto = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync($"https://localhost:7049/api/Comanda", texto);
        response.EnsureSuccessStatusCode();
    }
    public async Task CriarNovoProdutoCardapioAsync(ProdutoCardapio produto)
    {
        string json = JsonConvert.SerializeObject(produto);
        StringContent texto = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync("https://localhost:7049/api/ProdutoCardapio", texto);
        response.EnsureSuccessStatusCode();
    }
}