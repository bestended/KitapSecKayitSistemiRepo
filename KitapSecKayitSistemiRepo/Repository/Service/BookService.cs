using KitapSecKayitSistemiRepo.Data;
using KitapSecKayitSistemiRepo.Models;
using KitapSecKayitSistemiRepo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Service
{
    public class BookService : IBook
    {
        public readonly AppDbContext db;
        public BookService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddBook(Books book)
        {
            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();
            return book.BookId;

        }

        public async Task<bool> DeleteBook(Books book)
        {

            bool status = false;
            if (book != null)
            {
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                status = true;
            }

            return status;
        }

        public async Task<IEnumerable<Books>> GetBook()
        {
            var result = await db.Books.ToListAsync();
            return result;
        }

        public async Task<Books> GetBookById(int id)
        {
            var result = await db.Books.Where(i => i.BookId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateBook(Books book)
        {

            bool status = false;
            if (book != null)
            {
                db.Books.Update(book);
                await db.SaveChangesAsync();
                status = true;
            }
            return status;

        }
    }
}
