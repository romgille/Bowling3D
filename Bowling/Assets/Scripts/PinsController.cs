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

	public void Reset() 
	{
		//
		// TODO: implement the method
		//
	}

	public bool AllDown()
	{
        //bool oneDown = false;
		//while()
        //{
        //
        //}
		return false;
	}

	public void RemoveKnockedOut()
	{
        for(int i = 0; i < listPins.Length; i++)
        {
            if (!listPins[i].activeSelf)
            {
                System.Console.WriteLine(i);
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
		//
		// TODO: implement the method
		//
		return false;
	}
}
