﻿namespace LibraryManagement.ViewModel
{
    public class UpdateBookViewModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

        public string? ImageUrl { get; set; }
    }
}
