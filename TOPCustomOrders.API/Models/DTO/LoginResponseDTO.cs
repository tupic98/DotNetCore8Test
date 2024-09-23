namespace TOPCustomOrders.API.Models.DTO
{
    public class LoginResponseDTO
    {
        public string token {  get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
