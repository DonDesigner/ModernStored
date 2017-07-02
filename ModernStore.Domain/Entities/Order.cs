﻿using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        protected Order() { }

        private readonly IList<OrderItem> _Items;

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _Items = new List<OrderItem>();

            new FluentValidator.ValidationContract<Order>(this)
                .IsGreaterThan(x=>x.DeliveryFee, 0)
                .IsGreaterThan(x=>x.Discount, -1);
        }


        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items => _Items.ToArray();

        public decimal DeliveryFee { get; private set; }  //Taxa de Entrega
        public decimal Discount { get; private set; } //Desconto
 
        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            if (item.IsValid())
                _Items.Add(item);
        }



    }
}
