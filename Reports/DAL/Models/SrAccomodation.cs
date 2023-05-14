using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SrAccomodation
    {
        public SrAccomodation()
        {
            SrTripAccomDetail = new HashSet<SrTripAccomDetail>();
        }

        public int AccomodationId { get; set; }
        public int? TripId { get; set; }
        public int? CityId { get; set; }
        public int? HotelId { get; set; }
        public byte? AccomodationType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }

        public virtual SrHotels Hotel { get; set; }
        public virtual SrTrips Trip { get; set; }
        public virtual ICollection<SrTripAccomDetail> SrTripAccomDetail { get; set; }
    }
}
