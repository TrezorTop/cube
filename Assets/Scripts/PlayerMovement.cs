using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyRef;

    public float force = 15f;

    private float _horizontalInput;
    private float _verticalInput;

    public Transform cameraTransform;

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * force;
        _verticalInput = Input.GetAxis("Vertical") * force;

        Vector3 cameraDirection = new Vector3();

        if (Input.GetAxis("Vertical") > 0)
        {
            if (Input.GetButton("Vertical"))
            {
                cameraDirection = cameraTransform.transform.forward;
            }

            rigidbodyRef.AddForce(cameraDirection * force);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetButton("Vertical"))
            {
                cameraDirection = cameraTransform.transform.forward;
            }
            rigidbodyRef.AddForce(cameraDirection * -force);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetButton("Horizontal"))
            {
                cameraDirection = cameraTransform.transform.right;
            }
            rigidbodyRef.AddForce(cameraDirection * force);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (Input.GetButton("Horizontal"))
            {
                cameraDirection = cameraTransform.transform.right;
            }
            rigidbodyRef.AddForce(cameraDirection * -force);
        }
    }
}