using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg
{
    public class Category :AggregateRoot
    {
        public Category(string title, string slug, SeoData seoData, ICategoryDomainServices service)
        {
            slug = Slug.ToSlug();

            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
        public string Title { get; private set; }

        public string Slug { get; private set; }

        public SeoData SeoData { get; private set; }

        public long?  ParentId { get;private set; }

        public List<Category> CHild { get; private set; }

        public void Edit(SeoData seoData, string title ,string slug, ICategoryDomainServices service)
        {
            slug = slug?.ToSlug();
            Guard(slug, title, service);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public void AddChild (string  title, string slug, SeoData seoData, ICategoryDomainServices service)
        {
            CHild.Add(new Category(title, slug, seoData, service)
            {
                ParentId = Id
            });
        }

        public void Guard( string title, string slug , ICategoryDomainServices service)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if ( slug != Slug)
           if(service.IsSlugExists(slug));
            throw new SlugIsDuplicateException();


        }
    }
}
