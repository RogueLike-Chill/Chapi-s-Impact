using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentItems : MonoBehaviour
{

    [SerializeField] GameObject[] powerupList;
    GameObject fileChosen;
    // Start is called before the first frame update
    public void initSelf()
	{
        fileChosen = powerupList[Random.Range(0,powerupList.Length)];
	}
    
    public void spawnItem()
	{
        GameObject item = Instantiate(fileChosen,transform.position,Quaternion.identity);
        item.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, -10), ForceMode.Impulse);
	}
}
