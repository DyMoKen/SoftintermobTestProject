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
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HeroPresenter _heroPresenter;

        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<HeroUpgradeMessage>(options);

            var hero = new HeroModel("Knight", 1, 10);
            
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