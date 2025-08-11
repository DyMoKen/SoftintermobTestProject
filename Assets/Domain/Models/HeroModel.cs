using R3;

namespace Domain.Models
{
    public class HeroModel
    {
        public string Name { get; }
        
        public ReactiveProperty<int> Level { get; }
        public ReactiveProperty<int> Power { get; }

        public HeroModel(string name, int level, int power)
        {
            Name = name;
            Level = new ReactiveProperty<int>(level);
            Power = new ReactiveProperty<int>(power);
        }

        public void Upgrade()
        {
            Level.Value += 1;
            Power.Value += 10;
        }
    }
}
