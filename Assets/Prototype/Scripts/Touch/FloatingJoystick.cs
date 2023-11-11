using UnityEngine;

namespace Prototype.Scripts.Touch
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class FloatingJoystick : MonoBehaviour
    {
        [HideInInspector]
        public RectTransform RectTransform;
        public RectTransform Knob;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}
