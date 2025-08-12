using UnityEngine;

namespace Domain.Models
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Configs/HeroConfig", order = 0)]
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private int _healthPoints;
        [SerializeField] private int _power;
        [SerializeField] private int _strength;
        [SerializeField] private int _dexterity;
        [SerializeField] private int _intelligence;

        public string Name => _name;
        public int Level => _level;
        public int HealthPoints => _healthPoints;
        public int Power => _power;
        public int Strength => _strength;
        public int Dexterity => _dexterity;
        public int Intelligence => _intelligence;
    }
}