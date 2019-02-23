using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	ProfileGrid grid;
	[SerializeField] AssignTask assign_task;
	[SerializeField] ScoreDisplay score_display;
	[SerializeField] TimeCountdown time_display;

	bool is_ready = false;
	[SerializeField] float time_before_game = 5;
	[SerializeField] float time_during_game = 100;
	[SerializeField] float min_time_during_game = 20;

	Coroutine wait_time_during_game;

    void Start()
    {
		grid = GetComponent<ProfileGrid>();
		StartCoroutine(waitTimeBeforeGame());
    }
	
	void Update()
    {
		if (is_ready)
		{
			for (int i = 0; i < grid.row_count; i++)
			{
				for (int j = 0; j < grid.column_count; j++)
				{
					if (grid.profile_UI[i, j].GetComponent<Image>().sprite != assign_task.task_images[j].sprite)
					{
						return;
					}
				}
			}
			winGame();
		}
    }

	IEnumerator waitTimeBeforeGame()
	{
		time_display.time_remain = 0;
		assign_task.removeAssignedTask();
		is_ready = false;
		yield return new WaitForSeconds(time_before_game);
		time_display.time_remain = time_during_game;
		assign_task.assignRandomTasks();
		grid.shuffleGrid();
		is_ready = true;
		wait_time_during_game = StartCoroutine(waitTimeDuringGame());
	}

	void winGame()
	{
		Debug.Log("Win!");
		if (wait_time_during_game != null)
		{
			StopCoroutine(wait_time_during_game);
		}
		score_display.score++;      //increase score
		if (time_during_game > min_time_during_game)
			time_during_game -= 10;
		StartCoroutine(waitTimeBeforeGame());
	}

	IEnumerator waitTimeDuringGame()
	{
		yield return new WaitForSeconds(time_during_game);
		Debug.Log("time up");
		StartCoroutine(waitTimeBeforeGame());
	}
}
