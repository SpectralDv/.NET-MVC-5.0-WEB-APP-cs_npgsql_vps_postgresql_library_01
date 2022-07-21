

using Npgsql;
using System.Data;
using web_app_03.DataContext;
using web_app_03.Models;

namespace web_app_03.Interface
{

    public interface IContext
    {
        void CommandConnection(NpgsqlCommand command);
        NpgsqlCommand Select(string nameTable);
        NpgsqlCommand Find(string nameTable, string nameCol, string p1);
        NpgsqlCommand Update(string nameTable, string nameCol, string p1, int p2);
        NpgsqlCommand Update(string nameTable, string nameCol, int p1, int p2);
        NpgsqlCommand Delete(string nameTable, int p1);
        NpgsqlCommand Delete(string nameTable, string nameCol, string p1);
        void EditText(IContext bookContext, EditModel editModel);
        void EditValue(IContext bookContext, EditModel editModel);
        void Delete(IContext bookContext, EditModel editModel);
        public DataTable getDataTable();
        public bool getIsFind();
    }
    public interface IContextBook : IContext
    {
        NpgsqlCommand Insert(EditModel editModel, string p1, string p2, int p3);
    }
    public interface IContextClient : IContext
    {
        public NpgsqlCommand Insert(EditModel editModel, string p1, string p2);
    }

}
