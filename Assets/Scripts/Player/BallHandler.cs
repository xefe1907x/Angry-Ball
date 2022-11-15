using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidBody;

    Camera mainCamera;
    
    bool isDragging;

    public static Action ballIsThrown;

    void Start()
    {
        mainCamera = Camera.main;
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ballRigidBody == null)
            return;

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }

            isDragging = false;
            return;
        }

        isDragging = true;

        ballRigidBody.isKinematic = true;

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        ballRigidBody.position = worldPosition;
    }

    void LaunchBall()
    {
        ballRigidBody.isKinematic = false;
        Invoke("RemoveJoint", 0.4f);
    }
    
    void RemoveJoint()
    {
        var joint = GetComponent<SpringJoint2D>();
        Destroy(joint);
        ballIsThrown?.Invoke();
    }
}
