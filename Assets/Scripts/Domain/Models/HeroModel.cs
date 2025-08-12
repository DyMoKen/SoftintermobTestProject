using R3;

namespace Domain.Models
{
    public class HeroModel
    {
        public string Name { get; }
        
        public ReactiveProperty<int> Level { get; }
        public ReactiveProperty<int> Power { get; }
        public ReactiveProperty<int> Health { get; }
        public ReactiveProperty<int> Strength { get; }
        public ReactiveProperty<int> Dexterity { get; }
        public ReactiveProperty<int> Intelligence { get; }
        
        public HeroModel(string name, int level, int power, int health, int strength, int dexterity, int intelligence)
        {
            Name = name;
            Level = new ReactiveProperty<int>(level);
            Power = new ReactiveProperty<int>(power);
            Health = new ReactiveProperty<int>(health);
            Strength = new ReactiveProperty<int>(strength);
            Dexterity = new ReactiveProperty<int>(dexterity);
            Intelligence = new ReactiveProperty<int>(intelligence);
        }

        public HeroModel(HeroConfig config)
        {
            Name = config.Name;
            Level = new ReactiveProperty<int>(config.Level);
            Power = new ReactiveProperty<int>(config.Power);
            Health = new ReactiveProperty<int>(config.HealthPoints);
            Strength = new ReactiveProperty<int>(config.Strength);
            Dexterity = new ReactiveProperty<int>(config.Dexterity);
            Intelligence = new ReactiveProperty<int>(config.Intelligence);
        }
        
        public void Upgrade()
        {
            Level.Value += 1;
            Power.Value += 10;
            Health.Value += 25;
            Strength.Value += 1;
            Dexterity.Value += 1;
            Intelligence.Value += 1;
        }
    }
}
