using agrolugue_api.Domain.Model;

namespace agrolugue_api.Domain.Commands.Responses.Products
{
    public class CreateProductResponse
    {
        public int Id { get; set; } 
        public string OwnerId { get; set; }
    }
}
