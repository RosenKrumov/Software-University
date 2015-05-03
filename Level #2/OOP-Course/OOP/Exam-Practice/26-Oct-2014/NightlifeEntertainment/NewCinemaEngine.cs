using System;
using System.Text;
using NightlifeEntertainment.Models.Performances;
using NightlifeEntertainment.Models.Tickets;

namespace NightlifeEntertainment
{
    public class NewCinemaEngine : CinemaEngine
    {
        private StringBuilder output;

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            var venue = commandWords[2];
            switch (venue)
            {
                case "opera":
                    var opera = new Opera(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
            
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var performance = commandWords[2];
            var venue = this.GetVenue(commandWords[5]);
            switch (performance)
            {
                case "theatre":
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellTicketCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var type = (TicketType)Enum.Parse(typeof(TicketType), commandWords[2], true);
            this.output.Append(performance.SellTicket(type));
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;

                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }

                    break;

                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }
    }
}
