using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Sipariş numarası alanı zorunludur.")]
        [StringLength(6, ErrorMessage = "Sipariş numarası 6 karakterden uzun olmamalı")]
        public string OrderNo { get; set; }
        [Required(ErrorMessage = "Çıkış adresi alanı zorunludur.")]
        public string OutputAddress { get; set; }
        [Required(ErrorMessage = "Varış adresi alanı zorunludur.")]
        public string ArrivalAddress { get; set; }
        [Required(ErrorMessage = "Miktar alanı zorunludur.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Miktar birim alanı zorunludur.")]
        public string QuantityUnit { get; set; }
        [Required(ErrorMessage = "Ağırlık alanı zorunludur.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Ağırlık birim alanı zorunludur.")]
        public string WeightUnit { get; set; }
        [Required(ErrorMessage = "Malzeme kodu alanı zorunludur.")]
        public string MaterialCode { get; set; }
        [Required(ErrorMessage = "Malzeme adı alanı zorunludur.")]
        public string MaterialName { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}
