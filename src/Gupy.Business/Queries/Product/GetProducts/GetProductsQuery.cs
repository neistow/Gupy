﻿using System.Collections.Generic;
using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Product.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public int? CategoryId { get; set; }
        public bool? Available { get; set; }
    }
}