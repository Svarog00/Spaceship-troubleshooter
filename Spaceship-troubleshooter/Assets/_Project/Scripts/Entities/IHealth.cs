using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShipConditionController;

namespace Assets._Project.Scripts.Entities
{
    public class OnHealthChangedEventArgs
    {
        public float CurrentHealth;
    }

    public interface IHealth
    {
        event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

        float Health { get; }

        void Heal(float damage);
        void Hurt(float damage);
    }
}
