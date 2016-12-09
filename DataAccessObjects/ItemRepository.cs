using System;
using System.Collections.Generic;
using BusinessObjects;
using System.Data;
using Extensions;

namespace DataAccessObjects
{
    public class ItemRepository : IRepository<Item>
    {
        static readonly string connectionString = ConfigReader.GetConnectionString("ItemConnection");


        public bool DeleteData(int id)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            inputParams.Add("@ItemId", id);
            return DBAccessor.UpdateData(connectionString, "[dbo].[ItemDeleteData]",CommandType.StoredProcedure, inputParams);
        }

        public int GetItemCount()
        {
            return DBAccessor.GetScalar<int>(connectionString, "", CommandType.StoredProcedure, null);
        }

        public Item GetById(int id)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            inputParams.Add("@id", id);
            return DBAccessor.GetItem(connectionString, "[dbo].[ItemGetDataById]", CommandType.StoredProcedure, SetItem, inputParams);
        }

        public List<Item> GetDataList(string filterParm = null, string sort = null, bool isSortDirAsc = false)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(filterParm))
            {
                inputParams.Add("@filter", filterParm);

            }
            if (!string.IsNullOrEmpty(sort))
            {
                inputParams.Add("@sort", string.Format("{0}", sort));
            }
            inputParams.Add("@isSortDirAsc", isSortDirAsc);
            return DBAccessor.GetItemList(connectionString, "[dbo].[ItemGetData]", CommandType.StoredProcedure, SetItem, inputParams);
        }

        public bool InsertData(Item oneItem)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            inputParams.Add("@ItemId", oneItem.ItemID);
            inputParams.Add("@Price", oneItem.Price);
            inputParams.Add("@Description", oneItem.Description);
            return DBAccessor.UpdateData(connectionString, "[dbo].[ItemUpdateData]", CommandType.StoredProcedure, inputParams);
        }

        public bool UpdateData(Item oneItem)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            inputParams.Add("@ItemId", oneItem.ItemID);
            inputParams.Add("@Price", oneItem.Price);
            inputParams.Add("@Description", oneItem.Description);
            return DBAccessor.UpdateData(connectionString, "[dbo].[ItemUpdateData]", CommandType.StoredProcedure, inputParams);
        }

        private Item SetItem(System.Data.IDataReader reader)
        {
            if (reader == null)
            {
                return null;
            }
            Item oneItem = new Item();
            oneItem.Description = reader.GetVal<string>("Description", string.Empty);
            oneItem.Price = reader.GetVal<decimal>("Price", 0);
            //  oneItem.PriceType = reader.GetVal<string>("PriceType", string.Empty);
            oneItem.ItemID = reader.GetVal<int>("ItemID", 0);
            //  oneItem.Cost = reader.GetVal<decimal>("Cost", 0);
            return oneItem;
        }
    }
}