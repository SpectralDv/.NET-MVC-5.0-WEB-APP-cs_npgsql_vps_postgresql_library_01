

using web_app_03.Interface;

namespace web_app_03.Models
{
    public class BookModel : IModelBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}

