using Application.Messages;
using Domain.Models;
using MessagePipe;

namespace Application.UseCases
{
    public class UpgradeHeroUseCase
    {
        private readonly HeroModel _hero;
        private readonly IPublisher<HeroUpgradeMessage> _publisher;

        public UpgradeHeroUseCase(HeroModel hero, IPublisher<HeroUpgradeMessage> publisher)
        {
            _hero = hero;
            _publisher = publisher;
        }

        public void Execute()
        {
            _hero.Upgrade();
            _publisher.Publish(new HeroUpgradeMessage());
        }
    }
}
