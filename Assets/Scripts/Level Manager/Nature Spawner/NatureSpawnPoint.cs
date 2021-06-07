using System;
using UnityEngine;

public enum NatureType
{
	ROCK1,
	ROCK2,
	ROCK3,
	TREE1
}
public class NatureSpawnPoint : MonoBehaviour
{
	[Header("Is this spawn point active?")]
	[SerializeField] bool active; //Should this spawnpoint be used?
	[Header("What type of nature should grow here?")]
	[SerializeField] NatureType type;

	[Header("Make the sprite appear when fog reaches this %")]
	[SerializeField] [Range(0f, 100f)] float precentage;
	//Sprite sprite;
	//SpriteRenderer renderer;

	float currentFogPrecentage;
	bool rendererSet; //is the renderer sprite already set?
	bool fogDoneGenerating;
	NatureSpawner natureM;
	GameObject naturePiece;
	ShowSpriteInEditor spriteHandler;

	Vector3 offset; //relevent becuase for some reason, there exists an offset from the editor view to the game view.
	//this corrects is.

	private void Awake()
	{
		spriteHandler = GetComponent<ShowSpriteInEditor>();
	}
	public void initSelf(RoomInfo roomInfo)
	{
		natureM = transform.parent.GetComponentInParent<NatureSpawner>();
		setNaturePieceBasedOnType();
		
		naturePiece = Instantiate(naturePiece, transform.position+offset, Quaternion.identity);
		NaturePiece piece = naturePiece.GetComponent<NaturePiece>();


		piece.setType(type);
		piece.initSelf();
		piece.setPrecent(precentage/100f);
		naturePiece.transform.SetParent(this.transform);

		Destroy(GetComponent<ShowSpriteInEditor>());
		Destroy(GetComponent<SpriteRenderer>());
	}

	private void Update()
	{
		if (fogDoneGenerating)
			passCurrentStateToNaturePiece();
	}

	public bool isActive() => active;

		public NatureType getType() => type;

		public void setFogDone(bool done) => fogDoneGenerating = done;
		public void setFogState(float precentage)
		{
			currentFogPrecentage = precentage;
			if (active && fogDoneGenerating)
			{
				passCurrentStateToNaturePiece();
			}
		}

	internal void setRoomState(RoomInfo roomInfo)
	{
		//point.setFogDone(roomInfo.finishedLoading);
		//point.setFogState(roomInfo.containerInfo.remainingFogPrecentage);

		fogDoneGenerating = roomInfo.finishedLoading;
		currentFogPrecentage = roomInfo.containerInfo.remainingFogPrecentage;
	}

	void setNaturePieceBasedOnType()
		{
			switch (type)
			{
				case NatureType.ROCK1:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock1");
					offset = new Vector3(0, 2, 0);
						break;
					}

				case NatureType.ROCK2:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock2");
					offset = new Vector3(0, 2, 0);
					break;
					}

				case NatureType.ROCK3:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock3");
					offset = new Vector3(0, 2, 0);
					break;
					}
				case NatureType.TREE1:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Tree1");
					offset = new Vector3(0, 5, 0);
					break;
					}
			}
			
		}

		void passCurrentStateToNaturePiece()
		{
			naturePiece.GetComponent<NaturePiece>().setCurrentFogState(currentFogPrecentage);
		}


	}