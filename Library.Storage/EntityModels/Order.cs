using System;

namespace Library.Storage.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PlanedRefundDate { get; set; }
        public DateTime FactRefundDate { get; set; }
        public DateTime FactIssuanceDate { get; set; }
        public bool IsExpired { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public bool OrderState { get; set; }
    }
}