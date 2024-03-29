﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipTypeModel
    {
        [Key]
        public Guid IDMembershipType { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int SubscriptionLengthInMonths { get; set; }
    }
}
