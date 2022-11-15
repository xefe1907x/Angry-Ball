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
        ballRigidBody.isKinematic = true;
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

        if (ballRigidBody)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            ballRigidBody.position = worldPosition;
        }
    }

    void LaunchBall()
    {
        ballRigidBody.isKinematic = false;
        Invoke("RemoveJoint", 0.15f);
        Invoke("RemoveHandler", 1.5f);
        
    }
    
    void RemoveHandler()
    {
        var handler = GetComponent<BallHandler>();
        Destroy(handler);
    }
    
    void RemoveJoint()
    {
        var joint = GetComponent<SpringJoint2D>();
        Destroy(joint);
        ballIsThrown?.Invoke();
    }
}
