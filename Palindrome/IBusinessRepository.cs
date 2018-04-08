using System.Collections.Generic;
using System.Linq;

namespace Palindrome
{
    public interface IBusinessRepository<T>
    {
        void CreateNew(T ViewModel);
        List<T> FetchExistingRecords();
    }
}