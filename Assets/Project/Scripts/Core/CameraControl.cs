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
                }
                else
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, 61.6f, 85.6f),
                        transform.position.y,
                        Mathf.Clamp(transform.position.z,
                            playerController.secondarealimitmin,
                            playerController.secondarealimitmax)
                    );
                }
                
            }
            transform.position = playerController.gameObject.transform.position + aradakifark;
         //   transform.rotation = playerController.gameObject.transform.rotation;
        }
        
    }
}
