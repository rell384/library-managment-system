namespace library_managment_system.Repository
{
    public interface IBorrow
    {
        void BorrowBook(string code, string bookName);
        void ReturnBook(string code, string bookName);
    }
}
