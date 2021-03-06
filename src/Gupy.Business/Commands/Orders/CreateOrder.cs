﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Orders
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public OrderDto OrderDto { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShippingDetailsRepository _detailsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IShippingDetailsRepository detailsRepository,
            IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _detailsRepository = detailsRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDto = request.OrderDto;

            var details = await _detailsRepository.GetAsync(orderDto.ShippingDetailsId);
            if (details == null)
            {
                throw new NotValidException(nameof(orderDto.ShippingDetailsId),
                    $"ShippingDetails with id ({orderDto.ShippingDetailsId}) doesn't exist");
            }

            var order = _mapper.Map<Order>(orderDto);
            order.OrderStatus = OrderStatus.Pending;
            order.DateOrdered = DateTime.UtcNow;

            foreach (var orderItem in order.OrderItems)
            {
                var product = await _productRepository.GetAsync(orderItem.ProductId);
                if (product == null || product.SoftDeleted)
                {
                    throw new NotValidException(nameof(orderItem.ProductId),
                        $"Product with id ({orderItem.ProductId}) does not exist");
                }

                if (!product.IsAvailable)
                {
                    throw new NotValidException(nameof(orderItem),
                        $"Product with id ({orderItem.ProductId}) is not available");
                }

                if (product.PromotionEndDate < DateTime.UtcNow && product.PromotionPrice.HasValue)
                {
                    orderItem.PricePerUnit = product.PromotionPrice.Value;
                }
                else
                {
                    orderItem.PricePerUnit = product.Price;
                }
            }

            if (order.TotalSum < 1)
            {
                throw new NotValidException(nameof(Order.TotalSum), "Order total sum should be greater than 1");
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}