using UnityEngine;
using System.Collections;
using System.Linq;

public class PinsController : MonoBehaviour
{
    GameObject[] listPins;
    GameObject detector;

    void Start()
    {
        listPins = GameObject.FindGameObjectsWithTag("Pin");
        detector = GameObject.FindGameObjectWithTag("PinDetector");
    }

    public void Reset()
    {
        foreach (GameObject pin in listPins)
        {
            pin.gameObject.SetActive(true);
            pin.GetComponent<ResetPosition>().Reset();
        }
    }

    public bool AllDown()
    {
        return listPins.Length == KnockedOut();
    }

    public void RemoveKnockedOut()
    {
        foreach(GameObject pin in listPins)
        {
            if(!pin.GetComponent<Collider>().bounds.Intersects(detector.GetComponent<Collider>().bounds))
            {
                pin.gameObject.SetActive(false);
            }
        }
    }

    public int KnockedOut()
    {
        return listPins.Count(p => p.activeSelf && !p.GetComponent<Collider>().bounds.Intersects(detector.GetComponent<Collider>().bounds));
    }

    public bool HasDone()
    {
        foreach (GameObject pin in listPins)
        {
            if(!(pin.GetComponent<Renderer>().isVisible && pin.GetComponent<Rigidbody>().velocity != Vector3.zero))
            {
                continue;
            }
            return false;
        }
        return true;
    }
}