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
    public partial class RegisterDto
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
        /// Gets or Sets UserName
        /// </summary>

        [JsonPropertyName("user_name")]
        [Required(ErrorMessage = "user name is required ( user_name )")]
        public string UserName { get; set; }="";

        /// <summary>
        /// Gets or Sets Password
        /// </summary>

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "password is required ( password )")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password format, Password must contain at least 1 lowercase letter, 1 uppercase letter, 1 number, and 1 special character, and be at least 8 characters long")]
        public string Password { get; set; }="";

        /// <summary>
        /// Gets or Sets ConfirmPassword
        /// </summary>

        [JsonPropertyName("confirm_password")]
        [Required(ErrorMessage = "confirm password is required ( confirm_password )")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password doesn't match. Please try again")]
        public string ConfirmPassword { get; set; }="";

        /// <summary>
        /// Gets or Sets EmailAddress
        /// </summary>

        [JsonPropertyName("email_address")]
        [Required(ErrorMessage = "email address is required ( email_address )")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format, Use valid email id. example: username@domain.com")]
        public string EmailAddress { get; set; }="";

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>

        [JsonPropertyName("phone_number")]
        [Required(ErrorMessage = "phone number is required ( phone_number )")]
        [RegularExpression(@"^\+?[0-9]{8,}$", ErrorMessage = "Invalid phone number format, Use the valid phone number.The phone number must be at least of eight digit numbers optionally preceded with + sign")]
        public string PhoneNumber { get; set; }="";

    }
}
