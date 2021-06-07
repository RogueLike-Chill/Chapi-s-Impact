using System.Collections;
using UnityEngine;

public class TrashcanAttacking : MonoBehaviour
{

    Trashcan enemyM;
    bool attacking = false;

    //[SerializeField] TrashParticle particle;
    [SerializeField] TrashParticle[] particles;
    [Header("Range of particles to spawn")]
    [SerializeField] int min;
    [SerializeField] int max;

    void Start()
    {
        enemyM= GetComponent<Trashcan>();
    }
    public bool isAttacking() => attacking;

    void attack()
    {
        StartCoroutine(spawnCigaretteParticles());
    }

    IEnumerator spawnCigaretteParticles()
    {
        int amount = Random.Range(min, max);

        Vector3 offset = new Vector3(0, 3, 0);
        Vector3 spawnPosition = transform.position + offset;
        for (int i=0; i<amount; i++)
        {
            //if (i%2==0)
            Instantiate<TrashParticle>(particles[Random.Range(0,particles.Length)], spawnPosition , Quaternion.identity).transform.SetParent(this.transform);
            yield return null;
        }
        attacking = false;
    }

    internal void approveAttack()
    {
        attacking = true;
    }
}
