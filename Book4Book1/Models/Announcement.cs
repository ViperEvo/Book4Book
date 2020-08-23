namespace Book4Book1.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public int BookId { get; }
        public int UserId { get; }

        public Announcement(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}