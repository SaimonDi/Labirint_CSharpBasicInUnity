using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class RadarObj : MonoBehaviour
        {
        [SerializeField] private Image _ico;
        private void OnValidate()
            {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
            }
        private void OnDisable()
            {
            DisplayRadar.RemoveRadarObject(gameObject);
            }
        private void OnEnable()
            {
            DisplayRadar.RegisterRadarObject(gameObject, _ico);
            }
        }
    }
