//using FluentValidation;
//using YouTube.AspNetCore.API.Tutorial.Basic.Models.Dto.ClientsDto.Dto;

//namespace YouTube.AspNetCore.API.Tutorial.Basic.Validators
//{
//    public class ClientCreateValidator : AbstractValidator<ClientCreateDto>
//    {
//        public ClientCreateValidator()
//        {
//            RuleFor(x => x.Address)
//                .NotEmpty().WithMessage("Client Adress cannot be empty.")
//                .NotNull().WithMessage("Client Adress cannot be null.");

//            RuleFor(x => x.CompanyName)
//                .NotEmpty().WithMessage("Company name cannot be empty.")
//                .NotNull().WithMessage("Company name cannot be null.");

//            RuleFor(x => x.Owner)
//                .NotEmpty().WithMessage("Owner cannot be empty.")
//                .NotNull().WithMessage("Owner cannot be null.");

//            RuleFor(x => x.Phone)
//                .NotEmpty().WithMessage("Phone cannot be empty.")
//                .NotNull().WithMessage("Phone cannot be null.")
//                .MinimumLength(7).WithMessage("Phone number must be at least 7 characters long.");

//        }
//    }
//}
