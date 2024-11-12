using UnityEngine;

namespace Project.Scripts.Utils
{
    public class Buff : MonoBehaviour
    {
        private OnTriggers _onTriggers;
        private void Start()
        {
            _onTriggers = FindObjectOfType<OnTriggers>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_onTriggers.hp == 100) return;
            _onTriggers.hp += 20;
            _onTriggers.hptext.text = _onTriggers.hp + "";
        }
    }
}
