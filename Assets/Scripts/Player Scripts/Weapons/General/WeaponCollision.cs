﻿using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            IVulnrable enemy = collision.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(pushback * 5, 25);
        }

		if (collision.CompareTag("ItemTent"))
		{
			IVulnrable tent = collision.GetComponent<IVulnrable>();
			tent.takeDamage(Vector3.zero, 0);
		}
	}
}

