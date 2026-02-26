namespace FinCRM.Domain
{
    public class ClientAddress
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;

        public AddressType AddressType { get; set; }
    }

    public enum AddressType
    {
        Home,
        Work
    }
}
