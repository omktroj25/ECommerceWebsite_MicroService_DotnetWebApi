using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using Entity.Dto;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Entity.Data;
using AutoMapper;
using Service;
using Repository;
using Contract.IService;
using NLog;

namespace UserMicroServiceApi.Controller
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UserMicroServiceController : ControllerBase
    {
        private readonly UserMicroService userMicroService;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UserMicroServiceController(UserMicroService _userMicroService)
        {
            userMicroService = _userMicroService;
        }

        /// <summary>
        /// User can update address information using this api
        /// </summary>
        /// <remarks>update the delivery address of the user</remarks>
        /// <param name="addressId">Id of the user to update the address details</param>
        /// <param name="body">To send address information to update in the database</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [Route("/api/user/address/{address-id}")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserUpdateAddressApi")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserUpdateAddressApi([FromRoute(Name ="address-id")][Required]Guid addressId, [FromBody]AddressDto addressDto)
        { 
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return Ok(userMicroService.UpdateAddressService(addressId, userId, addressDto));
        }

        /// <summary>
        /// User can delete address details using this api
        /// </summary>
        /// <remarks>Delete address from the database</remarks>
        /// <param name="addressId">Id of the address to delete</param>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        [Route("/api/user/address/delete/{address-id}")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserDeleteAddressApi")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserDeleteAddressApi([FromRoute(Name ="address-id")][Required]Guid addressId)
        { 
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return Ok(userMicroService.DeleteAddressService(addressId, userId));
        }

        /// <summary>
        /// User can add address information using this api
        /// </summary>
        /// <remarks>Add the delivery address for the user</remarks>
        /// <param name="body">To send address information to add in the database</param>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [Route("/api/user/address")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserCreateAddressApi")]
        [SwaggerResponse(statusCode: 201, type: typeof(ResponseIdDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserCreateAddressApi([FromBody]AddressDto addressDto)
        {
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return CreatedAtAction(nameof(UserCreateAddressApi), userMicroService.AddAddressService(userId, addressDto));
        }

        // /// <summary>
        // /// User can delete his account details using this api
        // /// </summary>
        // /// <remarks>Delete user account from the database</remarks>
        // /// <response code="200">Success</response>
        // /// <response code="500">Internal server error</response>
        // [HttpDelete]
        // [Route("/api/user/delete")]
        // [Authorize(Roles="User")]
        // [SwaggerOperation("ApiUserDeleteDelete")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiUserDeleteDelete()
        // { 

        // }

        /// <summary>
        /// Login api for admin and user
        /// </summary>
        /// <remarks>To login to the system using username and password</remarks>
        /// <param name="body">To send login credentials to the server to validate</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [Route("/api/user/login")]
        [SwaggerOperation("UserLoginApi")]
        [SwaggerResponse(statusCode: 200, type: typeof(TokenResponseDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 401, type: typeof(ResponseDto), description: "Unauthorized access")]
        [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserLoginApi([FromBody]LoginDto loginDto)
        { 
            return Ok(userMicroService.GenerateTokenService(loginDto));
        }

        /// <summary>
        /// User can delete payment details using this api
        /// </summary>
        /// <remarks>Delete payment information</remarks>
        /// <param name="paymentId">Id of the payment to delete</param>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        [Route("/api/user/payment/delete/{payment-id}")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserPaymentDeleteApi")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserPaymentDeleteApi([FromRoute(Name ="payment-id")][Required]Guid paymentId)
        { 
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return Ok(userMicroService.DeletePaymentService(paymentId, userId));
        }

        /// <summary>
        /// User can update payment information using this api
        /// </summary>
        /// <remarks>update the payment details of the user</remarks>
        /// <param name="paymentId">Id of the user to update the payment details</param>
        /// <param name="body">To send payment information to update</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [Route("/api/user/payment/{payment-id}")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserUpdatePaymentApi")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserUpdatePaymentApi([FromRoute(Name ="payment-id")][Required]Guid paymentId, [FromBody]PaymentDto paymentDto)
        { 
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return Ok(userMicroService.UpdatePaymentService(paymentId, userId, paymentDto));
        }

        /// <summary>
        /// User can add payment information using this api
        /// </summary>
        /// <remarks>Add the payment details of the user</remarks>
        /// <param name="body">To send payment information to add in the database</param>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [Route("/api/user/payment")]
        [Authorize(Roles="User")]
        [SwaggerOperation("UserCreatePaymentApi")]
        [SwaggerResponse(statusCode: 201, type: typeof(ResponseIdDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserCreatePaymentApi([FromBody]PaymentDto paymentDto)
        { 
            Guid userId = new Guid(User.Claims.FirstOrDefault(u => u.Type == "NameId")!.Value);
            return CreatedAtAction(nameof(UserRegisterApi), userMicroService.AddPaymentService(userId, paymentDto));
        }

        /// <summary>
        /// Register api for new user registration
        /// </summary>
        /// <remarks>User can create account to access e-commerce service by registering their information</remarks>
        /// <param name="body">To send the user information to the server to save in the database</param>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [Route("/api/user/register")]
        [SwaggerOperation("UserRegisterApi")]
        [SwaggerResponse(statusCode: 201, type: typeof(ResponseIdDto), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        public virtual IActionResult UserRegisterApi([FromBody]RegisterDto registerDto)
        { 
            return CreatedAtAction(nameof(UserRegisterApi), userMicroService.RegisterUserService(registerDto));
        }

        // /// <summary>
        // /// Update user information
        // /// </summary>
        // /// <remarks>User can update his information</remarks>
        // /// <param name="body">To update the user information in the database</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPut]
        // [Route("/api/user/update")]
        // [Authorize(Roles="User")]
        // [SwaggerOperation("ApiUserUpdatePut")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiUserUpdatePut([FromBody]RegisterDto body)
        // { 

        // }

        // /// <summary>
        // /// User can delete product from their wishlist using this api
        // /// </summary>
        // /// <remarks>Delete product from the wishlist</remarks>
        // /// <param name="productId">Id of the product to delete</param>
        // /// <response code="200">Success</response>
        // /// <response code="404">Not found</response>
        // /// <response code="500">Internal server error</response>
        // [HttpDelete]
        // [Route("/api/user/wishlist/delete/{product-id}")]
        // [Authorize(Roles="User")]
        // [SwaggerOperation("ApiUserWishlistDeleteProductIdDelete")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiUserWishlistDeleteProductIdDelete([FromRoute][Required]Guid? productId)
        // { 

        // }

        // /// <summary>
        // /// User can add product to their wishlist using this api
        // /// </summary>
        // /// <remarks>Add the payment details of the user</remarks>
        // /// <param name="productId">Id of the product to add to the wishlist</param>
        // /// <response code="200">Success</response>
        // /// <response code="404">Not found</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/user/wishlist/{product-id}")]
        // [Authorize(Roles="User")]
        // [SwaggerOperation("ApiUserWishlistProductIdPost")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiUserWishlistProductIdPost([FromRoute][Required]Guid? productId)
        // { 
            
        // }

    }
}
