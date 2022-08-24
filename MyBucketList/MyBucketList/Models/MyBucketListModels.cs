using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyBucketList.Models
{
    public class MyBucketListModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bucket Type")]
        public string BucketType { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime CreationDate { get; set; }

        //[StringLength(10)]
        [Display(Name = "I want to do it because:")]
        public string IWantIt { get; set; }

        [Display(Name = "To make it happens I need to:")]
        public string ToMakeiT { get; set; }

        [Display(Name = "What has stopped me before")]
        public string WhatSopped { get; set; }

       [ Display(Name = "I want to do it with:")]
        public string  IWantWith { get; set; }

        [Display(Name = "it's gonna to be:")]
        public string? ItIsGonnaBe { get; set; }

        [Display(Name = "Created By")]
        public string?  CreationEmail { get; set; }

        
        // public int BucketId { get; internal set; }

        [Display(Name = "When")]
        public string? WhenAfter { get; set; }
        [Display(Name = "Where")]
        public string? WhereAfter { get; set; }

        [Display(Name = "With")]
        public string? WithAfter { get; set; }

        [Display(Name = "How")]
        public string? HowAfter { get; set; }
        [Display(Name = " I've learnt")]
        public string? IlearnedAfter { get; set; }

        [Display(Name = "It made me feel ")]
        public string? ItMadeMeFeelAfter { get; set; }

        [Display(Name = "Would I do it?")]
        public string? WouldIDoItAfter { get; set; }
        [Display(Name = "The best part was?")]
        public string? TheBestPartAfter { get; set; }

        [Display(Name = "Completed")]
        public Boolean IsCompleted { get; set; }
    }
}

public enum ItIsGonnaBe
{
    challenging,
    scary,
    funAfter,
    difficul,
    expensive

}

public enum WouldIDoIAfter
{
    ohyeah,
    maybe,
    YesWithS,
    beenThere,
    notInaM

}