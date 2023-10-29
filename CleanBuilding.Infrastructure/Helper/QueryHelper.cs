using CleanBuilding.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Infrastructure.Helper
{
    public class QueryHelper
    {
        public static string GetQuery(
            int? buidlingID,
            int? objectID,
            int? dataFieldID,
            DateTime startTime,
            DateTime endTime)
        {
            string searchCondition = string.Empty;
            if (buidlingID.HasValue)
                searchCondition = string.Format(@"{0} BuildingId = {1} AND", searchCondition, buidlingID.Value);

            if(objectID.HasValue)
                searchCondition = string.Format(@"{0} ObjectId = {1} AND", searchCondition, objectID.Value);
            
            if(dataFieldID.HasValue)
                searchCondition = string.Format(@"{0} DataFieldId = {1} AND", searchCondition, dataFieldID.Value);

            searchCondition = string.Format($@"{searchCondition} Timestamp BETWEEN '{startTime}' AND '{endTime}'");

            return $@"
                SELECT
                  [Value]
                  ,[Timestamp]
                FROM [dbo].[Reading]
                WHERE {searchCondition}";
        }

        public static string GetQueryBuilding()
        {

            return $@"
                SELECT
                   [Id]
                  ,[Name]
                  ,[Location]
                FROM [dbo].[Building]";
        }

        public static string GetQueryObject()
        {

            return $@"
                SELECT
                   [Id]
                  ,[Name]
                FROM [dbo].[Object]";
        }

        public static string GetQueryDataField()
        {

            return $@"
                SELECT
                   [Id]
                  ,[Name]
                FROM [dbo].[DataField]";
        }
    }
}
