using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Projectiles;


    void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }


    IEnumerator SpawnProjectiles()
    {
        while(true)
        {
            int randomProjectile = Random.Range(0, 7);
            Instantiate(Projectiles[randomProjectile], new Vector3(Random.Range(-5.2f, 5.2f), 3.25f, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }


}
