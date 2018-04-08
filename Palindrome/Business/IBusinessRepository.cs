using System.Collections.Generic;

namespace Palindrome.Business
{
    public interface IBusinessRepository<T>
    {
        void CreateNew(T ViewModel);
        List<T> FetchExistingRecords();
    }
}