using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
  public  class StoreDTO
    {
        //public int userid { get; set; }
        public string storid { get; set; }
        public string namestore { get; set; }
        public List<Storessss> store { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
    public class Storessss
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
