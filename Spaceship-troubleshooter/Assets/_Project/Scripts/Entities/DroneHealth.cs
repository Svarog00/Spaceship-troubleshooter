using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Scripts.Entities
{
    public class DroneHealth : IHealth
    {
        public event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

        private int _maxHealth;
        private int _curHealth;

        public DroneHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
            _curHealth = _maxHealth;
        }

        public void Heal(int damage)
        {
            _curHealth += damage;
            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _curHealth });
        }

        public void Hurt(int damage)
        {
            _curHealth -= damage;
            OnHealthChangedEventHandler?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _curHealth });
        }
    }
}
