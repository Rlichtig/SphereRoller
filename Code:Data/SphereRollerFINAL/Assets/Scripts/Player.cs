using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
	int SCORE_VALUE = 100;
	//public int vv = 10;
	//public int hv = 
	public Vector3 currentPlayerPosition;
	//public Vector3 previousPlayerPosition;
	public int score;
	public GameObject basesphere;
	public AudioClip Jump;
	public AudioClip Death;
	public AudioClip Pew;
	public GameObject parent;
	public bool isDead;
	public int highScore;
	public bool isMenu;
	
	void Start ()
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isDead)
		{
			currentPlayerPosition = gameObject.transform.position;
			
		
			if (Input.GetKey ("a") && currentPlayerPosition [2] == 5 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("JumpLeft");
				//gameObject.transform.position = new Vector3 (currentPlayerPosition [0], currentPlayerPosition [1], currentPlayerPosition [2] + 5);
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKey ("d") && currentPlayerPosition [2] == 5 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("JumpRight");
				//gameObject.transform.position = new Vector3 (currentPlayerPosition [0], currentPlayerPosition [1], currentPlayerPosition [2] - 5);
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKey ("a") && currentPlayerPosition [2] == 0 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("Rtm");
				//gameObject.transform.position = new Vector3 (currentPlayerPosition [0], currentPlayerPosition [1], currentPlayerPosition [2] + 5);
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKey ("d") && currentPlayerPosition [2] == 10 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("Ltm");
				//gameObject.transform.position = new Vector3 (currentPlayerPosition [0], currentPlayerPosition [1], currentPlayerPosition [2] - 5);
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKeyDown ("space") && currentPlayerPosition [2] == 5 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("Jim");
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKeyDown ("space") && currentPlayerPosition [2] == 0 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("Jir");
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			} else if (Input.GetKeyDown ("space") && currentPlayerPosition [2] == 10 && currentPlayerPosition [1] < 0.05 && currentPlayerPosition [1] > -0.05) {
				gameObject.animation.Play ("Jil");
				AudioSource.PlayClipAtPoint (Jump, new Vector3 (0, 0, 0));
			}
		}	
	}
	void FixedUpdate ()
	{
		if (!isDead) {
			currentPlayerPosition = gameObject.transform.position;
			GameObject.Find ("Score").SendMessage ("Increment", 1);
			parent.transform.Translate (new Vector3 (.5f, 0, 0));
			GameObject.Find ("Main Camera").transform.position = new Vector3 (currentPlayerPosition [0] - 10, 5, 5);
			
			//gameObject.animation.Play ("Rotation");
			//gameObject.transform.Translate (new Vector3 (.1f, 0, 0));
		
			//gameObject.transform.Translate (new Vector3 (0, vv * Input.GetAxis ("Vertical") * Time.deltaTime, 0), Space.World);
		
			
		}
	}

	 void OnTriggerEnter (Collider obj)
		{
			if (obj.gameObject.name == "Collectable") {
			GameObject.Find ("Score").SendMessage ("Increment", SCORE_VALUE);
			SCORE_VALUE = SCORE_VALUE * 2;
			obj.gameObject.transform.position = new Vector3 (0, -20, 0);
			AudioSource.PlayClipAtPoint (Pew, new Vector3 (0, 0, 0));
		}
	}

	
	void OnCollisionEnter (Collision obj)
	{
		if (obj.gameObject.name == "Enemy") {
			
			//GameObject[] spheres = GameObject.FindGameObjectsWithTag ("basesphere");
			//foreach (GameObject basesphere in spheres) {
			//basesphere.transform.position = currentPlayerPosition;
			//}
			
			//GameObject newSphere = Instantiate( GameObject.Find("basesphere")) as GameObject;
			//newSphere.transform.position = currentPlayerPosition;
			
			for(int i = 0; i < 25; i++)
			{
				GameObject newSphere = Instantiate (basesphere) as GameObject;
				newSphere.transform.position = currentPlayerPosition;
				newSphere.rigidbody.AddForce(Random.Range(-200,200), Random.Range(500,2500), Random.Range(500,2500));
				GameObject newSphere2 = Instantiate (basesphere) as GameObject;
				newSphere2.transform.position = currentPlayerPosition;
				newSphere2.rigidbody.AddForce(Random.Range(-200,200), Random.Range(-2500,-500), Random.Range(-2500,-500));
				GameObject newSphere3 = Instantiate (basesphere) as GameObject;
				newSphere3.transform.position = currentPlayerPosition;
				newSphere3.rigidbody.AddForce(Random.Range(200,-200), Random.Range(2500,500), Random.Range(-2500,-500));
				GameObject newSphere4 = Instantiate (basesphere) as GameObject;
				newSphere4.transform.position = currentPlayerPosition;
				newSphere4.rigidbody.AddForce(Random.Range(200,-200), Random.Range(-500,-2500), Random.Range(500,2500));
			}
			
			gameObject.animation.Stop("Jil");
			gameObject.animation.Stop("Jim");
			gameObject.animation.Stop("Jir");
			gameObject.animation.Stop("Ltm");
			gameObject.animation.Stop("Rtm");
			gameObject.animation.Stop("JumpRight");
			gameObject.animation.Stop("JumpLeft");
			gameObject.transform.Translate (new Vector3 (0, -100, 0));
			AudioSource.PlayClipAtPoint (Death, new Vector3 (0, 0, 0));
			isDead = true;
		}
		
		if (obj.gameObject.name == "Finish Line") 
		{
			Application.LoadLevel("Level_02");
		}
		
				if (obj.gameObject.name == "Finish Line 2") 
		{
			Application.LoadLevel("Level_03");
		}
		
		if (obj.gameObject.name == "Bottom") 
		{
			for(int i = 0; i < 25; i++)
			{
				GameObject newSphere = Instantiate (basesphere) as GameObject;
				newSphere.transform.position = currentPlayerPosition;
				newSphere.rigidbody.AddForce(Random.Range(-200,200), Random.Range(500,2500), Random.Range(500,2500));
				GameObject newSphere2 = Instantiate (basesphere) as GameObject;
				newSphere2.transform.position = currentPlayerPosition;
				newSphere2.rigidbody.AddForce(Random.Range(-200,200), Random.Range(-2500,-500), Random.Range(-2500,-500));
				GameObject newSphere3 = Instantiate (basesphere) as GameObject;
				newSphere3.transform.position = currentPlayerPosition;
				newSphere3.rigidbody.AddForce(Random.Range(200,-200), Random.Range(2500,500), Random.Range(-2500,-500));
				GameObject newSphere4 = Instantiate (basesphere) as GameObject;
				newSphere4.transform.position = currentPlayerPosition;
				newSphere4.rigidbody.AddForce(Random.Range(200,-200), Random.Range(-500,-2500), Random.Range(500,2500));
			}
			gameObject.transform.Translate (new Vector3 (0, -100, 0));
			AudioSource.PlayClipAtPoint (Death, new Vector3 (0, 0, 0));
			isDead = true;
		}
		/*if (obj.gameObject.name == "Bottom") {
			gameObject.transform.Translate (new Vector3 (0, -10, 0));
			AudioSource.PlayClipAtPoint (Death, new Vector3 (0, 0, 0));
		}*/
	}

	void OnGUI ()
	{
		if (isMenu == true) {
			//GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
			GUI.skin.textArea.fontSize = 20;
			GUI.skin.button.fontSize = 20;
			GUI.TextArea (new Rect (Screen.width / 3, Screen.height / 16, Screen.width / 3, Screen.height / 3),
			"HOW TO PLAY: \n\n" +
			"Press \"space\" to jump \n" +
			"Press \"a\" to jump left\n" +
			"Press \"d\" to jump right\n" +
			"Goal: Collect as many capsules as possible!");
		
			if (GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 2.2f, Screen.width / 8, Screen.height / 8), "Play!\n")) {	
				GameObject.Find ("Score").SendMessage ("Reset");
				Application.LoadLevel ("Level_01");
			}
		
			if (GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 1.6f, Screen.width / 8, Screen.height / 8), "Exit")) {
				Application.Quit ();
			}

		}
			else if (isDead == true) {
			//GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
			GUI.skin.textArea.fontSize = 20;
			GUI.skin.button.fontSize = 20;
			GUI.TextArea (new Rect (Screen.width / 3, Screen.height / 16, Screen.width / 3, Screen.height / 3),
			"HOW TO PLAY: \n\n" +
			"Press \"space\" to jump \n" +
			"Press \"a\" to jump left\n" +
			"Press \"d\" to jump right\n" +
			"Goal: Collect as many capsules as possible!");
		
			if (Input.GetKeyDown ("r") || GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 2.2f, Screen.width / 8, Screen.height / 8), "Retry?\n(R)")) {	
				GameObject.Find ("Score").SendMessage ("Reset");
				Application.LoadLevel ("Level_01");
			}
		
			if (GUI.Button (new Rect (Screen.width / 2.3f, Screen.height / 1.6f, Screen.width / 8, Screen.height / 8), "Exit")) {
				Application.Quit ();
			}

		}
	}
}