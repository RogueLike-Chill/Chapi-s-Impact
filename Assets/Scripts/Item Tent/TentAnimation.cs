using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentAnimation : MonoBehaviour
{
    Animator animator;
	ItemTent tentM;
	bool ready = false;
	internal void initSelf()
	{
        animator = GetComponent<Animator>();
		tentM = GetComponent<ItemTent>();
		ready = true;
	}
	private void Update()
	{
		if (ready)
		{
			setTentAnimationStates(tentM.getTentInfo());
		}
	}
	public void setTentAnimationStates(ItemTentInfo info)
	{
		if (info.collapsed)
		{
			animator.SetBool("Collapsed", true);
			ready = false;
		}

		animator.SetBool("Hurt", info.isHurt);

	}

	public void stopAnimating()
	{
		animator.speed = 0;
	}
}
