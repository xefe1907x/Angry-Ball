using UnityEngine;
using UnityEngine.InputSystem;
public class RopeSetup : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] Transform positionStart;
    Transform positionEnd;
    GameObject pivot;
    bool isPressing;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        SetPos1();
    }

    void SetPos1()
    {
        pivot = GameObject.FindGameObjectWithTag("Pivot");

        positionEnd = pivot.transform;
        
        line.SetPosition(0, positionStart.position);
    }

    void Update()
    {
        SetPos2();
        
    }

    void SetPos2()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
            isPressing = true;
        else
            isPressing = false;

        if (isPressing)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        
            Vector3 worldPosition = camera.ScreenToWorldPoint(touchPosition);

            line.SetPosition(1, worldPosition);
        }

        else
        {
            line.SetPosition(1, positionEnd.position);
        }
        
    }
}
