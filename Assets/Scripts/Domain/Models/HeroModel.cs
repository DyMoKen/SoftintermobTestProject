using R3;

namespace Domain.Models
{
    public class HeroModel
    {
        public string Name { get; }
        
        public ReactiveProperty<int> Level { get; }
        public ReactiveProperty<int> Power { get; }
        public ReactiveProperty<int> Strength { get; }
        public ReactiveProperty<int> Dexterity { get; }
        public ReactiveProperty<int> Intelligence { get; }
        
        public HeroModel(string name, int level, int power, int strength, int dexterity, int intelligence)
        {
            Name = name;
            Level = new ReactiveProperty<int>(level);
            Power = new ReactiveProperty<int>(power);
            Strength = new ReactiveProperty<int>(strength);
            Dexterity = new ReactiveProperty<int>(dexterity);
            Intelligence = new ReactiveProperty<int>(intelligence);
        }

        public void Upgrade()
        {
            Level.Value += 1;
            Power.Value += 10;
            Strength.Value += 1;
            Dexterity.Value += 1;
            Intelligence.Value += 1;
        }
    }
}
