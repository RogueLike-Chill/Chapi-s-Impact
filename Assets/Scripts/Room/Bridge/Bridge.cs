using System.Collections;
using UnityEngine;

public class Bridge : MonoBehaviour
{
	[SerializeField] public string direction;
	internal Vector3 positionTo;
	[SerializeField] internal Room roomTo;
	SpriteRenderer[] renderers;

	[SerializeField] bool isOpen = false;

	public void initSelf()
	{
		renderers = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].color = new Color(1, 1, 1, 0);
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if(isOpen)
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Player>().movePlayerBetweenRooms(positionTo,roomTo);
		}
	}

	public void openBridge()
	{
		isOpen = true;
		StartCoroutine(openBridgeCoroutine());
		//Create a coroutine for changing sprite transparacny and elevate position by 3!

		IEnumerator openBridgeCoroutine()
		{
			float deltaA = 0.02f;
			float deltaHeight = 0.06f;
			for(int i=0; i<50; i++)
			{
				for (int j=0; j<renderers.Length; j++)
				{
					renderers[j].color += new Color(1, 1, 1, deltaA);
				}
				transform.position += new Vector3(0, deltaHeight, 0);
				yield return null;
			}
		}
	}

}