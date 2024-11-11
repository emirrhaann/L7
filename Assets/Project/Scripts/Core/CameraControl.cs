using Project.Scripts.Utils;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class CameraControl : MonoBehaviour
    {
        public Vector3 aradakifark;
        [SerializeField]private OnTriggers _onTriggers;
        [SerializeField]private Camera cam;
        [SerializeField]private PlayerController _playerController;
        // Start is called before the first frame update
        void Start()
        {

            aradakifark = transform.position - _playerController.gameObject.transform.position;
        }

   
        // Update is called once per frame
        void Update()
        {
            if (_onTriggers.gameOver)
            {
                transform.position = _playerController.gameObject.transform.position + aradakifark;
                cam.fieldOfView = 60;
            }
            else
            {
                transform.position = _playerController.gameObject.transform.position + aradakifark;
            }
            if (!_onTriggers.onJoystick || !_onTriggers.gameOver) return;
            {
                
            }
        }
    }
}
