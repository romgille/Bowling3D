using UnityEngine;

public class BallController : MonoBehaviour
{

    public void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ResetPosition>().Reset();
    }

    public void FollowMouse()
    {
        transform.position = new Vector3(GetComponent<FollowMouse>().position.x, transform.position.y, transform.position.z);
    }

    public void Shoot(Vector3 direction, float strength, float torque)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(strength * direction, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, torque));
    }

    public bool HasDone()
    {
        return transform.position.y < 0 || !GetComponent<MeshRenderer>().isVisible;
    }
}