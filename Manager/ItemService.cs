﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessObjects;

namespace Manager
{
    public class ItemService
    {
        IRepository<Item> repo;
        ItemObjectMapper mapper;

        public ItemService(IRepository<Item> repo)
        {
            this.repo = repo;
            mapper = new ItemObjectMapper();
        }

        public ItemDto GetDataByID(int id)
        {
            if (id == 0 || id < 0)
            {
                return null;
            }
            return mapper.ToTransferObject(repo.GetById(id));
        }

        //public int GetItemCount()
        //{
        //    return repo.GetItemCount();
        //}

        public List<ItemDto> GetData(string filterParam = null, string sortParam = null, bool isSortDirAsc = false)
        {

            return mapper.ToTransferObjectList(repo.GetDataList(filterParam, sortParam, isSortDirAsc));
        }

        public bool DeleteData(int id)
        {
            if (id == 0 || id < 0)
            {
                return false;
            }
            return repo.DeleteData(id);
        }

        public bool UpdateData(ItemDto dto)
        {
            if (dto == null)
            {
                return false;
            }
            return repo.UpdateData(mapper.ToBusinessObject(dto));
        }


        public bool InsertData(ItemDto dto)
        {
            if (dto == null)
            {
                return false;
            }
            return repo.InsertData(mapper.ToBusinessObject(dto));
        }
    }
}
