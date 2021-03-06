﻿using System.Collections.Generic;
using UnityEngine;

public struct SpawnwaveManagerInfo
{
    public int totalNumberOfWaves { get; set; }
    public int remainingNumberOfWaves { get; set; }
    public bool isCompleted { get; set; }

    public SpawnwaveManagerInfo(int total, int remainingWaves)
	{
        this.totalNumberOfWaves = total;
        this.remainingNumberOfWaves = remainingWaves;
        isCompleted = remainingNumberOfWaves == 0;
	}
}
public class EnemyWaveManager : MonoBehaviour
{
    SpawnwaveManagerInfo waveManagerInfo;
    int randomizedNumberOfSpawnWaves;
    int currentWaveIndex;
    SpawnWave currentWave;
    List<SpawnWave> waves;

    public RoomEvents roomEvents;

    bool ready = false;
    void Update()
    {
        if (ready)
        {
            if (currentWave.isWaveDone() && currentWaveIndex<waveManagerInfo.totalNumberOfWaves)
			{
                activateNextWave();
			}

            updateWaveManagerInfo();
        }
    }

    public void initSelf(RoomEvents events)
    {
        this.roomEvents = events;
        initWaves();
        activateNextWave();
        waveManagerInfo = new SpawnwaveManagerInfo(waves.Count, waves.Count);
    }

	internal void setRoomEvents(RoomEvents events)
	{
        this.roomEvents = events;
	}

	void initWaves()
    {
        waves = new List<SpawnWave>(GetComponentsInChildren<SpawnWave>());
        randomizedNumberOfSpawnWaves = Random.Range(1, waves.Count + 1);
        int count = waves.Count;
        
        for (int i = 0; i < count - randomizedNumberOfSpawnWaves; i++)
        {
            waves.RemoveAt(Random.Range(1, waves.Count));
        }

        currentWaveIndex = -1;
        ready = true;
    }

	public void activateNextWave()
    {
        currentWaveIndex++;
        if (waves.Count<=currentWaveIndex )
        {
            roomEvents.roomCleared.Invoke();
            waveManagerInfo.remainingNumberOfWaves = 0;
            print("No waves.");
            return;
        }

        currentWave = waves[currentWaveIndex];
        currentWave.initSelf(roomEvents);
    }

    void updateWaveManagerInfo()
    {
        waveManagerInfo.remainingNumberOfWaves = waveManagerInfo.totalNumberOfWaves - currentWaveIndex;
        waveManagerInfo.isCompleted = waveManagerInfo.remainingNumberOfWaves == 0;
        //print("Remaining number of waves:" + waveManagerInfo.remainingNumberOfWaves);
    }

    public SpawnwaveManagerInfo getSpawnWaveManagerInfo() => waveManagerInfo;

}