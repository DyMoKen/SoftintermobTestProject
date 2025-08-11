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

        [Header("Hero details")]
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _power;
        [SerializeField] private int _strength;
        [SerializeField] private int _dexterity;
        [SerializeField] private int _intelligence;
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<HeroUpgradeMessage>(options);

            var hero = new HeroModel(_name, _level, _power, _strength, _dexterity, _intelligence);
            
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