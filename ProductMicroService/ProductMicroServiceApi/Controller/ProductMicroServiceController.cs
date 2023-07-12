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

namespace ProductMicroServiceApi.Controller
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ProductMicroServiceController : ControllerBase
    { 
        private readonly ProductMicroService productMicroService;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ProductMicroServiceController(ProductMicroService _productMicroService)
        {
            productMicroService = _productMicroService;
        }

        // /// <summary>
        // /// Admin can update the stock of the product by using this product-stock update API
        // /// </summary>
        // /// <remarks>Admin can update product stock information through this API</remarks>
        // /// <param name="productId">The ID of the product</param>
        // /// <param name="count">The action to perform (increase or decrease)</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="404">Not found</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/inventory/{product-id}")]
        // [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        // [ValidateModelState]
        // [SwaggerOperation("ApiInventoryProductIdPost")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiInventoryProductIdPost([FromRoute][Required]string productId, [FromQuery][Required()]int? count)
        // { 
            
        // }

        // /// <summary>
        // /// Admin can delete product using this api
        // /// </summary>
        // /// <remarks>Delete product from the wishlist</remarks>
        // /// <param name="productId">Id of the product to delete</param>
        // /// <response code="200">Success</response>
        // /// <response code="404">Not found</response>
        // /// <response code="500">Internal server error</response>
        // [HttpDelete]
        // [Route("/api/product/delete/{product-id}")]
        // [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        // [ValidateModelState]
        // [SwaggerOperation("ApiProductDeleteProductIdDelete")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiProductDeleteProductIdDelete([FromRoute][Required]Guid? productId)
        // { 
           
        // }

        // /// <summary>
        // /// Admin can add product by using this add product api
        // /// </summary>
        // /// <remarks>New product can be added to the database</remarks>
        // /// <param name="body">To add new product to the database</param>
        // /// <response code="201">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPost]
        // [Route("/api/product")]
        // [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        // [ValidateModelState]
        // [SwaggerOperation("ApiProductPost")]
        // [SwaggerResponse(statusCode: 201, type: typeof(ResponseIdDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiProductPost([FromBody]List<ProductDtoInner> body)
        // { 
            
        // }

        // /// <summary>
        // /// Admin can update product by using this update product api
        // /// </summary>
        // /// <remarks>Product can be updated in the database</remarks>
        // /// <param name="productId">The ID of the product</param>
        // /// <param name="body">To update product in the database</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="404">Not found</response>
        // /// <response code="409">Conflict</response>
        // /// <response code="500">Internal server error</response>
        // [HttpPut]
        // [Route("/api/product/{product-id}")]
        // [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        // [ValidateModelState]
        // [SwaggerOperation("ApiProductProductIdPut")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ResponseDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 404, type: typeof(ResponseDto), description: "Not found")]
        // [SwaggerResponse(statusCode: 409, type: typeof(ResponseDto), description: "Conflict")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiProductProductIdPut([FromRoute][Required]string productId, [FromBody]List<ProductDtoInner> body)
        // { 
            
        // }

        // /// <summary>
        // /// Admin and user can view the list of products by using this get product api
        // /// </summary>
        // /// <remarks>To get all products list</remarks>
        // /// <param name="name">Filter products by name</param>
        // /// <param name="category">Filter products by category</param>
        // /// <param name="price">Filter products by price</param>
        // /// <param name="description">Filter products by description</param>
        // /// <param name="rowSize">number of movie to be returned</param>
        // /// <param name="startIndex">cursor position to fetch the movie</param>
        // /// <param name="sortBy">order to retrieve the movie details</param>
        // /// <param name="sortOrder">order to retrieve the movie details</param>
        // /// <response code="200">Success</response>
        // /// <response code="400">Bad request</response>
        // /// <response code="500">Internal server error</response>
        // [HttpGet]
        // [Route("/api/products")]
        // [Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        // [ValidateModelState]
        // [SwaggerOperation("ApiProductsGet")]
        // [SwaggerResponse(statusCode: 200, type: typeof(ProductDto), description: "Success")]
        // [SwaggerResponse(statusCode: 400, type: typeof(ResponseDto), description: "Bad request")]
        // [SwaggerResponse(statusCode: 500, type: typeof(ResponseDto), description: "Internal server error")]
        // public virtual IActionResult ApiProductsGet([FromQuery]string name, [FromQuery]string category, [FromQuery]string price, [FromQuery]string description, [FromQuery]int? rowSize, [FromQuery]int? startIndex, [FromQuery]string sortBy, [FromQuery]string sortOrder)
        // { 
            
        // }

    }
}
