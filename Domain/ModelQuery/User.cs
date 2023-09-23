using Microsoft.AspNetCore.Identity;

namespace agrolugue_api.Domain.ModelsQuery
{
    public class User : IdentityUser
    {
        public DateTime DateTime { get; set; }
        public virtual ICollection<Product> OwnedProducts { get; set; } = new List<Product>();
        public virtual ICollection<Rent> RentedProducts { get; set; } = new List<Rent>();
    }
}
