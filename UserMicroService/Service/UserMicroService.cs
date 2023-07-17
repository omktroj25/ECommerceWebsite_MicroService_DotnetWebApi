using Entity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository;
using AutoMapper;
using Contract.IRepository;
using Contract.IService;
using Entity.Dto;
using Exception;
using Entity.Model;
using NLog;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Service
{
    public class UserMicroService
    {
        private readonly UserMicroServiceRepository userMicroServiceRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public UserMicroService(UserMicroServiceRepository _userMicroServiceRepository, IConfiguration _config, IMapper _mapper)
        {
            config = _config;
            mapper = _mapper;
            userMicroServiceRepository = _userMicroServiceRepository;
        }



        // Validate the user input in the registerDto
        private bool ValidateRegisterDto(RegisterDto registerDto)
        {
            if(userMicroServiceRepository.ValidateUsernameConflict(registerDto.UserName))
            {
                throw new BaseCustomException(409, "User name already exists", "Username already taken. Please choose a different username");
            }
            if(userMicroServiceRepository.ValidatePhoneConflict(registerDto.PhoneNumber))
            {
                throw new BaseCustomException(409, "Phone number already exists", "Phone number already taken. Please choose a different phone number");
            }
            if(userMicroServiceRepository.ValidateEmailConflict(registerDto.EmailAddress))
            {
                throw new BaseCustomException(409, "Email address already exists", "Email id already taken. Please choose a different email address");
            }
            return true;
        }

        //Hash password to store in database
        private string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // User registration service
        public ResponseIdDto RegisterUserService(RegisterDto registerDto)
        {
            Guid userId = Guid.NewGuid();
            registerDto.Id = Guid.NewGuid();
            registerDto.UserId = userId;
            registerDto.CreatedBy = userId;
            registerDto.CreatedOn = DateTime.UtcNow;
            if(ValidateRegisterDto(registerDto))
            {
                registerDto.Password = ComputeHash(registerDto.Password);
                User user = mapper.Map<User>(registerDto);
                if(userMicroServiceRepository.CreateUser(user))
                {
                    ResponseIdDto responseIdDto = new ResponseIdDto()
                    {
                        Id = userId,
                        Message = "User registered successfully. Go to login page for login"
                    };
                    return responseIdDto;
                }
            }
            throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
        }



        //Validate user name and password
        public User ValidateUser(LoginDto loginDto)
        {
            string hashedPasswordEntered = ComputeHash(loginDto.Password);
            User? user = userMicroServiceRepository.GetUserByInput(loginDto.UserName);
            if (user == null)
            {
                throw new BaseCustomException(401, "Unauthorized access", "Invalid user name. Please check your login details and try again");
            }
            if (user.Password == hashedPasswordEntered && loginDto.UserName == user.UserName || loginDto.UserName == user.EmailAddress || loginDto.UserName == user.PhoneNumber)
            {
                return user;
            }
            throw new BaseCustomException(401, "Unauthorized access", "Invalid password. Please check your login details and try again");
        }

        //Generate JWT token with expire and claims to login
        public TokenResponseDto GenerateTokenService(LoginDto loginDto)
        {
            User user = ValidateUser(loginDto);
            
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Jwt:Key"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim("NameId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"], claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            TokenResponseDto tokenResponseDto = new TokenResponseDto
            {
                TokenType = "Bearer Token",
                AccessToken = tokenString,
            };

            return tokenResponseDto;
        }



        // Add new address to the user
        public ResponseIdDto AddAddressService(Guid userId, AddressDto addressDto)
        {
            Guid id = Guid.NewGuid();
            addressDto.Id = id;
            addressDto.UserId = userId;
            addressDto.CreatedBy = userId;
            addressDto.CreatedOn = DateTime.UtcNow;
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                Address address = mapper.Map<Address>(addressDto);
                if(userMicroServiceRepository.CreateAddress(address))
                {
                    ResponseIdDto responseIdDto = new ResponseIdDto()
                    {
                        Id = id,
                        Message = "New address created successfully"
                    };
                    return responseIdDto;
                }
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }




        // Add new payment to the user
        public ResponseIdDto AddPaymentService(Guid userId, PaymentDto paymentDto)
        {
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                if(!userMicroServiceRepository.PaymentConflict(userId, paymentDto.PaymentType))
                {
                    Guid id = Guid.NewGuid();
                    paymentDto.Id = id;
                    paymentDto.UserId = userId;
                    paymentDto.CreatedBy = userId;
                    paymentDto.CreatedOn = DateTime.UtcNow;
                    if(paymentDto.PaymentType == "UPI")
                    {
                        if(!userMicroServiceRepository.ValidateUpiConflict(paymentDto.UpiId))
                        {
                            Payment payment = mapper.Map<Payment>(paymentDto);
                            UpiPayment upi = mapper.Map<UpiPayment>(paymentDto);
                            upi.Id = Guid.NewGuid();
                            if(userMicroServiceRepository.CreateUpiPayment(payment,upi))
                            {
                                ResponseIdDto responseIdDto = new ResponseIdDto()
                                {
                                    Id = id,
                                    Message = "New UPI payment created successfully"
                                };
                                return responseIdDto;
                            }
                        }
                    }
                    else if(paymentDto.PaymentType == "CARD")
                    {
                        if(!userMicroServiceRepository.ValidateCardConflict(paymentDto.CardNumber))
                        {
                            Payment payment = mapper.Map<Payment>(paymentDto);
                            CardPayment card = mapper.Map<CardPayment>(paymentDto);
                            card.Id = Guid.NewGuid();
                            if(userMicroServiceRepository.CreateCardPayment(payment,card))
                            {
                                ResponseIdDto responseIdDto = new ResponseIdDto()
                                {
                                    Id = id,
                                    Message = "New CARD payment created successfully"
                                };
                                return responseIdDto;
                            }
                        }
                    }
                    throw new BaseCustomException(400, "Invalid payment type", "The payment type should be UPI or DEBIT/CARD or CREDIT/CARD");
                }
                throw new BaseCustomException(409, "Payment type already exist", "Try different payment method");
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }



        // To Update address details of the user
        public ResponseDto UpdateAddressService(Guid addressId, Guid userId, AddressDto addressDto)
        {
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                Address? address = userMicroServiceRepository.GetAddressById(userId, addressId);
                if(address != null)
                {
                    addressDto.Id = address.Id;
                    addressDto.UserId = userId;
                    addressDto.CreatedBy = address.CreatedBy;
                    addressDto.CreatedOn = address.CreatedOn;
                    address = mapper.Map<Address>(addressDto);
                    if(userMicroServiceRepository.SaveAddress(address))
                    {
                        ResponseDto responseDto = new ResponseDto()
                        {
                            StatusCode = 200,
                            Message = "Address updated successfully",
                            Description = "The user address is updated in the database"
                        };
                        return responseDto;
                    }
                    throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                }
                throw new BaseCustomException(404, "Address not found", "Address id doesn't exist in the database");
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }



        // To Update payment details of the user
        public ResponseDto UpdatePaymentService(Guid paymentId, Guid userId, PaymentDto paymentDto)
        {
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                Payment? payment = userMicroServiceRepository.GetPaymentById(userId, paymentId);
                if(payment != null)
                {
                    if(payment.PaymentType == "UPI")
                    {
                        UpiPayment? upiPayment = userMicroServiceRepository.GetUpiById(payment.Id);
                        if(upiPayment != null)
                        {
                            paymentDto.Id = upiPayment.Id;
                            paymentDto.UserId = userId;
                            paymentDto.CreatedBy = upiPayment.CreatedBy;
                            paymentDto.CreatedOn = upiPayment.CreatedOn;
                            upiPayment = mapper.Map<UpiPayment>(paymentDto);
                            if(userMicroServiceRepository.SaveUpiPayment(upiPayment))
                            {
                                ResponseDto responseDto = new ResponseDto()
                                {
                                    StatusCode = 200,
                                    Message = "Upi payment updated successfully",
                                    Description = "The user upi payment is updated in the database"
                                };
                                return responseDto;
                            }
                            throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                        }
                        throw new BaseCustomException(404, "Upi payment details not found", "Upi payment id doesn't exist in the database");
                    }
                    else if(payment.PaymentType == "CARD")
                    {
                        CardPayment? cardPayment = userMicroServiceRepository.GetCardById(payment.Id);
                        if(cardPayment != null)
                        {
                            paymentDto.Id = cardPayment.Id;
                            paymentDto.UserId = userId;
                            paymentDto.CreatedBy = cardPayment.CreatedBy;
                            paymentDto.CreatedOn = cardPayment.CreatedOn;
                            cardPayment = mapper.Map<CardPayment>(paymentDto);
                            if(userMicroServiceRepository.SaveCardPayment(cardPayment))
                            {
                                ResponseDto responseDto = new ResponseDto()
                                {
                                    StatusCode = 200,
                                    Message = "Card payment updated successfully",
                                    Description = "The user card payment is updated in the database"
                                };
                                return responseDto;
                            }
                            throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                        }
                        throw new BaseCustomException(404, "Upi payment details not found", "Upi payment id doesn't exist in the database");
                    }
                }
                throw new BaseCustomException(404, "Payment not found", "Payment id doesn't exist in the database");
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }



        // To Delete the address details from the database
        public ResponseDto DeleteAddressService(Guid addressId, Guid userId)
        {
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                Address? address = userMicroServiceRepository.GetAddressById(userId, addressId);
                if(address != null)
                {
                    address.IsActive = false;
                    address.UpdatedBy = userId;
                    address.UpdatedOn = DateTime.UtcNow;
                    if(userMicroServiceRepository.SaveAddress(address))
                    {
                        ResponseDto responseDto = new ResponseDto()
                        {
                            StatusCode = 200,
                            Message = "Address deleted successfully",
                            Description = "The user address is deleted in the database"
                        };
                        return responseDto;
                    }
                    throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                }
                throw new BaseCustomException(404, "Address not found", "Address id doesn't exist in the database");
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }




        // To Delete the payment details in the database
        public ResponseDto DeletePaymentService(Guid paymentId, Guid userId)
        {
            if(userMicroServiceRepository.ValidateUserById(userId))
            {
                Payment? payment = userMicroServiceRepository.GetPaymentById(userId, paymentId);
                if(payment != null)
                {
                    if(payment.PaymentType == "UPI")
                    {
                        UpiPayment? upiPayment = userMicroServiceRepository.GetUpiById(payment.Id);
                        if(upiPayment != null)
                        {
                            upiPayment.IsActive = false;
                            upiPayment.UpdatedBy = userId;
                            upiPayment.UpdatedOn = DateTime.UtcNow;
                            if(userMicroServiceRepository.SaveUpiPayment(upiPayment))
                            {
                                ResponseDto responseDto = new ResponseDto()
                                {
                                    StatusCode = 200,
                                    Message = "Upi payment deleted successfully",
                                    Description = "The user upi payment is deleted in the database"
                                };
                                return responseDto;
                            }
                            throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                        }
                        throw new BaseCustomException(404, "Upi payment details not found", "Upi payment id doesn't exist in the database");
                    }
                    else if(payment.PaymentType == "CARD")
                    {
                        CardPayment? cardPayment = userMicroServiceRepository.GetCardById(payment.Id);
                        if(cardPayment != null)
                        {
                            cardPayment.IsActive = false;
                            cardPayment.UpdatedBy = userId;
                            cardPayment.UpdatedOn = DateTime.UtcNow;
                            if(userMicroServiceRepository.SaveCardPayment(cardPayment))
                            {
                                ResponseDto responseDto = new ResponseDto()
                                {
                                    StatusCode = 200,
                                    Message = "Card payment deleted successfully",
                                    Description = "The user card payment is deleted in the database"
                                };
                                return responseDto;
                            }
                            throw new BaseCustomException(500, "Internal server error", "Error occured while processing your request. Please try again later");
                        }
                        throw new BaseCustomException(404, "Upi payment details not found", "Upi payment id doesn't exist in the database");
                    }
                }
                throw new BaseCustomException(404, "Payment not found", "Payment id doesn't exist in the database");
            }
            throw new BaseCustomException(404, "User not found", "User id doesn't exist in the database");
        }
        
    }
}