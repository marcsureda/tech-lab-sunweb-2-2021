using System;
using System.Collections.Generic;
using Sundio.Enumerations;
using Sundio.Packages.Models;

namespace WebApplication2.Models
{
    public class PackageModelExtended
    {
        /// <summary>
        ///     Gets or sets the total price. If there are booking related cost, Total include them.
        /// </summary>
        public PriceModel TotalPrice { get; set; }
        /// <summary>Gets or sets the average price.</summary>
        public PriceModel AveragePrice { get; set; }
        /// <summary>Gets or sets the original price per person.</summary>
        public PriceModel OriginalPricePerPerson { get; set; }
        /// <summary>Gets or sets the public price per person.</summary>
        public PriceModel PublicPricePerPerson { get; set; }
        /// <summary>
        ///     Gets or sets the ski pass public price per person.
        /// </summary>
        public PriceModel SkiPassPublicPricePerPerson { get; set; }
        /// <summary>Gets or sets the discounts</summary>
        public PriceModel Discount { get; set; }
        /// <summary>
        ///     The discounts applicable to each of the participants
        /// </summary>
        [Obsolete("Discounts per person deprecated and not used anymore. Use \'DiscountsInfo\' to get discounts information")]
        public IEnumerable<ParticipantDiscountsModel> DiscountsPerPerson { get; set; }
        /// <summary>Gets or sets the on request property.</summary>
        public bool OnRequest { get; set; }
        /// <summary>Gets or sets the discount percentage.</summary>
        public int DiscountPercentage { get; set; }
        /// <summary>Gets or sets the SunwebCE discount percentage.</summary>
        [Obsolete("The CE discount can be found at DiscountsInfo property, look for discount type SunwebCe")]
        public PriceModel SunwebCeDiscount { get; set; }
        /// <summary>Gets or sets the departure date.</summary>
        /// <value>The departure date.</value>
        public DateTime? DepartureDate { get; set; }
        /// <summary>Gets or sets if it has some flight.</summary>
        [Obsolete("Obsolete since MN-227, please use TransportType")]
        public bool HasFlight { get; set; }
        /// <summary>Gets or sets if it has an accommodation.</summary>
        public bool HasAccommodation { get; set; }
        /// <summary>Gets or sets if it has some transfer.</summary>
        public bool HasTransfer { get; set; }
        /// <summary>Gets or sets if it has ski pass.</summary>
        public bool HasSkiPass { get; set; }
        /// <summary>Gets or sets if it has car rental.</summary>
        public bool HasCarRental { get; set; }
        /// <summary>Gets or sets the duration (in days).</summary>
        public int Duration { get; set; }
        /// <summary>Gets or sets the accommodation identifier.</summary>
        public int AccommodationId { get; set; }
        /// <summary>Gets or sets the mealplan.</summary>
        public MealplanModel Mealplan { get; set; }
        /// <summary>Gets or sets the flight information.</summary>
        public FlightInfoModel FlightInfo { get; set; }
        /// <summary>Gets or sets the bus information.</summary>
        public BusInfoModel BusInfo { get; set; }
        /// <summary>Gets or sets the rooms.</summary>
        public IEnumerable<RoomInfoModel> Rooms { get; set; }
        /// <summary>
        ///     Gets or sets the booking related costs information.
        /// </summary>
        public BookingRelatedCostsInfoModel BookingRelatedCostsInfo { get; set; }
        /// <summary>
        ///     The number of available packages
        ///     with the selected room combination.
        /// </summary>
        public int? Stock { get; set; }
        /// <summary>Gets or sets the type of the transport.</summary>
        public TransportType TransportType { get; set; }
        /// <summary>Gets or sets the Discounts property.</summary>
        public IEnumerable<string> Discounts { get; set; }
        /// <summary>Gets or sets the campaign name.</summary>
        public string CampaignName { get; set; }
        /// <summary>Gets or sets the campaign code.</summary>
        public string CampaignCode { get; set; }
        /// <summary>
        ///     Gets or sets the list of services included in the price.
        /// </summary>
        [Obsolete("Use property \'ExtraServices\' from response model instead of this")]
        public IEnumerable<string> IncludedExtraServices { get; set; }
        /// <summary>
        ///     Gets or sets the list of services, both included and optional.
        /// </summary>
        [Obsolete("Use property \'ExtraServices\' from response model instead of this")]
        public IEnumerable<PackageServiceModel> Services { get; set; }
        /// <summary>Gets or sets if it is unavailable.</summary>
        public bool IsUnavailable { get; set; }
        /// <summary>Gets or sets the discounts information.</summary>
        public IEnumerable<DiscountsModel> DiscountsInfo { get; set; }
        public AirportModel DepartureAirport { get; set; }
        public AirportModel ArrivalAirport { get; set; }
        /// <summary>Gets or sets the Geolocation information</summary>
        public GeoCoordinateModel Geolocation { get; set; }

        public Accommodation Accommodation { get; set; }
    }

    public class Accommodation
    {
        public string Name { get; set; }
        public string AccoImageUrl { get; set; }
    }
}