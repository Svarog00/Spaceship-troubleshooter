using Assets._Project.Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthBarSlider;
        [SerializeField] private IHealth _healthSource;

        // Start is called before the first frame update
        void Start()
        {
            _healthBarSlider.value = _healthBarSlider.maxValue;
            _healthSource.OnHealthChangedEventHandler += _healthSource_OnHealthChangedEventHandler;
        }

        private void _healthSource_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
        {
            _healthBarSlider.value = e.CurrentHealth;
        }

        private void OnDestroy()
        {
            _healthSource.OnHealthChangedEventHandler -= _healthSource_OnHealthChangedEventHandler;
        }
    }
}