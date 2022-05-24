using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class StaffBUS
    {
        private static StaffBUS instance;
        public static StaffBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new StaffBUS();
                return instance;
            }
        }
        public List<StaffDTO> GetAllStaff()
        {
            DataTable data;
            try
            {
                data = StaffDAO.Instance.GetAllStaff();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<StaffDTO> list = new List<StaffDTO>();
            foreach (DataRow dr in data.Rows)
            {
                StaffDTO st = new StaffDTO(dr);
                list.Add(st);
            }
            return list;
        }
        public List<StaffDTO> GetStaffByName(string name)
        {
            List<StaffDTO> li = new List<StaffDTO>();
            foreach (StaffDTO i in GetAllStaff())

            {
                if (i.Name.Contains(name))
                {
                    li.Add(i);
                }
            }
            return li;
        }
        public bool Check(int id)
        {
            bool isAdded = true;
            foreach (StaffDTO i in GetAllStaff())
            {
                if (id == i.ID)
                {
                    isAdded = false;
                }
            }
            return isAdded;
        }
        public void AddUpdateStaff(StaffDTO staff)
        {
            if (Check(staff.ID))
            {

                StaffDAO.Instance.AddStaffDAO(staff);
            }
            else
            {
               StaffDAO.Instance.updateStaffDAO(staff);
            }
        }
        public void DeleteStaff(int StafftoDelete)
        {
            try
            {
                StaffDAO.Instance.DeleteStaffDAO(StafftoDelete);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
