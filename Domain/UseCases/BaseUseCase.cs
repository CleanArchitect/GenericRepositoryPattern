namespace Domain.UseCases
{
    public abstract class UseCaseBase
    {
        protected IEventBus EventBus { get; }

        protected UseCaseBase(IEventBus eventBus)
        {
            EventBus = eventBus;
        }
    }
}
