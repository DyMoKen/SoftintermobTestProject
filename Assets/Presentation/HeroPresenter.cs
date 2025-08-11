using Application.Messages;
using Application.UseCases;
using Domain.Models;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation
{
    public class HeroPresenter : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;

        private Label _nameLabel;
        private Label _levelLabel;
        private Label _powerLabel;
        private Button _upgradeButton;
        
        private UpgradeHeroUseCase _upgradeHeroUseCase;
        private HeroModel _hero;
        
        private ISubscriber<HeroUpgradeMessage> _upgradedSubscriber;
        private CompositeDisposable _disposables = new();

        public void Construct(HeroModel hero, UpgradeHeroUseCase upgradeHeroUseCase,
            ISubscriber<HeroUpgradeMessage> subscriber)
        {
            _hero = hero;
            _upgradeHeroUseCase = upgradeHeroUseCase;
            _upgradedSubscriber = subscriber;
        }

        private void OnEnable()
        {
            var root = uiDocument.rootVisualElement;
            
            _nameLabel = root.Q<Label>("HeroName");
            _levelLabel = root.Q<Label>("HeroLevel");
            _powerLabel = root.Q<Label>("HeroPower");
            _upgradeButton = root.Q<Button>("HeroUpgradeButton");

            _upgradeButton.clicked += OnUpgradeClicked;

            _nameLabel.text = _hero.Name;
            
            _hero.Level.Subscribe(value => _levelLabel.text = $"Уровень: {value}").AddTo(_disposables);
            _hero.Power.Subscribe(value => _powerLabel.text = $"Сила: {value}").AddTo(_disposables);
            
        }

        private void OnUpgradeClicked()
        {
            _upgradeHeroUseCase.Execute();
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }
    }
}