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
		score.Clear();
		state = State.WAIT;
	}

	public void TakeTurn(int next_frame) 
	{
		rolls = 0;
		frame = next_frame;
        ball.Reset();
        pins.Reset();
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
	}

	
	void Update()
    {
        switch (state)
        {
            case State.WAIT:
                resetAll();
                break;
            case State.AIM:
                ball.Reset();
                pins.RemoveKnockedOut();
                if (pins.AllDown())
                {
                    pins.Reset();
                }
                ball.FollowMouse();
                if (Input.GetMouseButtonUp(0))
                {
                    rolls++;
                    state = State.SHOOT;
                }
                break;
            case State.SHOOT:
                ball.Shoot(Vector3.forward, 1, 0);
                if(ball.HasDone() && pins.HasDone())
                {
                    state = State.DONE;
                }
                break;
            case State.DONE:
                score.SetScore(frame, rolls, pins.KnockedOut());
                if (Input.GetMouseButtonUp(0))
                {
                    state = score.IsEnded(frame) ? State.WAIT : State.AIM;
                }
                break;
            default:
                return;
        }
    }

    private void resetAll()
    {
        ball.Reset();
        pins.Reset();
    }
}
