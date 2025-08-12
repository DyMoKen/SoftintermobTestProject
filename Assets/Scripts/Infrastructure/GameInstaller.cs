using Application.Messages;
using Application.UseCases;
using Domain.Models;
using MessagePipe;
using Presentation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private HeroPresenter _heroPresenter;
        [SerializeField] private HeroConfig _heroConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<HeroUpgradeMessage>(options);

            var hero = new HeroModel(_heroConfig);
            
            builder.RegisterInstance(hero);
            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton);

            builder.RegisterComponent(_heroPresenter);
            
            builder.RegisterBuildCallback(container =>
            {
                var presenter = container.Resolve<HeroPresenter>();
                presenter.Construct(
                    hero,
                    container.Resolve<UpgradeHeroUseCase>(),
                    container.Resolve<ISubscriber<HeroUpgradeMessage>>());
            });
        }
    }
}