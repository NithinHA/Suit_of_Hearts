using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileGrid : MonoBehaviour
{
	public List<Sprite> sprite_distinct_list = new List<Sprite>();
	[SerializeField] List<Sprite> profile_sprites_list = new List<Sprite>();
	Sprite[,] profile_sprites;
	[SerializeField] List<GameObject> profile_UI_list = new List<GameObject>();
	public GameObject[,] profile_UI;

	public int row_count;
	public int column_count;

	void Start()
	{
		for (int i = 0; i < sprite_distinct_list.Count; i++)
		{
			for (int j = 0; j < row_count; j++)
			{
				profile_sprites_list.Add(sprite_distinct_list[i]);
			}
		}
		profile_sprites = new Sprite[row_count, column_count];
		profile_UI = new GameObject[row_count, column_count];

		int count = 0;
		for(int i = 0; i < row_count; i++)
		{
			for (int j = 0; j < column_count; j++)
			{
				profile_sprites[i, j] = profile_sprites_list[count];
				profile_UI[i, j] = profile_UI_list[count];
				count++;
			}
		}

		shuffleGrid();
	}

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene(0);		//load scene MainMenu
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			SceneManager.LoadScene(4);		//load level selection menu
		}
    }


	public void ScrollLeft(int row_col)
	{
		List<Sprite> sprite_list = new List<Sprite>();
		if (row_col >= 0 && row_col < row_count)
		{
			for (int i = 0; i < column_count; i++)
				sprite_list.Add(profile_sprites[row_col, i]);
			left_rotation(sprite_list);
			for (int i = 0; i < column_count; i++)
				profile_sprites[row_col, i] = sprite_list[i];
		}
		else
		{
			for (int i = 0; i < row_count; i++)
				sprite_list.Add(profile_sprites[i, row_col - 10]);
			left_rotation(sprite_list);
			for (int i = 0; i < row_count; i++)
				profile_sprites[i, row_col - 10] = sprite_list[i];
		}
		assign_sprites_to_images();
	}

	public void ScrollRight(int row_col)
	{
		List<Sprite> sprite_list = new List<Sprite>();
		if (row_col >= 0 && row_col < row_count)
		{
			for (int i = 0; i < column_count; i++)
				sprite_list.Add(profile_sprites[row_col, i]);
			right_rotation(sprite_list);
			for (int i = 0; i < column_count; i++)
				profile_sprites[row_col, i] = sprite_list[i];
		}
		else
		{
			for (int i = 0; i < row_count; i++)
				sprite_list.Add(profile_sprites[i, row_col - 10]);
			right_rotation(sprite_list);
			for (int i = 0; i < row_count; i++)
				profile_sprites[i, row_col - 10] = sprite_list[i];
		}
		assign_sprites_to_images();
	}

	private List<T> left_rotation<T>(List<T> object_list)
	{
		T first_sprite = object_list[0];
		int i = 0;
		while (i < object_list.Count - 1)
			object_list[i] = object_list[++i];
		object_list[i] = first_sprite;

		return object_list;
	}

	private List<T> right_rotation<T>(List<T> object_list)
	{
		T last_object = object_list[object_list.Count - 1];
		int i = object_list.Count - 1;
		while (i > 0)
			object_list[i] = object_list[--i];
		object_list[i] = last_object;

		return object_list;
	}

	private void assign_sprites_to_images()
	{
		for (int i = 0; i < row_count; i++)
		{
			for (int j = 0; j < column_count; j++)
			{
				profile_UI[i, j].GetComponent<Image>().sprite = profile_sprites[i, j];
			}
		}
	}
	
	public void shuffleGrid()
	{
		get2d_sprite_array(shuffleLogic(profile_sprites_list.ToArray()));
		assign_sprites_to_images();
	}
	
	private void get2d_sprite_array(Sprite[] array)
	{
		int count = 0;
		for (int i = 0; i < row_count; i++)
		{
			for (int j = 0; j < column_count; j++)
			{
				profile_sprites[i, j] = array[count];
				count++;
			}
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
