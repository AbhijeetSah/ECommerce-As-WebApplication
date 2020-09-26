using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class CommentCommon:Common
    {
        public string  RowId { get; set; }
        public string  ProductReferenceId { get; set; }
        public string  CommentMessage { get; set; }
        public string  CommentBy { get; set; }
        public string  CommentTo { get; set; }
    }
}
