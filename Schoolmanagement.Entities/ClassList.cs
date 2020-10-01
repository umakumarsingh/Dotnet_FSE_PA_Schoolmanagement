using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.Entities
{
    public enum ClassList
    {
        [Display(Name = "All Class")]
        All,
        [Display(Name = "Pre Nursery")]
        PreNursery, Nursery,
        [Display(Name = "Kinder Garten")]
        KG,
        [Display(Name = "Lower Kindergarten")]
        LKG,
        [Display(Name = "Upper Kindergarten")]
        UKG, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, ELEVEN, TWELVE
    }
}
