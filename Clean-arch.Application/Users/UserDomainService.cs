using Clean_arch.Domain.UserAgg;

namespace Clean_arch.Application.Users;

public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _repository;
    public UserDomainService(IUserRepository repository)
    {
        _repository = repository;
    }

    public bool EmailIsExist(string email)
    {
        return _repository.UserIsExist(email);
    }
}