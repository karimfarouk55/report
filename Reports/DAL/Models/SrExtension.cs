using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SrExtension
    {
        public int ExtensionId { get; set; }
        public int? TripId { get; set; }
        public int? CityId { get; set; }
        public int? HotelId { get; set; }
        public byte? Number { get; set; }
        public decimal? Price { get; set; }

        public virtual MsgaCity City { get; set; }
        public virtual SrHotels Hotel { get; set; }
        public virtual SrTrips Trip { get; set; }
    }
}
