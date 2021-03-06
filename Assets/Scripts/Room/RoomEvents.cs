﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomEvents : MonoBehaviour
{
	bool ready = false;
	public UnityEvent dwindleLocalFog;
	public UnityEvent treePlanted;
	public UnityEvent roomCleared;
	public UnityEvent roomLeft;
	public UnityEvent roomEntered;

	public void initEvents()
	{
		dwindleLocalFog = new UnityEvent();
		treePlanted= new UnityEvent();
		roomCleared = new UnityEvent();
		roomLeft = new UnityEvent();
		roomEntered = new UnityEvent();

		ready = true;
	}

	public void removeAllListeners()
	{
		dwindleLocalFog.RemoveAllListeners();
		treePlanted.RemoveAllListeners();
		roomCleared.RemoveAllListeners();
		roomLeft.RemoveAllListeners();
		roomEntered.RemoveAllListeners();
	}





}
