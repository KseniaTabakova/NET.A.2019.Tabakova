using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Library.Helpers
{
    /// <summary>
    /// Criteria for books searching.
    /// </summary>
    public enum Tags
    {
        ISBN,
        Author,
        Title,
        Publisher,
        YearOfPublication,
        NumberOfPages,
        Price
    }
}
