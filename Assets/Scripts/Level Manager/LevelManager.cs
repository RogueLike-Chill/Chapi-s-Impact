using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int initialFogCount;
    GameManager manager;
    LevelSpawner spawner;
    Vector3[] levelBoundries;
    int enemyCount;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelBoundries = new Vector3[4];
        initLevelBoundries();
        updateCurrentEnemyCount();
        GameManagerEvents.enemyDefeated.AddListener(updateCurrentEnemyCount);
    }

	private void Update()
	{
		
	}

	public int getInitialFogCount() => initialFogCount;

    private void updateCurrentEnemyCount()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
	}

    public int getCurrentEnemyCount()
	{
        return enemyCount;
	}

    public Vector3[] getLevelBoundries()
	{
        return levelBoundries;
	}

    private void initLevelBoundries()
	{
       Transform[] trans= transform.Find("LevelBoundries").GetComponentsInChildren<Transform>();
        Transform[] trans2 = new Transform[trans.Length - 1];

        for (int i=0; i<trans2.Length;i++)
		{   trans2[i] = trans[i+1];	}

        for(int i=0; i<trans2.Length; i++)
		{   levelBoundries[i] = trans2[i].position;	}
	}

	internal void requestMoveToMainMenu()
	{
        manager.moveToMainMenu();
	}
}
