namespace Models.Responses
{
    public class GenericResult
    {
        public int Id { get; set; }
        public bool IsSuccesfull { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
