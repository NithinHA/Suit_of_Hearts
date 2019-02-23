using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdown : MonoBehaviour
{
	public float time_remain = 0;
	private Text timer_text;

    void Start()
    {
		timer_text = GetComponent<Text>();
    }
	
    void Update()
    {
		timer_text.text = "Time: " + (int)time_remain;
		if (time_remain > 0)
		{
			time_remain -= Time.deltaTime;
		}
	}
}
