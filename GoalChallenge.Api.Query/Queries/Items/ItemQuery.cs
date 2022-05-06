using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Api.Query.Queries.Items
{
    public class ItemQuery : Data.Dapper.Query, IItemQuery
    {
        public ItemQuery(IDbConnection dbConnection) : base(dbConnection) { }

        public async Task<dynamic> GetAllItems()
        {
            string query = @" Select Item.Id,
                                     Item.Name,
                                     Item.ExpirationDate,
                                     Item.Type
                                from Item ";

            return await base.ExecuteQueryAsync<dynamic>(query);
        }
    }
}
