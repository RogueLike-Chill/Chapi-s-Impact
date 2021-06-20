using System;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour
{
    bool planting = false;
    Tree tree;
    Player playerM;
    bool plantLocked = false;
    float direction;
    int treesToPlant = 0;
    int frameCount;
    bool activateFrameCount;

    [Header("Set tree position offsets")]
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float zOffset;
    
    [Header("Timing of planting events in frames")]
    [SerializeField] float secondsUntilPlanting;
    [SerializeField] float secondsUntilEnding;


    // Start is called before the first frame update
    void Start()
    {
        playerM = GetComponent<Player>();
        tree = Resources.Load<Tree>("TreeOfLife");
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerM.plantingPressed() && !plantLocked && playerM.getHowManyTreesCanPlant()>0
            && playerM.getPlayerInfo().isControlledByPlayer)
		{
            plantLocked = true;
            playerM.setPlanting(true);
			//Get a consistent amount of real time regardless of frameRate;
			//CHANGE TO NOT HARDCODED VALUES!!!
			Invoke("plant", secondsUntilPlanting);
			Invoke("endPlanting", secondsUntilEnding);
			activateFrameCount = true;
        }
        direction = playerM.getChapiDirection();
        //adjustDirectionToFitTreePivot();
  //      if (activateFrameCount)
		//{
  //          frameCount++;
  //          if (frameCount == framesUntilPlanting)
  //              plant();

  //          else if (frameCount == framesUntilEnding)
		//	{
  //              endPlanting();
  //              activateFrameCount = false;
  //              frameCount = 0;
  //          }

		//}
    }

    void adjustDirectionToFitTreePivot()
	{
        if (direction < 0)
            direction *= 4;
	}

    public bool isPlanting()
    {
        return planting;
    }

    void plant()
	{
        Vector3 offset = new Vector3(direction, yOffset, zOffset) ;
        Instantiate(tree, transform.position + offset , Quaternion.identity);
	}

    void endPlanting()
	{
        playerM.setPlanting(false);
        playerM.getRoom().invokeTreePlantedEvent();
        plantLocked = false;
	}

	internal void setRoom(Room currentRoom)
	{
       // currentRoom.addTreePlantedEventListener(endPlanting);
	}
}
