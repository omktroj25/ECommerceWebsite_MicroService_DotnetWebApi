using Entity.Data;
using Entity.Dto;
using Contract.IRepository;
using Contract.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Entity.Model;
using NLog;

namespace Repository
{
    public class UserMicroServiceRepository
    {
        private ApiDbContext context;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;

        public UserMicroServiceRepository(ApiDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        //Validate email number conflict
        public bool ValidateUsernameConflict(string username)
        {
            return context.Users.Any(u => u.UserName == username && u.IsActive == true);
        }

        //Validate email number conflict
        public bool ValidateEmailConflict(string email)
        {
            return context.Users.Any(e => e.EmailAddress == email && e.IsActive == true);
        }

        //Validate phone number conflict
        public bool ValidatePhoneConflict(string phone)
        {
            return context.Users.Any(p => p.PhoneNumber == phone && p.IsActive == true);
        }

        //Validate the userId in the database
        public bool ValidateUserById(Guid userId)
        {
            return context.Users.Any(u => u.Id == userId && u.IsActive == true);
        }

        // Validate whethet the upi payment method already exist in the database or not
        public bool PaymentConflict(Guid userId, string paymentType)
        {
            return context.Payments.Any(p => p.UserId == userId && p.PaymentType == paymentType && p.IsActive == true);
        }

        // Validate upiId conflict
        public bool ValidateUpiConflict(string upiId)
        {
            return context.UpiPayments.Any(p => p.UpiId == upiId && p.IsActive == true);
        }

        // validate card number conflict
        public bool ValidateCardConflict(string cardNumber)
        {
            return context.CardPayments.Any(p => p.CardNumber == cardNumber && p.IsActive == true);
        }

        //To create new user account in database
        public bool CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        //To create new user account in database
        public bool CreateAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return true;
        }

        // To Create new upi payment for the user in the database
        public bool CreateUpiPayment(Payment payment, UpiPayment upi)
        {
            context.Payments.Add(payment);
            context.UpiPayments.Add(upi);
            context.SaveChanges();
            return true;
        }

        // To Create new card payment for the user in the database
        public bool CreateCardPayment(Payment payment, CardPayment card)
        {
            context.Payments.Add(payment);
            context.CardPayments.Add(card);
            context.SaveChanges();
            return true;
        }

        //Get user details with respect to username or email address or phone number
        public User? GetUserByInput(string input)
        {
            return context.Users.FirstOrDefault(u => u.UserName == input || u.EmailAddress == input || u.PhoneNumber == input && u.IsActive == true);
        }
        
        // To Get address details from the database by using the address and user id
        public Address? GetAddressById(Guid userId, Guid addressId)
        {
            return context.Addresses.FirstOrDefault(a => a.UserId == userId && a.Id == addressId && a.IsActive == true);
        }

        // To Get the payment details by using the payment and user id
        public Payment? GetPaymentById(Guid userId, Guid paymentId)
        {
            return context.Payments.FirstOrDefault(p => p.UserId == userId && p.Id == paymentId && p.IsActive == true);
        }

        // To Get the upi payment details by using the payment type id
        public UpiPayment? GetUpiById(Guid paymentTypeId)
        {
            return context.UpiPayments.FirstOrDefault(p => p.PaymentTypeId == paymentTypeId && p.IsActive == true);
        }

        // To Get the card payment details by using the payment type id
        public CardPayment? GetCardById(Guid paymentTypeId)
        {
            return context.CardPayments.FirstOrDefault(p => p.PaymentTypeId == paymentTypeId && p.IsActive == true);
        }

        // To update the information of the address
        public bool SaveAddress(Address address)
        {   
            context.Addresses.Update(address);
            context.SaveChanges();
            return true;
        }

        // To update the information of the upi payment
        public bool SaveUpiPayment(UpiPayment upiPayment)
        {   
            context.UpiPayments.Update(upiPayment);
            context.SaveChanges();
            return true;
        }

        // To update the information of the card payment
        public bool SaveCardPayment(CardPayment cardPayment)
        {   
            context.CardPayments.Update(cardPayment);
            context.SaveChanges();
            return true;
        }


    }
}