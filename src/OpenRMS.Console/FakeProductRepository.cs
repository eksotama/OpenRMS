﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Console
{
    internal class FakeProductRepository : IProductRepository /*,  IRepository<Product>*/
    {
        private List<Product> _products = new List<Product>()
        {
            new Product( id: Guid.NewGuid(), name: "Product 1", description: "Product 1 Description", attributes: new List<ProductAttribute>() ),
            new Product( id:Guid.NewGuid(), name: "Product 2", description: "Product 2 Description", attributes: new List<ProductAttribute>() ),
            new Product( id:Guid.NewGuid(), name: "Product 3", description: "Product 3 Description", attributes: new List<ProductAttribute>() )
        };

        public void Create(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            var hasEntity = _products.Any(product => product == entity);
            if (!hasEntity)
            {
                throw new InvalidOperationException("product not found to delete");
            }
            _products.Remove(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Maybe<Product, Guid> GetForId(Guid id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);

            if (product == null) return new Maybe<Product, Guid>();

            return new Maybe<Product, Guid>(product);
        }

        public Maybe<Product, Guid> GetForName(string name)
        {
            var product = _products.SingleOrDefault(p => p.Name == name);

            if (product == null) return new Maybe<Product, Guid>();

            return new Maybe<Product, Guid>(product);
        }

        public void Update(Product entity)
        {
            var product = _products.SingleOrDefault(p => p.Id == entity.Id);

            if (product == null) throw new InvalidOperationException("product not found in collection");

            product.SetValues(entity.Name, entity.Description);

        }
    }
}