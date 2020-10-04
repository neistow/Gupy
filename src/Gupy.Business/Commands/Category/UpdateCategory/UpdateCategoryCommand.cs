﻿using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Common;
using MediatR;

namespace Gupy.Business.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public CategoryDto CategoryDto { get; set; }
        public IFile Photo { get; set; }
    }
}