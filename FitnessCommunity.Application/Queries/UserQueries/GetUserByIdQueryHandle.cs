using AutoMapper;
using FitnessCommunity.Application.Dtos.UserDtos.Responses;
using FitnessCommunity.Domain.Exceptions.UserExceptions;
using FitnessCommunity.Domain.Repositories;
using MediatR;

namespace FitnessCommunity.Application.Queries.UserQueries
{
    public class GetUserByIdQueryHandle : IRequestHandler<GetUserByIdQuery, GetUserDetailsByIdResponse>
    {
        private readonly IUserRepository _userService;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandle(IUserRepository userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<GetUserDetailsByIdResponse> Handle(GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException(request.Id);
            }
            return _mapper.Map<GetUserDetailsByIdResponse>(user);
        }
    }
}
