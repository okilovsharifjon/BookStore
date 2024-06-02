using AutoMapper;
using DataAccess;
using DataAccess.Repositories;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookService(
        BookRepository bookRepository,
        AuthorRepository authorRepository,
        CategoryRepository categoryRepository) : IBookService
    {
        private readonly BookRepository _bookRepository = bookRepository;
        private readonly AuthorRepository _authorRepository = authorRepository;
        private readonly CategoryRepository _categoryRepository = categoryRepository;

        public async Task<int> CreateAsync(BookDto bookDto, CancellationToken token = default)
        {
            Book book = bookDto.ToBook();
            Category category = _categoryRepository.Get(bookDto.Category);
            if (category is null)
            {
                _categoryRepository.CreateAsync(new() { Name = bookDto.Category });
                category = _categoryRepository.Get(bookDto.Category);
            }
            
            book.Category = category;
            book.CategoryId = category.Id;

            Author author = _authorRepository.Get(bookDto.Author);
            if (author is null)
            {
                _authorRepository.CreateAsync(new() { Name = bookDto.Author });
                author = _authorRepository.Get(bookDto.Author);
            }
            book.Author = author;
            book.AuthorId = author.Id;

            
            return await _bookRepository.CreateAsync(book, token);
        }
        public async Task<Book> GetAsync(int id, CancellationToken token)
            => await _bookRepository.GetAsync(id, token);
        public async Task UpdateAsync(int id, BookDto bookDto, CancellationToken token)
        {
            Book book = bookDto.ToBook();
            Category category = _categoryRepository.Get(bookDto.Category);
            if (category is null)
            {
                _categoryRepository.CreateAsync(new() { Name = bookDto.Category });
                category = _categoryRepository.Get(bookDto.Category);
            }

            book.Category = category;
            book.CategoryId = category.Id;

            Author author = _authorRepository.Get(bookDto.Author);
            if (author is null)
            {
                _authorRepository.CreateAsync(new() { Name = bookDto.Author });
                author = _authorRepository.Get(bookDto.Author);
            }
            book.Author = author;
            book.AuthorId = author.Id;
            await _bookRepository.UpdateAsync(id, book, token);
        }
          
        public async Task DeleteAsync(int id, CancellationToken token)
            => await _bookRepository.DeleteAsync(id, token);
    }
}
