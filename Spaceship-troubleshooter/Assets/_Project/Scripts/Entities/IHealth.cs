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
        public int CurrentHealth;
    }

    public interface IHealth
    {
        event EventHandler<OnHealthChangedEventArgs> OnHealthChangedEventHandler;

        void Heal(int damage);
        void Hurt(int damage);
    }
}
