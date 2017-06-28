using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// player attributs
	public float strength;
	public float torque;
    public Scoreboard score;

	// internal variables
	int rolls;
	int frame;

	// controllers
	BallController ball;
	PinsController pins;

	// state variable
	public enum State { WAIT, AIM, SHOOT, DONE, Length };
	private State _state;

	// state accessors
	public State state { 
		get {
			return _state;
		}
		private set {
			_state = value;
			EnterState();
		}
	}


	/*
	 *  Public methods
	 */
	
	public void Reset() 
	{
		score.Clear ();
		state = State.WAIT;
	}

	public void TakeTurn(int next_frame) 
	{
		rolls = 0;
		frame = next_frame;
		state = State.AIM;
	}


	/*
	 *  Private methods
	 */

	void Start()
	{
		score = new Scoreboard ();
		ball = GameObject.Find ("Ball")     .GetComponent<BallController> ();
		pins = GameObject.Find ("PinHolder").GetComponent<PinsController> ();
		Reset();
	}

	void EnterState() {
		//
		// TODO: complete the implementation
		//
	}

	
	void Update() 
	{
		//
		// TODO: complete the implementation
		//
	}

	//
	// TODO: implement all the remaining methods
	//
}
