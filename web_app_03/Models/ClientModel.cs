

using web_app_03.Interface;

namespace web_app_03.Models
{
    public class ClientModel : IModelClient
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }
}

