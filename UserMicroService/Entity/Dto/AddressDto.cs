using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Entity.Dto
{   
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AddressDto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid UserId { get; set; }
        [JsonPropertyName("id")]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid Id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid CreatedBy { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Line1
        /// </summary>

        [JsonPropertyName("line1")]
        public string Line1 { get; set; }="";

        /// <summary>
        /// Gets or Sets Line2
        /// </summary>

        [JsonPropertyName("line2")]
        public string Line2 { get; set; }="";

        /// <summary>
        /// Gets or Sets City
        /// </summary>

        [JsonPropertyName("city")]
        public string City { get; set; }="";

        /// <summary>
        /// Gets or Sets Zipcode
        /// </summary>

        [JsonPropertyName("zipcode")]
        [RegularExpression(@"^[0-9]{5,}$", ErrorMessage = "Invalid zipcode format, The zipcode must be at least of five digit numbers")]
        public string ZipCode { get; set; }="";

        /// <summary>
        /// Gets or Sets State
        /// </summary>

        [JsonPropertyName("state")]
        public string State { get; set; }="";

        /// <summary>
        /// Gets or Sets Country
        /// </summary>

        [JsonPropertyName("country")]
        public string Country { get; set; }="";

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>

        [JsonPropertyName("phone_number")]
        [RegularExpression(@"^\+?[0-9]{8,}$", ErrorMessage = "Invalid phone number format, Use the valid phone number.The phone number must be at least of eight digit numbers optionally preceded with + sign")]
        public string PhoneNumber { get; set; }="";

        /// <summary>
        /// Gets or Sets AddressType
        /// </summary>

        [JsonPropertyName("address_type")]
        [RegularExpression("(HOME|WORK)", ErrorMessage = "The input must contain HOME or WORK .")]
        public string AddressType { get; set; }="";

    }
}
