


using web_app_03.Interface;

namespace web_app_03.Models
{
    public class EditModel : IModelEdit
    {
        public string NameTable { get; set; }
        public string FindCol { get; set; }
        public string NameCol1 { get; set; }
        public string NameCol2 { get; set; }
        public string NameCol3 { get; set; }
        public string FindText { get; set; }
        public int FindValue { get; set; }
        public string EditText { get; set; }
        public int EditValue { get; set; }
    }
}
