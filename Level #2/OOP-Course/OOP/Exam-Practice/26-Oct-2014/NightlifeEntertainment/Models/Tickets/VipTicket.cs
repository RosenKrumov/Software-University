namespace NightlifeEntertainment.Models.Tickets
{
    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance) 
            : base(performance, TicketType.VIP)
        {
        }
    }
}
