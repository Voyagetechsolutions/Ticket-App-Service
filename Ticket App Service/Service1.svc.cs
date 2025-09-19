using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Ticket_App_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<EventDto> GetEvents(string sortBy = "Title")
        {
            var events = new List<EventDto>
            {
                new EventDto { Id = 1, Title = "Concert", Description = "Live music", EventDate = DateTime.Now.AddDays(10), Location = "Stadium", Price = 100, TotalTickets = 500, AvailableTickets = 200, EventImageUrl = "" },
                new EventDto { Id = 2, Title = "Movie Night", Description = "Outdoor movie", EventDate = DateTime.Now.AddDays(5), Location = "Park", Price = 50, TotalTickets = 300, AvailableTickets = 150, EventImageUrl = "" }
            };
            if (sortBy == "Price")
                return events.OrderBy(e => e.Price).ToList();
            return events.OrderBy(e => e.Title).ToList();
        }

        public EventDto GetEventById(int eventId)
        {
            return GetEvents().FirstOrDefault(e => e.Id == eventId);
        }

        public bool AddEvent(EventDto eventDto)
        {
            return true;
        }

        public bool EditEvent(EventDto eventDto)
        {
            return true;
        }

        public bool DeleteEvent(int eventId)
        {
            return true;
        }

        public bool AddToCart(int userId, int eventId, int ticketTypeId, int quantity)
        {
            return true;
        }

        public bool RemoveFromCart(int userId, int cartItemId)
        {
            return true;
        }

        public bool UpdateCartItem(int userId, int cartItemId, int quantity)
        {
            return true;
        }

        public List<CartItemDto> GetCartItems(int userId)
        {
            return new List<CartItemDto>
            {
                new CartItemDto { Id = 1, EventId = 1, TicketTypeId = 1, Quantity = 2, Price = 100, EventTitle = "Concert" }
            };
        }

        public InvoiceDto Checkout(int userId)
        {
            return new InvoiceDto { Id = 1, InvoiceNo = "INV001", IssuedDate = DateTime.Now, TotalAmount = 200, FinalPayment = 180, PaymentMethod = "Card" };
        }

        public List<InvoiceDto> GetInvoicesByUser(int userId)
        {
            return new List<InvoiceDto>
            {
                new InvoiceDto { Id = 1, InvoiceNo = "INV001", IssuedDate = DateTime.Now, TotalAmount = 200, FinalPayment = 180, PaymentMethod = "Card" }
            };
        }

        public bool RegisterUser(UserDto userDto)
        {
            return true;
        }

        public UserDto Login(string username, string password)
        {
            return new UserDto { Id = 1, Username = username, Email = "user@example.com", RoleId = 1 };
        }

        public ReportDto GetSalesReport(DateTime startDate, DateTime endDate)
        {
            return new ReportDto
            {
                ProductsSold = 20,
                ProductsOnHand = 100,
                RegisteredUsers = 50,
                TotalSales = 5000,
                TotalDiscounts = 500,
                TotalTax = 700
            };
        }

        public List<PromotionDto> GetPromotionsForEvent(int eventId)
        {
            return new List<PromotionDto>
            {
                new PromotionDto { Id = 1, Code = "DISCOUNT10", PromoDescription = "10% off", PromoType = "Percent", PromoValue = 10, IsActive = true }
            };
        }
    }
}
