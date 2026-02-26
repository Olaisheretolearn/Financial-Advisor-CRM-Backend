namespace FinCRM.Domain
{

    // so we storing this with blob
    public class Document
    {
        public int Id { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;


        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;


        public int UploadedById { get; set; }
        public User UploadedBy { get; set; } = null!;


        public DocumentType DocumentType { get; set; }

        public DateTimeOffset UploadedAt { get; set; }


        public bool IsDeleted { get; set; }
    }

    public enum DocumentType
    {
        Statement,
        Identification,
        Agreement
    }
}