using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript_1 : MonoBehaviour
{
	[SerializeField] private List<Sprite> play_sprites = new List<Sprite>();
	public List<GameObject> play_imgs = new List<GameObject>();

	[SerializeField] private List<Sprite> bae_sprites = new List<Sprite>();
	public List<GameObject> bae_imgs = new List<GameObject>();

	[SerializeField] private List<Sprite> slay_sprites = new List<Sprite>();
	public List<GameObject> slay_imgs = new List<GameObject>();

	void Start()
    {
		for(int i=0; i<play_imgs.Count; i++)
		{
			play_sprites.Add(play_imgs[i].GetComponent<Image>().sprite);
			bae_sprites.Add(bae_imgs[i].GetComponent<Image>().sprite);
			slay_sprites.Add(slay_imgs[i].GetComponent<Image>().sprite);
		}
    }

    void Update()
    {
        
    }

	public void ScrollLeft(int type)
	{
		switch (type)
		{
			case 0:
				left_rotation(play_sprites);
				assign_sprites(play_imgs, play_sprites);
				break;
			case 1:
				left_rotation(bae_sprites);
				assign_sprites(bae_imgs, bae_sprites);
				break;
			case 2:
				left_rotation(slay_sprites);
				assign_sprites(slay_imgs, slay_sprites);
				break;
		}
	}

	
	public void ScrollRight(int type)
	{
		switch (type)
		{
			case 0:
				right_rotation(play_sprites);
				assign_sprites(play_imgs, play_sprites);
				break;
			case 1:
				right_rotation(bae_sprites);
				assign_sprites(bae_imgs, bae_sprites);
				break;
			case 2:
				right_rotation(slay_sprites);
				assign_sprites(slay_imgs, slay_sprites);
				break;
		}
	}

	private void left_rotation<T>(List<T> object_list)
	{
		T first_sprite = object_list[0];
		int i = 0;
		while (i < object_list.Count - 1)
			object_list[i] = object_list[++i];
		object_list[i] = first_sprite;
	}

	private void right_rotation<T>(List<T> object_list)
	{
		T last_object = object_list[object_list.Count - 1];
		int i = object_list.Count - 1;
		while (i > 0)
			object_list[i] = object_list[--i];
		object_list[i] = last_object;
	}

	private void assign_sprites(List<GameObject> imgs, List<Sprite> sprites)
	{
		for (int i = 0; i < imgs.Count; i++)
			imgs[i].GetComponent<Image>().sprite = sprites[i];
	}
}
