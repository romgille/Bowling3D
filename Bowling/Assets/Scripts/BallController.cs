using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody body;
    bool isShot;

    void Start()
    {
        isShot = false;
    }

    void Update()
    {
        if (HasDone())
        {
            Reset();
        } else
        {
            FollowMouse();
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(new Vector3(0, 0, 1), 100, 10);
                isShot = true;
            }
            HasDone();
        }
    }

    public void Reset()
    {
        GetComponent<ResetPosition>().Reset();
        isShot = false;
    }

    public void FollowMouse()
    {
        if (!isShot)
        {
            transform.position = new Vector3(GetComponent<FollowMouse>().position.x, transform.position.y, transform.position.z);
        }
    }

    public void Shoot(Vector3 direction, float strength, float torque)
    {
        if (!isShot)
        {
            body = GetComponent<Rigidbody>();
            body.isKinematic = false;
            body.AddForce(strength * direction, ForceMode.Impulse);
            body.AddTorque(new Vector3(torque, 0, 0));
        }
    }

    public bool HasDone()
    {
        return !GetComponent<MeshRenderer>().isVisible;
    }
}