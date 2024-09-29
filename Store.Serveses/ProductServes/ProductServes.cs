﻿using AutoMapper;
using Store.Data.Entites;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Spceficitions.ProductSpecs;
using Store.Serveses.ProductServes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Data.Entites.Type;

namespace Store.Serveses.ProductServes
{
    public class ProductServes : IProductServes
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ProductServes(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public Task<IReadOnlyList<Brand>> GetBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Type>> GetTypeAsync()
        {
            throw new NotImplementedException();
        }

        //       public async Task<IReadOnlyList<Type>> GetTypeAsync()
        //              => await unit.reposatry<Type>().GetAll();

        //       public async Task<IReadOnlyList<Brand>> GetBrandsAsync()
        //=> await unit.reposatry<Brand>().GetAll();

        async Task<ProductDTO> IProductServes.GetProductAsync(int id)
        {
            var products = await unit.reposatry<Product>().Getbyid(id);

            var result = mapper.Map<ProductDTO>(products);
            return (result);
        }

        async Task<IReadOnlyList<ProductDTO>> IProductServes.GetProductsAsync(ProductSpecfictions input)
        {
            var specs = new ProductWithSpecs(input);
            var products = await unit.reposatry<Product>().GetAll(specs);

            var result = mapper.Map<IReadOnlyList<ProductDTO>>(products);

            return result;
        }
    }
}
