﻿namespace BookLibrary2.Dto
{
    public class RentBookDto
    {
        public int Id { get; set; }
        public int receipt { get; set; }
        public int bookId { get; set; }
        public int memberId { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime rentDue { get; set; }
    }
}
