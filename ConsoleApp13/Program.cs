using PracticeLinqJoin;
using System.Runtime.CompilerServices;


// Author türünde bir liste oluşturuyoruz (List<Author>).
var authorList = new List<Author>();

// Listeye Add yöntemi ile yazarları ekliyoruz.
authorList.Add(new Author { AuthorId = 1, Name = "Orhan Pamuk" });
authorList.Add(new Author { AuthorId = 2, Name = "Elif Şafak" });
authorList.Add(new Author { AuthorId = 3, Name = "Ahmet Ümit" });


// Book türünde bir liste oluşturuyoruz (List<Book>).
var bookList = new List<Book>();

// Listeye kitapları Add yöntemi ile ekliyoruz. Her kitap bir yazar kimliğine (AuthorId) bağlıdır.
bookList.Add(new Book { BookId = 1, Title = "Kar", AuthorId = 1 });
bookList.Add(new Book { BookId = 2, Title = "İstanbul", AuthorId = 1 });
bookList.Add(new Book { BookId = 3, Title = "10 Dakika 38 Saniye Bu Tuhaf Duyguda", AuthorId = 2 });
bookList.Add(new Book { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3 });


// LINQ kullanarak yazar ve kitapları birleştiriyoruz.
// Yazar ve kitap listelerindeki AuthorId'ye göre eşleştirme (join) yapılıyor.
var bookAndAuthor = from Author in authorList
                    join Book in bookList
                    on Author.AuthorId equals Book.AuthorId
                    select new
                    {
                        BookTitle = Book.Title, // Kitabın başlığı
                        AuthorName = Author.Name // Yazarın adı
                    };

// Elde edilen yazar-kitap bilgilerini ekrana yazdırıyoruz.
foreach (var item in bookAndAuthor)
{
    // Her bir yazar ve kitabı konsola yazdırıyoruz.
    Console.WriteLine($"Yazar : {item.AuthorName}, Kitabın Başlığı : {item.BookTitle}");
}