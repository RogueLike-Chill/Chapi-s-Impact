using System.Collections;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] float zOffset;
    [SerializeField] float yOffset;

    [SerializeField] int shakeDurationInFrames;
    [SerializeField] float shakeIntensity;

    Vector3 offset;
    Vector3 originalPosition;

    [SerializeField] bool canFollow;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, yOffset, zOffset);
        player = GameObject.FindGameObjectWithTag("Player");
        originalPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;


		if (player.GetComponent<Player>().getPlayerInfo().isControlledByPlayer)
			if (canFollow)
			{
                originalPosition = player.transform.position - offset;
				transform.position = originalPosition;
			}




	}

    public void shake()
	{
        StartCoroutine(shakeC());

        IEnumerator shakeC()
        {
            for (int i = 0; i < shakeDurationInFrames; i++)
            {
                transform.position = transform.position + new Vector3(Random.Range(-shakeIntensity, shakeIntensity), Random.Range(-shakeIntensity, shakeIntensity), 0);
                yield return null;
            }

        }
    }

}

