using AdoptMe.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdoptMe.Data.Models
{
    public class Reply : BaseDeletableModel<int>
    {
        public Reply()
        {
            this.ReplyPictures = new HashSet<Picture>();
        }

        public string Text { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Picture> ReplyPictures { get; set; }
    }
}
