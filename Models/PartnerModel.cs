namespace DoAnTKPMNC.Models
{
    using global::DoAnTKPMNC.Entities;
    using System;
    using System.Collections.Generic;

    namespace DoAnTKPMNC.Entities
    {
        public class PartnerModel
        {
            public string? PhoneNumber { get; set; }
            public string PartnerName { get; set; }            
            public AccountModel AccountModel  { get; set;}
        }
    }

}
