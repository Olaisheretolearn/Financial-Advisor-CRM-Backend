using System.Runtime.CompilerServices;

namespace FinCRM.Domain
{
    public class Note
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;


        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;


        public DateTimeOffset CreatedAt { get; set; }


        public string NoteText { get; set; } = null!;
        public NoteType NoteType { get; set; }

    }

    public enum NoteType
    {
        Call,
        Meeting,
        Email
    }
}
