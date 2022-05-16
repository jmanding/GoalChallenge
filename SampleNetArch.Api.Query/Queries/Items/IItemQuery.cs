namespace SampleNetArch.Api.Query.Queries.Items
{
    public interface IItemQuery 
    {
        Task<dynamic> GetAllItems();
    }
}