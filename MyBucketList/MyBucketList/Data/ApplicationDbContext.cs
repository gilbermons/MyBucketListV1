using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBucketList.Models;
using MyBucketList.Data;

namespace MyBucketList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyBucketList.Models.MyBucketListModels>? MyBucketListModel { get; set; }
        public DbSet<MyBucketList.Data.Bucket>? Bucket { get; set; }
        public DbSet<MyBucketList.Data.BucketReview>? BucketReview { get; set; }
    }
}