using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto bookDto)
            => Ok(await _bookService.CreateAsync(bookDto)); //returns id

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int id)
            => Ok(await _bookService.GetAsync(id));

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] BookDto bookDto)
        {
            await _bookService.UpdateAsync(id, bookDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
    }
}
