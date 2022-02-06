using Player.Interfaces;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbodyRef;

        public float movementForce = 15f;
        public ForceMode movementForceMode = ForceMode.Force;

        public float jumpForce = 5f;
        public ForceMode jumpForceMode = ForceMode.Impulse;

        private bool _isGrounded;

        public Transform cameraTransform;

        public PlayerMovement(bool isGrounded)
        {
            _isGrounded = isGrounded;
        }

        private void Update()
        {
            // Debug.Log(rigidbodyRef.velocity.magnitude);
            if (Input.GetButton("Vertical")) AddForce(InputManagerAxis.Vertical);
            if (Input.GetButton("Horizontal")) AddForce(InputManagerAxis.Horizontal);
            if (Input.GetButtonDown("Jump")) ApplyJumpForce();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _isGrounded = collision.gameObject.layer == LayerMask.NameToLayer("Jumpable");
        }

        // private void OnCollisionExit(Collision collision)
        // {
        //     _isGrounded = collision.gameObject.layer != LayerMask.NameToLayer("Jumpable");
        // }


        private void ApplyJumpForce()
        {
            if (_isGrounded)
            {
                rigidbodyRef.AddForce(0, jumpForce * Time.fixedDeltaTime, 0, jumpForceMode);
                _isGrounded = false;
            }
        }


        private void AddForce(InputManagerAxis axis)
        {
            Vector3 cameraDirection = new Vector3();

            if (Input.GetButton(Interfaces.Input.InputDictionary[axis]))
            {
                cameraDirection = axis == InputManagerAxis.Vertical
                    ? cameraTransform.transform.forward
                    : cameraTransform.transform.right;
            }

            cameraDirection.y = 0;

            if (_isGrounded)
            {
                rigidbodyRef.AddForce(
                    cameraDirection * (movementForce * Input.GetAxis(Interfaces.Input.InputDictionary[axis]) * Time.fixedDeltaTime),
                    movementForceMode
                );
            }
        }
    }
}