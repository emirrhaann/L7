using Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Core
{
    public class CameraControl : MonoBehaviour
    {
        public Vector3 aradakifark;
        [SerializeField]private OnTriggers onTriggers;
        [SerializeField]private Camera cam;
        [SerializeField]private PlayerController playerController;
        void Start()
        {
            aradakifark = transform.position - playerController.gameObject.transform.position;
        }

        private void Update()
        {
            if (onTriggers.gameOver)
            {
                transform.position = playerController.gameObject.transform.position + aradakifark;
                cam.fieldOfView = 60;
                
            }
            else
            {
                if (onTriggers.passed == false)
                {
                    
                    transform.position = new Vector3(transform.position.x,
                        transform.position.y,
                        Mathf.Clamp(transform.position.z,
                            playerController.firstarealimitmin,
                            playerController.firstarealimitmax)
                    );
                    transform.position = playerController.gameObject.transform.position + aradakifark;
                }
                else
                {
                    var vector3 = transform.position;
                    vector3.z = playerController.gameObject.transform.position.z + aradakifark.z;
                    transform.position = vector3;
                }
                
            }
        }
        
    }
}
