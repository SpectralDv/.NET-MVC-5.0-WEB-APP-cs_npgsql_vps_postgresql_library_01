


using Npgsql;

namespace web_app_03.Interface
{

    public interface IId
    {
        int Id { get; set; }
    }
    public interface IName 
    {
        string Name { get; set; }
    }
    public interface IDescription
    {
        string Description { get; set; }
    }
    public interface IStatus
    {
        int Status { get; set; }
    }
    public interface ILogin
    {
        string Login { get; set; }
    }
    //////////////////////////////////////////////////////
    public interface IModel 
    {

    }
    public interface IModelBook : IModel, IId, IName, IDescription, IStatus
    {

    }
    public interface IModelClient : IModel, IId, ILogin
    {

    }
    ////////////////////////////////////////////////////////
    public interface IModelEdit : IModel
    {

    }
}