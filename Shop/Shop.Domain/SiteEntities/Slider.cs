using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public string  ImageName { get; private set; }
        public string link { get; private set;}

        public string Title { get; private set; }


        public Slider(string imageName, string link, string title)
        {
            Guard(link, imageName, title);
            ImageName = imageName;
            this.link = link;
            Title = title;
        }

        public void Edit(string imageName, string link, string title)
        {
            Guard(link,imageName,title);
            ImageName = imageName;
            this.link = link;
            Title = title;
        }
        public void Guard(string link, string imageName, string title)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

        }



    }
}
