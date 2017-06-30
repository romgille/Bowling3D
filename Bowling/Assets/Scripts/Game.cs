using UnityEngine;

public class Game : MonoBehaviour 
{
	public Player player;

	// state variables
	bool show;
	int frame;

	void Start() {
		show = true;
		frame = -1;
	}

	public void Play()
	{
		show = false;
		frame = 0; 
		player.Reset ();
	}

	void Update () 
	{	
		if (frame == 10 && player.state == Player.State.WAIT ) {
			frame = -1;
			show = true;
		}
		if (frame > -1 && player.state == Player.State.WAIT ) 
		{
			player.TakeTurn (frame);
			frame++;
		}
	}

	void OnGUI () 
	{
		if(show)
		{
			GUI.BeginGroup( new Rect(Screen.width/2-50,Screen.height/2-100,100,100) );
			GUI.Box (new Rect (0,0,100,100), "Menu");
			
			// Make the first button
			if( GUI.Button(new Rect (10,25,80,30), "Play") ) {
				Play();
				show = false;
			}
			
			// Make the second button.
			if( GUI.Button(new Rect (10,60,80,30), "Quit") ) {
				Application.Quit();
			}
			
			GUI.EndGroup();
		}
	}
}