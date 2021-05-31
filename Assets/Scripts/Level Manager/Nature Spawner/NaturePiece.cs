﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturePiece : MonoBehaviour
{
    [SerializeField] float precentage;
    float fixedDelta;
    float currentDelta;
    Animator animator;
	string animationName;
	[SerializeField] float currentState;
	[SerializeField] NatureType type;

	bool ready = false;
    
    public void initSelf()
    {
		
        animator = GetComponent<Animator>();
		animator.speed = 0;
		ready = true;
    }

    void Update()
    {
        //setCurrentFogState();
    }
	internal void setPrecent(float precentage)
	{
		this.precentage = precentage;
		fixedDelta = precentage;
	}

	internal void setCurrentFogState(float cDelta)
	{
		print($"Fixed delta: {fixedDelta}, cDelta {cDelta}");
		if ((cDelta <= fixedDelta))
		{
			animator?.Play("Base Layer." + animationName, 0, 0.99f);
		}
		else
		{
			currentState= (float)((fixedDelta / cDelta));
			//print("Type: " + type + "fixedDelta: " + fixedDelta + ", currentDelta: " + cDelta+", currentState: " + currentState);
            animator?.Play("Base Layer."+animationName, 0, currentState);

        }
    }

	internal void setType(NatureType type)
	{
		this.type = type;
		switch(type)
		{
			case NatureType.ROCK1:
				{
					animationName = "Rock1";

					break;
				}

			case NatureType.ROCK2:
				{
					animationName = "Rock2";
					break;
				}

			case NatureType.ROCK3:
				{
					animationName = "Rock3";
					break;
				}
			case NatureType.TREE1:
				{
					animationName = "Tree1";
					break;
				}
		}
	}
}
