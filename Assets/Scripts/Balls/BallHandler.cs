using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidBody;

    Camera mainCamera;
    
    bool isDragging;

    public static Action ballIsThrown;
    public static Action hitBlock;

    void Start()
    {
        mainCamera = Camera.main;
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.isKinematic = true;
        ConnectRigidBody();
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
    
    void ConnectRigidBody()
    {
        var pivot = GameObject.FindGameObjectWithTag("Pivot");
        var pivotRigidBody = pivot.GetComponent<Rigidbody2D>();
        var sprintJoint = GetComponent<SpringJoint2D>().connectedBody = pivotRigidBody;
    }

    void LaunchBall()
    {
        ballRigidBody.isKinematic = false;
        Invoke("RemoveJoint", 0.3f);
        Invoke("RemoveHandler", 1.5f);
        ballIsThrown?.Invoke();
        
    }
    
    void RemoveHandler()
    {
        var handler = GetComponent<BallHandler>();
        Destroy(handler);
    }
    
    void RemoveJoint()
    {
        ballRigidBody = null;
        var currentBallSprintJoint = GetComponent<SpringJoint2D>();
        currentBallSprintJoint.enabled = false;
        currentBallSprintJoint = null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block"))
        {
            hitBlock?.Invoke();
        }
    }
}
