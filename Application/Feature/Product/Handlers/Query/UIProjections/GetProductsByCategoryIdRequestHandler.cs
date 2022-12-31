﻿using Application.DTO.Product;
using Application.Feature.Product.Requests.UIProjections;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Handlers.Query.UIProjections
{
    public class GetProductsByCategoryIdRequestHandler : IRequestHandler<GetProductsByCategoryIdRequest, List<ProductListDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryIdRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ProductListDto>>(await _productRepository.GetProductsByCategoryId(request.NidCategory, request.PageSize, request.Skip));
        }
    }
}
