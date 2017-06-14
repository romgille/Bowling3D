using UnityEngine;
using System.Collections;

public class PinsController : MonoBehaviour 
{
    GameObject[] listPins;
    GameObject detector;

    private void Start()
    {
        listPins = GameObject.FindGameObjectsWithTag("Pins");
        detector = GameObject.FindGameObjectWithTag("PinDetector");
    }

	public void Reset() 
	{
		//
		// TODO: implement the method
		//
	}

	public bool AllDown()
	{
        bool oneDown = false;
		while()
        {

        }
		return false;
	}

	public void RemoveKnockedOut()
	{
		//
		// TODO: implement the method
		//
	}

	public int KnockedOut()
	{
        return listPins.Count(p => p.IsActive());
	}

	public bool HasDone()
	{
		//
		// TODO: implement the method
		//
		return false;
	}
}
