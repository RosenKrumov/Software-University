namespace NightlifeEntertainment.Models.Tickets
{
    public class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance) 
            : base(performance, TicketType.Student)
        {
        }
    }
}
