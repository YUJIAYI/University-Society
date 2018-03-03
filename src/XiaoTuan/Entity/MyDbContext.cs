using XiaoTuan.Configs;

namespace XiaoTuan.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base((string)Setting.ConnectionString)
        {
        }
        public virtual DbSet<activity> activity { get; set; }
        public virtual DbSet<activityCollection> activityCollection { get; set; }
        public virtual DbSet<enroll> enroll { get; set; }
        public virtual DbSet<organization> organization { get; set; }
        public virtual DbSet<organizationalConcerns> organizationalConcerns { get; set; }
        public virtual DbSet<orgMember> orgMember { get; set; }
        public virtual DbSet<photo> photo { get; set; }
        public virtual DbSet<student> student { get; set; }
        public virtual DbSet<task> task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<activity>()
                .Property(e => e.activity_id)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.org_id)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.activity_name)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.activity_detail)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.sign_notice)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.activity_place)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.activity_photo)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .HasMany(e => e.activityCollection)
                .WithOptional(e => e.activity)
                .WillCascadeOnDelete();

            modelBuilder.Entity<activity>()
                .HasMany(e => e.photo)
                .WithOptional(e => e.activity)
                .WillCascadeOnDelete();

            modelBuilder.Entity<activityCollection>()
                .Property(e => e.collection_id)
                .IsUnicode(false);

            modelBuilder.Entity<activityCollection>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<activityCollection>()
                .Property(e => e.activity_id)
                .IsUnicode(false);

            modelBuilder.Entity<enroll>()
                .Property(e => e.org_form_id)
                .IsUnicode(false);

            modelBuilder.Entity<enroll>()
                .Property(e => e.activity_id)
                .IsUnicode(false);

            modelBuilder.Entity<enroll>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<enroll>()
                .Property(e => e.evaluate_content)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.org_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.org_name)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.org_introduce)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.Internal_construction)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.org_logo)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.org_enclosure)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .Property(e => e.superior_org_id)
                .IsUnicode(false);

            modelBuilder.Entity<organization>()
                .HasMany(e => e.activity)
                .WithOptional(e => e.organization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<organization>()
                .HasMany(e => e.organizationalConcerns)
                .WithOptional(e => e.organization)
                .WillCascadeOnDelete();

            modelBuilder.Entity<organizationalConcerns>()
                .Property(e => e.concerns_id)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalConcerns>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<organizationalConcerns>()
                .Property(e => e.org_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgMember>()
                .Property(e => e.org_member_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgMember>()
                .Property(e => e.org_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgMember>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<orgMember>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<orgMember>()
                .HasMany(e => e.task)
                .WithOptional(e => e.orgMember)
                .HasForeignKey(e => e.Initiator_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<orgMember>()
                .HasMany(e => e.task1)
                .WithOptional(e => e.orgMember1)
                .HasForeignKey(e => e.allocator_id);

            modelBuilder.Entity<photo>()
                .Property(e => e.photo_id)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.activity_id)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<photo>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.school)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.major)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.grade)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.cell_number)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.card_number)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.identfily_pic)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .HasMany(e => e.activityCollection)
                .WithOptional(e => e.student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<student>()
                .HasMany(e => e.enroll)
                .WithRequired(e => e.student)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<student>()
                .HasMany(e => e.organizationalConcerns)
                .WithOptional(e => e.student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<student>()
                .HasMany(e => e.orgMember)
                .WithRequired(e => e.student)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<student>()
                .HasMany(e => e.photo1)
                .WithOptional(e => e.student)
                .WillCascadeOnDelete();

            modelBuilder.Entity<task>()
                .Property(e => e.task_id)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.Initiator_id)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.allocator_id)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.task_detail)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.task_enclosure)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.return_reason)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.evaluate_content)
                .IsUnicode(false);
        }
    }
}
