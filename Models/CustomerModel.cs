namespace DoAnTKPMNC.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public AccountModel Account { get; set; }
    }
}
