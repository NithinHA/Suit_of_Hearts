using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public int score = 0;
	private Text score_text;

    void Start()
    {
		score_text = GetComponent<Text>();
    }
	
    void Update()
    {
		score_text.text = "Score: " + score;

		//if (Input.GetKeyDown(KeyCode.Space))
		//	score++;
    }
}
