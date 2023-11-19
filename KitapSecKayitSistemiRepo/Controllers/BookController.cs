using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Controllers
{
    public class BookController : Controller
    {
        public readonly IBook bookRepository;
        public BookController(IBook bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IActionResult> GetBookList()
        {
            var result = await bookRepository.GetBook();
            return View(result);
        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Books book)
        {
            await bookRepository.AddBook(book);

            if (book.BookId == 0)
            {
                TempData["bookError"] = "Kayıt Başarısız";

            }
            else
            {
                TempData["bookSuccess"] = "Kayıt Başarılı";


            }

            return RedirectToAction("GetBookList");


        }



        public async Task<IActionResult> Edit(int id)
        {
            Books book = new Books();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    book =await bookRepository.GetBookById(id);
                    if (book == null)
                    {
                        return NotFound();
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }

            return View(book);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Books book)
        {
            bool status = await bookRepository.UpdateBook(book);
            if (book.BookId == 0)
            {

                TempData["bookError"] = "Güncelleme Başarısız";


            }
            else
            {
                TempData["bookSuccess"] = "Güncelleme Başarılı";
            }

            return RedirectToAction("GetBookList");
        }


        
        public async Task<IActionResult> Delete(int id)
        {
            Books book = new Books();
            try
            {
                if (id == 0)
                {

                    return BadRequest();
                }
                else
                {
                    book = await bookRepository.GetBookById(id);
                    if (book == null)
                    {
                        return NotFound();
                    }


                }
          
            }
            catch (Exception)
            {

                throw;
            }
            return View(book);

        }



        [HttpPost]
        public async Task<IActionResult> Delete(Books book)
        {
            bool status = await bookRepository.DeleteBook(book);
            if (book.BookId == 0)
            {

                TempData["bookError"] = "Silme Başarısız";


            }
            else
            {
                TempData["bookSuccess"] = "Silme Başarılı";
            }

            return RedirectToAction("GetBookList");
        }



    }
}
