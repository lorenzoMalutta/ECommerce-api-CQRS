namespace agrolugue_api.Domain.Commands.Requests.Product
{
    public class ReadProductRequest
    {
        public int? Id {  get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
