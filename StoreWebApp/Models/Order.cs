using System;
using System.Collections.Generic;

namespace StoreWebApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int PickupPointId { get; set; }

    public int Code { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();

    public virtual User User { get; set; } = null!;
}
