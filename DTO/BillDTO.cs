using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public int ID { get; set; } 
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public string Status { get; set; }
        public BillDTO(int ID, DateTime? DateCheckIn, DateTime? DateCheckOut, string Status)
        {
            this.ID = ID;
            this.DateCheckIn = DateCheckIn;
            this.DateCheckOut = DateCheckOut;
            this.Status = Status;
        }
        public BillDTO (DataRow row)
        {
            this.ID = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = row["Status"].ToString();
        }
    }
}
