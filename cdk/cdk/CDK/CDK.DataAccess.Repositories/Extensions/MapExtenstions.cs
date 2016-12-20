using CDK.DataAccess.Models;
using Repository.Pattern.Ef6;
using System.Data.Entity.ModelConfiguration;

namespace CDK.DataAccess.Repositories.Extensions
{
    internal static class MapExtenstions
    {
        public static void AddSeo<TEntity>(this EntityTypeConfiguration<TEntity> map)
            where TEntity : class, ISeoModel
        {
            map.Property(x => x.SeoCaption).HasColumnName("SeoCaption").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.SeoDescription).HasColumnName("SeoDescription").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.SeoSlug).HasColumnName("SeoSlug").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.SeoKeywords).HasColumnName("SeoKeywords").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            map.Property(x => x.SeoURI).HasColumnName("SeoURI").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.SeoMetaDescription).HasColumnName("SeoMetaDescription").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.SeoTitle).HasColumnName("SeoTitle").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }

        public static void AddPhoto<TEntity>(this EntityTypeConfiguration<TEntity> map)
            where TEntity : class, IPhotoModel
        {
            map.Property(x => x.LargeUri).HasColumnName("LargeUri").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.SmallUri).HasColumnName("SmallUri").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");
            map.Property(x => x.ThumbnailUri).HasColumnName("ThumbnailUri").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");

            map.Property(x => x.PhotoName).HasColumnName("PhotoName").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.PhotoType).HasColumnName("PhotoType").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

            map.Property(x => x.PhotoDescription).HasColumnName("PhotoDescription").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");

            map.Property(x => x.AltText).HasColumnName("AltText").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }

        public static void AddVideo<TEntity>(this EntityTypeConfiguration<TEntity> map)
            where TEntity : class, IVideoModel
        {
            map.Property(x => x.Name).HasColumnName("Name").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.Type).HasColumnName("Type").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.Uri).HasColumnName("Uri").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasColumnType("varchar(MAX)");

            map.Property(x => x.AltText).HasColumnName("AltText").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }

        public static void AddBase<TEntity>(this EntityTypeConfiguration<TEntity> map)
            where TEntity : Entity, IBaseModel
        {
            map.HasKey(x => x.Id);
            map.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            map.Property(x => x.LastUpdate).HasColumnName("LastUpdate").IsRequired().HasColumnType("datetime2");
            map.Property(x => x.Created).HasColumnName("Created").IsRequired().HasColumnType("datetime2");
            map.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.LastUpdateBy).HasColumnName("LastUpdateBy").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }

        public static void AddBaseWithoutId<TEntity>(this EntityTypeConfiguration<TEntity> map)
            where TEntity : Entity, IBaseModel
        {
            map.Property(x => x.LastUpdate).HasColumnName("LastUpdate").IsRequired().HasColumnType("datetime2");
            map.Property(x => x.Created).HasColumnName("Created").IsRequired().HasColumnType("datetime2");
            map.Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            map.Property(x => x.LastUpdateBy).HasColumnName("LastUpdateBy").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }

        public static void AddSequense<TEntity>(this EntityTypeConfiguration<TEntity> map)
           where TEntity : class, ISequenceModel
        {
            map.Property(x => x.SequenceNumber).HasColumnName("SequenceNumber");
        }

        public static void AddExternal<TEntity>(this EntityTypeConfiguration<TEntity> map)
           where TEntity : class, IExternalModel
        {
            map.Property(x => x.LastExternalUpdate).HasColumnName("LastExternalUpdate").IsRequired().HasColumnType("datetime2");
        }
        
    }
}