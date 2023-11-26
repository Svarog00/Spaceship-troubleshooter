using Assets._Project.Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI
{
    public class UI_ShipHealthBar : MonoBehaviour
    {
        [SerializeField] private GameObject _healthSource;
        [SerializeField] private Image _healthBarImage;

        private float _maxValue;

        // Start is called before the first frame update
        void Start()
        {
            _maxValue = _healthSource.GetComponent<IHealth>().Health;
            _healthBarImage.fillAmount = _maxValue / 100;

            _healthSource.GetComponent<IHealth>().OnHealthChangedEventHandler += HealthSource_OnHealthChangedEventHandler;
        }

        private void HealthSource_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
        {
            _healthBarImage.fillAmount = e.CurrentHealth / _maxValue;
        }
    }
}