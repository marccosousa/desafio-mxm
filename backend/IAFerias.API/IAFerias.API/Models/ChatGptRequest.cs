namespace IAFerias.API.Models
{
    public class ChatGptRequest
    {
        public string? Model { get; set; }
        public string? Prompt { get; set; }
        public int MaxTokens { get; set; }
        public decimal Temperature { get; set; }

        public ChatGptRequest(string lugar, int dias)
        {
            Model = "text-davinci-003";
            Prompt = $"Quero tirar férias em {lugar} durante {dias} dias. Pode preparar um roteiro para mim.";
            MaxTokens = 100;
            Temperature = 0.2m; 
        }
    }
}
