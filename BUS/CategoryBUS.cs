﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CategoryBUS
    {
        private static CategoryBUS instance;
        public static CategoryBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryBUS();
                return instance;
            }
        }
        public List<CategoryDTO> GetListCategory()
        {
            DataTable data;
            try
            {
                data = CategoryDAO.Instance.GetListCategory();
            }
            catch (Exception ex)
            {
                throw ex;
            }    
            List<CategoryDTO> list = new List<CategoryDTO>();
            foreach (DataRow dr in data.Rows)
            {
                CategoryDTO categoryDTO = new CategoryDTO(dr);
                list.Add(categoryDTO);
            }    
            return list;
        }
    }
}
