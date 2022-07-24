namespace Controllers.ApiModels
{
	//public record BookDto(int id, string ISBN, string Title, string Author);

	public class BookDto
	{
		public int Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }

        public BookDto()
        {
        }

        public BookDto(int id, string iSBN, string title, string author)
        {
            Id = id;
            ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }
    }
}


