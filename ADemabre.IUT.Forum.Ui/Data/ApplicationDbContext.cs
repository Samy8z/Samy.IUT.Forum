using ADemabre.IUT.Forum.Ui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADemabre.IUT.Forum.Ui.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {     
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            #region User
            builder.Entity<User>(b =>
            {
                // Each users can have multiple claims
                // b = builder
                b.HasMany(e => e.Claims) // User has many (e => e.Claims) | (e => e.Claims) return UserClaims builder
                //        e -> Entity(user)   e.Claims -> With propriety claims
                .WithOne() // Une correspondance 

                    .HasForeignKey(uc => uc.UserId) // foreign key 
                                                    //          UserClaims -> Table de liaison entre User et Claims
                                                    // UserId est foreign key dans uc
                    .IsRequired();

                // Each users can have multiple logins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each users can have multiple UserToken
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each users can have multiple UserRoles
                b.HasMany(e => e.UserRoles)
                    .WithOne(u => u.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                // Each users can have multiple messages
                b.HasMany(e => e.Messages)
                    .WithOne()
                    .HasForeignKey(m => m.UserId)
                    .IsRequired();
            });
            #endregion 
            
            #region Role
            builder.Entity<Role>(b =>
            {
                // Each user can have multiple userRoles
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.Property(e => e.Description)
                    .HasMaxLength(255);

            });
            #endregion
            
            #region Message
            builder.Entity<Message>(b =>
            {
                b.HasKey(e => e.Id);

                b.HasOne(e => e.Sujet)
                    .WithMany(s => s.Messages)
                    .HasForeignKey(m => m.SujetId)
                    .IsRequired();

                b.Property(e => e.Content)
                    .IsRequired();

                b.Property(e => e.IsDeleted)
                    .HasDefaultValue(false);

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Save);
            });
            #endregion
            
            #region Categorie
            builder.Entity<Categorie>(b =>
            {
                b.HasKey(e => e.Id);
                    
                
                b.Property(n => n.Nom)
                    .IsRequired();

                b.Property(e => e.Description)
                    .HasMaxLength(2000);

                b.Property(e => e.Cle)
                    //.HasDefaultValue(c => c.Nom)
                    .IsRequired();

                b.Property(e => e.Order)
                    .IsRequired();

                b.Property(e => e.Creation)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save); // Donne la date

               
            });
            #endregion
            
            #region Sujet
            builder.Entity<Sujet>(b =>
            {
                b.HasKey(b => b.Id);

                b.HasOne(e => e.Topic)
                    .WithMany(t => t.Sujets)
                    .HasForeignKey(s => s.TopicId)
                    .IsRequired();

                b.Property(n => n.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                b.Property(e => e.Suppression);
                    
                
                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            });
            #endregion
            
            #region Topic
            builder.Entity<Topic>(b =>
            {
                b.HasKey(e => e.Id);

                b.HasOne(e => e.Categorie)
                    .WithMany(c => c.Topics)
                    .HasForeignKey(t => t.CategorieId)
                    .IsRequired();

                b.Property(n => n.Nom)
                    .HasMaxLength(255)
                    .IsRequired();

                b.Property(e => e.Description)
                    .HasMaxLength(2000);

                b.Property(e => e.Cle)
                    //.HasDefaultValue(c => c.Nom)
                    .IsRequired();

                b.Property(o => o.Order)
                    .IsRequired();

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

                
            });
            #endregion
        }
    }
}