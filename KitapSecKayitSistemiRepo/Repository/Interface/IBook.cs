using KitapSecKayitSistemiRepo.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitapSecKayitSistemiRepo.Repository.Interface
{
    public interface IBook
    {

        Task<IEnumerable<Books>> GetBook();

        Task<int> AddBook(Books book);
        Task<Books> GetBookById(int id);

        Task<bool> UpdateBook(Books book);

        Task<bool> DeleteBook(Books book);

    }
}
