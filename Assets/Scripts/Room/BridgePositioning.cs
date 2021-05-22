﻿using UnityEngine;

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

                if (m.name.Equals("Left"))
                    bridgePositions[1] = m;

                if (m.name.Equals("Bottom"))
                    bridgePositions[2] = m;

                if (m.name.Equals("Right"))
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
					bridges[i] = obj;
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
				//comp.positionTo = posit.getBridgePositions()[(i + 2) % 4].position;
				Transform[] pos = posit.getBridgePositions();
				Vector3 t = pos[(i + 2) % 4].position;
				switch (i)
				{
					case 0:
						{
							Quaternion d = Quaternion.Euler(40, 0, 0);
							Vector3 der = new Vector3(0, 0, 2);
							der = d * der;
							t += der;
							t += new Vector3(0, 5, 0);
							break;
						}
					case 1:
						{
							t += new Vector3(2, 2, 0);
							break;
						}
					case 2:
						{
							Quaternion d = Quaternion.Euler(40, 0, 0);
							Vector3 der = new Vector3(0, 0, 2);
							der = d * der;
							t -= der;
							t += new Vector3(0, 2, 0);
							break;
						}
					case 3:
						{
							t -= new Vector3(2, -2, 0);
							break;
						}
				}

					comp.positionTo = t;

				//bridges[i].GetComponent<Bridge>().positionTo = roomAdjacencyList[i].GetComponent<BridgePositioning>().getBridgePositions()[(i + 2) % 4].position;
			}
		}
	}
}
