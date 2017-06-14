using UnityEngine;

public class TestController : MonoBehaviour {

    BallController ball;
    PinsController pins;

    GUIText score;
    GUIText help;

    bool aim_mode;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball").GetComponent<BallController>();
        pins = GameObject.Find("PinHolder").GetComponent<PinsController>();
        score = GameObject.Find("Score").GetComponent<GUIText>();
        help = GameObject.Find("Help").GetComponent<GUIText>();

        aim_mode = true;
        help.text = "Click to proceed.";
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Knocked-out pins: " + pins.KnockedOut();
        
        if (aim_mode)
        {
            ball.FollowMouse();

            if (Input.GetMouseButtonUp(0))
            {
                aim_mode = false;
                ball.Shoot(Vector3.forward, 50, 0);
            }
        } else
        {
            if (ball.HasDone() && pins.HasDone() && Input.GetMouseButtonUp(0))
            {
                aim_mode = true;
                ball.Reset();
                pins.RemoveKnockedOut();

                if (pins.AllDown())
                {
                    pins.Reset();
                }
            }
        }
	}
}
