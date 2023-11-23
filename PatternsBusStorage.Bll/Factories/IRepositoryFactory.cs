using PatternsBusStorage.Application.Repositories;

namespace PatternsBusStorage.Bll.Factories;

public interface IRepositoryFactory
{
    IBusRepository CreateBusRepository();

    IUserActionsRepository CreateUserActionsRepository();

    IScheduleRepository CreateScheduleRepository();
}