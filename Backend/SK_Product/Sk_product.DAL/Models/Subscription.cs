﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sk_product.DAL.Models
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime SubscribedOn { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}