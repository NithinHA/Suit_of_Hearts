using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignTask : MonoBehaviour
{
	public GameObject game_manager;
	private ProfileGrid grid;

	Sprite default_sprite;

	public List<Image> task_images = new List<Image>();
	private Sprite[] all_sprites;

    void Start()
    {
		grid = game_manager.GetComponent<ProfileGrid>();
		foreach(Image img in gameObject.GetComponentsInChildren<Image>())
		{
			task_images.Add(img);
		}
		task_images.RemoveAt(0);

		default_sprite = task_images[0].sprite;
    }
	
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.E))
		//	assignRandomTasks();
		//if (Input.GetKeyDown(KeyCode.R))
		//	removeAssignedTask();
    }

	public void assignRandomTasks()
	{
		all_sprites = shuffleLogic(grid.sprite_distinct_list.ToArray());
		for (int i = 0; i < grid.column_count; i++)
		{
			task_images[i].sprite = all_sprites[i];
		}
	}

	public void removeAssignedTask()
	{
		for (int i = 0; i < task_images.Count; i++)
		{
			task_images[i].sprite = default_sprite;
		}
	}

	private System.Random _random = new System.Random();
	Sprite[] shuffleLogic(Sprite[] array)
	{
		int p = array.Length;
		for (int n = p - 1; n > 0; n--)
		{
			int r = _random.Next(0, n);
			Sprite t = array[r];
			array[r] = array[n];
			array[n] = t;
		}

		return array;
	}
	
}
