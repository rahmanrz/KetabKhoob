using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
       

        public long UserId { get; set; }

        public long ProdusctId { get; private set; }

        public string Text { get; private set; }

        public CommentStatus Status { get; private set; }

        public DateTime UpdateDate { get; private set; }



        public Comment(long userId, long produsctId, string text)
        {

            NullOrEmptyDomainDataException.CheckString(text,nameof(text));

            UserId = userId;

            ProdusctId = produsctId;

            Text = text;

            Status = CommentStatus.Pending;
        }
        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            Text = Text;
            UpdateDate = DateTime.Now;
        }

        public void ChancheStattus(CommentStatus status)
        {   
            Status = status;
            UpdateDate = new DateTime();
        }
        public enum CommentStatus
        {
            Pending,
            Accepted,
            Rejected
        }
    }
}
