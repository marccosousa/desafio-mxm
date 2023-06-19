namespace IAFerias.API.Models
{
    public class ChatGptRequest
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }

        public ChatGptRequest(Ferias ferias)
        {
            model = "text-davinci-003";
            prompt = $"Quero passar minhas férias em {ferias.Lugar} durante {ferias.Dias} dias. Prepare um roteiro com apenas um passeio por dia. Nada além.";
            max_tokens = 500;
            temperature = 0.2m; 
        }
    }
}
