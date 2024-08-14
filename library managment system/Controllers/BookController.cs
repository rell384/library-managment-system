using library_managment_system.Models;
using library_managment_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace library_managment_system.Controllers
{
    public class BookController : Controller
    {
        IPersonRepo _PersonRepo;
        IBookRepo _BookRepo;
        IBorrow _Borrow;
        public BookController(IPersonRepo PersonRepo ,IBookRepo BookRepo , IBorrow iborrow)
        {
            _PersonRepo = PersonRepo;
            _BookRepo = BookRepo;
            _Borrow = iborrow;
        }

        // GET: Book/AllBooks
        [HttpGet]
        public ActionResult AllBooks()
        {
            var books = _BookRepo.GetAll(); // Assuming you have a method to get all books in your repository
            return View(books);
        }

        // GET: Book/AddBook
        [HttpGet]
        public ActionResult AddBook()
        {
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            ViewBag.Images = Directory.GetFiles(imagesPath).Select(Path.GetFileName).ToList();
            return View();
        }


        // POST: Book/AddBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBook(Book model)
        {
            // Ensure the model is valid and the book name is provided
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.Name))
            {
                // Construct the image path based on the selected image filename
                var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                var imagePath = Path.Combine(imagesDirectory, model.Image);

                // Check if the image file exists in the specified path
                if (System.IO.File.Exists(imagePath))
                {
                    // Create a new book object with the provided details
                    Book book = new Book
                    {
                        Name = model.Name,
                        Image = model.Image, // Use the provided image name from the model
                        TotalCopies = model.TotalCopies,
                        AvailableCopies = model.TotalCopies // Initialize AvailableCopies to match TotalCopies
                    };

                    // Insert the new book into the repository
                    _BookRepo.Insert(book);

                    // Redirect to the Home index page upon successful insertion
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Image file does not exist, return to the view with an error message
                    ModelState.AddModelError("Image", "The selected image does not exist.");
                }
            }

            // If model validation fails or image doesn't exist, reload the image list for the dropdown
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            ViewBag.Images = Directory.GetFiles(imagesPath).Select(Path.GetFileName).ToList();

            // Return to the AddBook view with the current model
            return View("AddBook", model);
        }



        // GET: Book/BorrowBook
        [HttpGet]
            public ActionResult BorrowBook()
        {
            return View();
        }

        // POST: Book/BorrowBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrowBook(string code, string bookName)
        {
            try
            {
                _Borrow.BorrowBook(code, bookName);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public ActionResult ReturnBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnBook(string code, string bookName)
        {
            try
            {
                _Borrow.ReturnBook(code, bookName);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
