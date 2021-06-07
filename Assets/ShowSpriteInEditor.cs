using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class ShowSpriteInEditor : MonoBehaviour
{
	NatureType type;

	void Start()
	{
		//transform.localScale = new Vector3(0.5f, 0.5f, 1);

	}

	private void Update()
	{

		makeSpriteAppearInEditor();
	}

	void makeSpriteAppearInEditor()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		type = GetComponent<NatureSpawnPoint>().getType();
		switch (type)
		{
			case NatureType.ROCK1:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock1").GetComponent<SpriteRenderer>().sprite; ;

					break;
				}

			case NatureType.ROCK2:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock2").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}

			case NatureType.ROCK3:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock3").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}
			case NatureType.TREE1:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Tree1").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}
		}
	}
}
