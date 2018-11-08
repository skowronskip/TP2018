using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ProcessState
    {
        private IBookDao dao;

        public ProcessState(IBookDao dao)
        {
            this.dao = dao;
        }

        public List<Book> GetCurrentLibraryState()
        {
            return dao.GetBooks();
        }
    }
}
