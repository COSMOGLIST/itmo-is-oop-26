using Application.InfrastructurePort;
using Application.Models;
using Application.PresentationPort;

namespace BuisnessLogic;

public class UserService : IUserService
{
    private readonly IAccountRepository _userRepository;
    private readonly IHistoryRepository _historyRepository;
    private CurrentUserSession _currentUserSession;
    private CurrentRoleSession _currentRoleSession;

    public UserService(IAccountRepository userRepository, CurrentUserSession currentUserSession, IHistoryRepository historyRepository, CurrentRoleSession currentRoleSession)
    {
        _userRepository = userRepository;
        _currentUserSession = currentUserSession;
        _historyRepository = historyRepository;
        _currentRoleSession = currentRoleSession;
    }

    public LogInResult UserLogIn(string number, string pin)
    {
        GetAccountResult getAccountResult = _userRepository.GetUser(number, pin);
        switch (getAccountResult)
        {
            case GetAccountResult.Success success:
                _currentRoleSession.Role = Role.User;
                _currentUserSession.User = success.User;
                return new LogInResult.Success();
            case GetAccountResult.NoSuchUser:
                return new LogInResult.NoSuccess();
            default:
                return new LogInResult.NoSuccess();
        }
    }

    public MoneyOperationResult AddMoney(decimal amountOfMoney)
    {
        if (_currentUserSession.User is not null)
        {
            decimal newAmountOfMoney = _currentUserSession.User.AmountOfMoney + amountOfMoney;
            _userRepository.SetMoney(_currentUserSession.User.Number, newAmountOfMoney);
            _historyRepository.LogHistory(_currentUserSession.User.Number, _currentUserSession.User.AmountOfMoney, newAmountOfMoney);
            _currentUserSession.User.AmountOfMoney = _userRepository.GetBalance(_currentUserSession.User.Number);
            return new MoneyOperationResult.Success();
        }

        return new MoneyOperationResult.NoSuchUser();
    }

    public MoneyOperationResult TakeMoney(decimal amountOfMoney)
    {
        if (_currentUserSession.User is not null)
        {
            if (_currentUserSession.User.AmountOfMoney < amountOfMoney)
            {
                return new MoneyOperationResult.NotEnoughMoney();
            }
            else
            {
                decimal newAmountOfMoney = _currentUserSession.User.AmountOfMoney - amountOfMoney;
                _userRepository.SetMoney(_currentUserSession.User.Number, newAmountOfMoney);
                _historyRepository.LogHistory(_currentUserSession.User.Number, _currentUserSession.User.AmountOfMoney, newAmountOfMoney);
                _currentUserSession.User.AmountOfMoney = _userRepository.GetBalance(_currentUserSession.User.Number);
                return new MoneyOperationResult.Success();
            }
        }

        return new MoneyOperationResult.NoSuchUser();
    }

    public BalanceAskResult GetMoneyAmount()
    {
        if (_currentUserSession.User is not null)
        {
            return new BalanceAskResult.Success(_userRepository.GetBalance(_currentUserSession.User.Number));
        }

        return new BalanceAskResult.NotSuccess();
    }

    public IEnumerable<HistoryElement> GetHistory()
    {
        if (_currentUserSession.User is not null)
        {
            return _historyRepository.GetAccountHistory(_currentUserSession.User.Number);
        }

        return new List<HistoryElement>();
    }
}