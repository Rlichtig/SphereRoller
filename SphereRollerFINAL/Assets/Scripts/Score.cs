using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int score;
	public int highScore;
	
    void Awake()
	{
        DontDestroyOnLoad(transform.gameObject);
    }
	// Use this for initialization
	void Start () {
		score = 0;
		highScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// change the guitext to be exactly what the score value is;
		guiText.text = ("High Score: " + highScore
			+ "\n"
			+ "Score: "
			+ score);
		if(score > highScore)
		{
			highScore = score;
		}
	}
	
	void Increment(int score_value) {
		score += score_value;
	}
	
	void Reset() {
		score = 0;
	}
	
	
}
