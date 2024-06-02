using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public record struct BookDto(
        string Name,
        decimal Price,
        string Image,
        string Author,
        string Category
        );
}
