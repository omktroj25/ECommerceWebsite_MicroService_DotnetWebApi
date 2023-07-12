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

namespace OrderMicroServiceApi.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class OrderMicroServiceController : ControllerBase
    {
        private readonly OrderMicroService orderMicroService;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public OrderMicroServiceController(OrderMicroService _orderMicroService)
        {
            orderMicroService = _orderMicroService;
        }

        // /// <summary>
        // /// User can delete a product from the cart by using this api
        // /// </summary>
        // /// <remarks>user can delete a product from the cart through this api</remarks>
        // /// <param name="productId">Id of the product to delete form the cart item</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="404">Not found</response>
        // /// <response code="500">Internal server error</response>
        // [HttpDelete]
        // [Route("/api/order/cart-item/delete/{product-id}")]
        // [Authorize]
        // [SwaggerOperation("ApiOrderCartItemDeleteProductIdDelete")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiOrderCartItemDeleteProductIdDelete([FromRoute][Required]Guid? productId)
        // { 
            
        // }

        // /// <summary>
        // /// User can add a product to the cart
        // /// </summary>
        // /// <remarks>User can add a product to the cart using this API.</remarks>
        // /// <param name="productId">ID of the product to update in the cart</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="404">Not Found</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/order/cart-item/{product-id}")]
        // [Authorize]
        // [SwaggerOperation("ApiOrderCartItemProductIdPost")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not Found")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiOrderCartItemProductIdPost([FromRoute][Required]Guid? productId)
        // { 
           
        // }

        // /// <summary>
        // /// User can update the quantity of the product by using API
        // /// </summary>
        // /// <remarks>Admin can update product quantity through this API</remarks>
        // /// <param name="productId">The ID of the product</param>
        // /// <param name="count">The action to perform (increase or decrease)</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="404">Not found</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/order/cart-item-quantity/{product-id}")]
        // [Authorize]
        // [SwaggerOperation("ApiOrderCartItemQuantityProductIdPost")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiOrderCartItemQuantityProductIdPost([FromRoute][Required]string productId, [FromQuery][Required()]int? count)
        // { 
            
        // }

        // /// <summary>
        // /// User can place an order
        // /// </summary>
        // /// <remarks>place order using the provided details</remarks>
        // /// <param name="addressId">address id for deliverying the order</param>
        // /// <param name="paymentId">payment id for paying to the order</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/order/checkout")]
        // [Authorize]
        // [SwaggerOperation("ApiOrderCheckoutPost")]
        // [SwaggerResponse(statusCode: 200, type: typeof(OrderDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiOrderCheckoutPost([FromQuery][Required()]Guid? addressId, [FromQuery][Required()]Guid? paymentId)
        // { 
            
        // }

    }
}
