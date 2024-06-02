using DataAccess.Repositories;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal static class BookDtoExtensions
    {
        internal static Book ToBook(this BookDto bookDto)
        => new()
        {
            Name = bookDto.Name,
            Price = bookDto.Price,
            Image = bookDto.Image
        };
    }
}
