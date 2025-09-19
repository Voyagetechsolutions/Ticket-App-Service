using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Ticket_App_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<EventDto> GetEvents(string sortBy = "Title");

        [OperationContract]
        EventDto GetEventById(int eventId);

        [OperationContract]
        bool AddEvent(EventDto eventDto);

        [OperationContract]
        bool EditEvent(EventDto eventDto);

        [OperationContract]
        bool DeleteEvent(int eventId);

        [OperationContract]
        bool AddToCart(int userId, int eventId, int ticketTypeId, int quantity);

        [OperationContract]
        bool RemoveFromCart(int userId, int cartItemId);

        [OperationContract]
        bool UpdateCartItem(int userId, int cartItemId, int quantity);

        [OperationContract]
        List<CartItemDto> GetCartItems(int userId);

        [OperationContract]
        InvoiceDto Checkout(int userId);

        [OperationContract]
        List<InvoiceDto> GetInvoicesByUser(int userId);

        [OperationContract]
        bool RegisterUser(UserDto userDto);

        [OperationContract]
        UserDto Login(string username, string password);

        [OperationContract]
        ReportDto GetSalesReport(DateTime startDate, DateTime endDate);

        [OperationContract]
        List<PromotionDto> GetPromotionsForEvent(int eventId);
    }

    [Serializable]
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int TotalTickets { get; set; }
        public int AvailableTickets { get; set; }
        public string EventImageUrl { get; set; }
    }

    [Serializable]
    public class CartItemDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int TicketTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string EventTitle { get; set; }
    }

    [Serializable]
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FinalPayment { get; set; }
        public string PaymentMethod { get; set; }
    }

    [Serializable]
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string ProfileImageUrl { get; set; }
    }

    [Serializable]
    public class PromotionDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string PromoDescription { get; set; }
        public string PromoType { get; set; }
        public decimal PromoValue { get; set; }
        public bool IsActive { get; set; }
    }

    [Serializable]
    public class ReportDto
    {
        public int ProductsSold { get; set; }
        public int ProductsOnHand { get; set; }
        public int RegisteredUsers { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalDiscounts { get; set; }
        public decimal TotalTax { get; set; }
    }
}
