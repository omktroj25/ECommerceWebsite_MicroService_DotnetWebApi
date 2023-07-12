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
    public partial class OrderDto
    { 
        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name="name")]
        public string Name { get; set; }="";

        /// <summary>
        /// Gets or Sets EmailAddress
        /// </summary>

        [DataMember(Name="email_address")]
        public string EmailAddress { get; set; }="";

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>

        [DataMember(Name="phone_number")]
        public string PhoneNumber { get; set; }="";

        /// <summary>
        /// Gets or Sets AddressDetails
        /// </summary>

        [DataMember(Name="address_details")]
        public AddressDto? AddressDetails { get; set; }

        /// <summary>
        /// Gets or Sets PaymentDetails
        /// </summary>

        [DataMember(Name="payment_details")]
        public PaymentDto? PaymentDetails { get; set; }

        /// <summary>
        /// Gets or Sets OrderItems
        /// </summary>

        [DataMember(Name="order_items")]
        public List<ProductDto>? OrderItems { get; set; }

        /// <summary>
        /// Gets or Sets OrderItems
        /// </summary>

        [DataMember(Name="amount")]
        public Decimal Amount { get; set; }

   
    }
}
