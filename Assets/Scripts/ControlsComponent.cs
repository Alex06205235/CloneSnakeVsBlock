using UnityEngine;

namespace Skripts.Control
{
    public class ControlsComponent : MonoBehaviour
    {
        public GameObject snakeObject;
        public Camera playerCamera;
        public float controlSensitivity;
        public float forwardSpeed;

        float _sidewaysSpeed;
        static Rigidbody _snakeRigidbody;
        Vector3 _previousMousePosition;
        Vector3 _touchLastPos;

        void Awake()
        {
            _snakeRigidbody = snakeObject.GetComponent<Rigidbody>();
        }
   
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchLastPos = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            }
            else if(Input.GetMouseButtonUp(0))
            {
                _sidewaysSpeed = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 delta = playerCamera.ScreenToViewportPoint(Input.mousePosition) - _touchLastPos;
                _sidewaysSpeed += delta.x * controlSensitivity;
                _touchLastPos = playerCamera.ScreenToViewportPoint(Input.mousePosition);
            }
        
        
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(_sidewaysSpeed) > 4) _sidewaysSpeed = 4 * Mathf.Sign(_sidewaysSpeed);
            _snakeRigidbody.velocity = new Vector3(_sidewaysSpeed * 5, 0, forwardSpeed);

            _sidewaysSpeed = 0;
        }

    }
}
