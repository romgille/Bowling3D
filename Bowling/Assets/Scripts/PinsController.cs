using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PinsController : MonoBehaviour 
{
    GameObject[] listPins;
    GameObject detector;

    private void Start()
    {
        listPins = GameObject.FindGameObjectsWithTag("Pin");
        detector = GameObject.FindGameObjectWithTag("PinDetector");
    }

    void Update()
    {
        if(HasDone())
        {
            Reset();
        }
    }

	public void Reset() 
	{
        foreach(GameObject pin in listPins)
        {
            pin.GetComponent<ResetPosition>().Reset();
            pin.SetActive(true);
        }
	}

	public bool AllDown()
	{
        bool allDown = true;
        int i = 0;

        while(i < listPins.Length && allDown)
        {
            if(listPins[i].activeSelf)
            {
                allDown = false;
            }
            i++;
        }
		return allDown;
	}

	public void RemoveKnockedOut()
	{
        for(int i = 0; i < listPins.Length; i++)
        {
            if (!listPins[i].activeSelf)
            {
                listPins[i].gameObject.SetActive(false);
            }
        }
	}

	public int KnockedOut()
	{
        return listPins.Count(p => !p.activeSelf);
	}

	public bool HasDone()
	{
        if(!AllDown())
        {
            return false;
        }

		foreach(GameObject pin in listPins)
        {
            if(pin.GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0) && 
                pin.GetComponent<MeshRenderer>().isVisible)
            {
                return false;
            }
        }
		return true;
	}
}
