using Book4Book1.Database;
using Book4Book1.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Book4BookTests
{
    public class Tests
    {
        private static LocalDatabase localDatabase;
        private readonly string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "database.sqlite");

        User user1;
        User user2;
        Author author1;
        Author author2;
        Book book1;
        Book book2;
        Announcement announcement1;
        Announcement announcement2;

        [SetUp]
        public void Setup()
        {
            localDatabase = new LocalDatabase();

            user1 = new User("Dominik", "Toczek", "dominiktoczek@interia.pl", "DominikT", "DominikPass");
            user2 = new User("Arkadiusz", "Szupryczynski", "arkadiuszszupryczynski@gmail.com.pl", "ArkadiuszSz", "ArkadiuszPass");
            
            author1 = new Author("Henryk", "Sienkiewicz", new DateTime(1846, 5, 5), "male");
            author2 = new Author("Agatha", "Christie", new DateTime(1890, 9, 15).Date, "female");

            book1 = new Book("Krzyzacy", "Historyczna", "Opis", author1.AuthorId);
            book2 = new Book("Murder on the Orient Express", "Kryminal", "Opis", author2.AuthorId);

            announcement1 = new Announcement("2020/09/05", "Krakow", "Historyczna", "Krzyzacy", "Henryk Sienkiewicz", "Opis");
            announcement2 = new Announcement("2020/09/15", "Warszawa", "Kryminal", "Murder on the Orient Express", "Agatha Christie", "Opis");
        }

        [TearDown]
        public void TearDown()
        {
            localDatabase.CloseConnection();

            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
        }

        [Test]
        public void AddUser_NewUser_UserAddedToDatabase()
        {
            localDatabase.AddUser(user1);

            var expected = 1;
            var actual = localDatabase.GetAllUsers().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllUsers_TwoUsersInDatabase_ReturnsCorrectListOfUsers()
        {
            localDatabase.AddUser(user1);
            localDatabase.AddUser(user2);

            var expected = 2;
            var actual = localDatabase.GetAllUsers().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveUser_TwoUsersInDatabase_OneUserRemovedFromDatabase()
        {
            localDatabase.AddUser(user1);
            localDatabase.AddUser(user2);

            localDatabase.RemoveUser(user1);

            var expected = 1;
            var actual = localDatabase.GetAllUsers().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAuthor_NewAuthor_AuthorAddedToDatabase()
        {
            localDatabase.AddAuthor(author1);

            var expected = 1;
            var actual = localDatabase.GetAllAuthors().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllAuthors_TwoAuthorsInDatabase_ReturnsCorrectListOfAuthors()
        {
            localDatabase.AddAuthor(author1);
            localDatabase.AddAuthor(author2);

            var expected = 2;
            var actual = localDatabase.GetAllAuthors().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveAuthor_TwoAuthorsInDatabase_OneAuthorRemovedFromDatabase()
        {
            localDatabase.AddAuthor(author1);
            localDatabase.AddAuthor(author2);

            localDatabase.RemoveAuthor(author1);

            var expected = 1;
            var actual = localDatabase.GetAllAuthors().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddBook_NewBook_BookAddedToDatabase()
        {
            localDatabase.AddBook(book1);

            var expected = 1;
            var actual = localDatabase.GetAllBooks().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllBooks_TwoBooksInDatabase_ReturnsCorrectListOfBooks()
        {
            localDatabase.AddBook(book1);
            localDatabase.AddBook(book2);

            var expected = 2;
            var actual = localDatabase.GetAllBooks().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveBook_TwoBooksInDatabase_OneBookRemovedFromDatabase()
        {
            localDatabase.AddBook(book1);
            localDatabase.AddBook(book2);

            localDatabase.RemoveBook(book1);

            var expected = 1;
            var actual = localDatabase.GetAllBooks().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAnnouncement_NewAnnouncement_AnnouncementAddedToDatabase()
        {
            localDatabase.AddAnnouncement(announcement1);

            var expected = 1;
            var actual = localDatabase.GetAllAnnouncements().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllAnnouncements_TwoAnnouncementsInDatabase_ReturnsCorrectListOfAnnouncements()
        {
            localDatabase.AddAnnouncement(announcement1);
            localDatabase.AddAnnouncement(announcement2);

            var expected = 2;
            var actual = localDatabase.GetAllAnnouncements().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveAnnouncement_TwoAnnouncementsInDatabase_OneAnnouncementRemovedFromDatabase()
        {
            localDatabase.AddAnnouncement(announcement1);
            localDatabase.AddAnnouncement(announcement2);

            localDatabase.RemoveAnnouncement(announcement1);

            var expected = 1;
            var actual = localDatabase.GetAllAnnouncements().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}