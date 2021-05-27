using System;
using UnityEngine;

public class BridgePositioning : MonoBehaviour
{
    Transform[] bridgePositions;
    bool[] adjecencyList;
    GameObject[] roomAdjacencyList;
    GameObject bridge;
    GameObject[] bridges;

    Transform[] getBridgePositions() => bridgePositions;
    public void init(GameObject[] list)
	{
        bridgePositions = new Transform[4];
        bridges = new GameObject[4];
        foreach (Transform t in transform)
        {
            foreach (Transform m in t)
            {
                if (m.gameObject.name.Equals("Top"))
                    bridgePositions[0] = m;

                if (m.gameObject.name.Equals("Left"))
                    bridgePositions[1] = m;

                if (m.gameObject.name.Equals("Bottom"))
                    bridgePositions[2] = m;

                if (m.gameObject.name.Equals("Right"))
                    bridgePositions[3] = m;
            }

        }
        this.roomAdjacencyList = list;
        bridge = Resources.Load<GameObject>("Rooms/Misc/Bridge");
        positionBridgesRoom();
    }

    void positionBridgesRoom()
	{
		for (int i = 0; i < bridgePositions.Length; i++)
		{
			if (roomAdjacencyList[i] != null && bridgePositions[i] != null)
			{
				if (bridge != null)
				{
					GameObject obj = Instantiate<GameObject>(bridge, bridgePositions[i].position, Quaternion.identity);
					obj.GetComponent<Bridge>().direction = bridgePositions[i].gameObject.name;
					obj.transform.parent = this.transform;

					Vector3 startingPositionOffset = new Vector3(0, -3, 0);
					obj.transform.position += startingPositionOffset;

					bridges[i] = obj;

					obj.GetComponent<Bridge>().initSelf();
				}
			}
		}
	}

	 public void initDirections()
	{
		for (int i = 0; i < bridgePositions.Length; i++)
		{
			if (roomAdjacencyList[i] != null && bridgePositions[i] != null && bridges[i] != null)
			{
				Bridge comp = bridges[i].GetComponent<Bridge>();
				BridgePositioning posit = roomAdjacencyList[i].GetComponent<BridgePositioning>();
				comp.roomTo = roomAdjacencyList[i].GetComponent<Room>();
				//comp.positionTo = posit.getBridgePositions()[(i + 2) % 4].position;
				Transform[] pos = posit.getBridgePositions();
				Vector3 v = pos[(i + 2) % 4].position;
				Quaternion q = pos[(i + 2) % 4].rotation;
				q = Quaternion.Euler(40, 0, 0);
				switch (i)
				{
					case 0:
						{


							q *= Quaternion.Euler(0, 0, 270);
							Quaternion d = Quaternion.Euler(40, 0, 0);
							Vector3 der = new Vector3(0, 0, 2);
							der = d * der;
							v += der;
							v += new Vector3(0, 5, 0);
							break;
						}
					case 1:
						{
							v += new Vector3(-2, 2, 0);
							break;
						}
					case 2:
						{

							q *= Quaternion.Euler(0, 0, 90);
							Quaternion d = Quaternion.Euler(40, 0, 0);
							Vector3 der = new Vector3(0, 0, 2);
							der = d * der;
							v -= der;
							v += new Vector3(0, 2, 0);
							break;
						}
					case 3:
						{
							q *= Quaternion.Euler(0, 0, 180);
							v -= new Vector3(-4, -2, 0);
							break;
						}
				}

					comp.positionTo = v;
					comp.transform.rotation= q;
				//bridges[i].GetComponent<Bridge>().positionTo = roomAdjacencyList[i].GetComponent<BridgePositioning>().getBridgePositions()[(i + 2) % 4].position;
			}
		}
	}

	internal void openBridges()
	{
		foreach (GameObject bridge in bridges)
		{
			if(bridge)
			bridge.GetComponent<Bridge>().openBridge();
		}
	}
}
