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
    public partial class ProductDto
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
        /// Gets or Sets ProductName
        /// </summary>

        [JsonPropertyName("product_name")]
        [Required(ErrorMessage = "product name is required ( product_name )")]
        public string ProductName { get; set; }="";

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [JsonPropertyName("price")]
        [Required(ErrorMessage = "price is required ( price )")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "price must be a positive value greater than 0")]
        public Decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>

        [JsonPropertyName("category")]
        [Required(ErrorMessage = "category is required ( category )")]
        public string Category { get; set; }="";

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [JsonPropertyName("description")]
        [Required(ErrorMessage = "description is required ( description )")]
        public string Description { get; set; }="";

        /// <summary>
        /// Gets or Sets Stock
        /// </summary>

        [JsonPropertyName("stock")]
        [Required(ErrorMessage = "stock is required ( stock )")]
        [RegularExpression(@"^(?!0$)\d+$", ErrorMessage = "stock must be greater than zero")]
        public int Stock { get; set; }

        
    }
}
