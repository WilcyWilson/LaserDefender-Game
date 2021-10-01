using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [Header("Enemy VFX")]
    [SerializeField] GameObject enemydeathVFX = default;
    [SerializeField] float enemyDurationOfExplosion = 1f;

    [Header("Player VFX")]
    [SerializeField] GameObject playerdeathVFX = default;
    [SerializeField] float playerDurationOfExplosion = 1f;

    public void ExplodeEnemyVFX(GameObject callingObject)
    {
        GameObject explosion = Instantiate(enemydeathVFX,
                                           callingObject.transform.position, 
                                           callingObject.transform.rotation) as GameObject;
        Destroy(explosion, enemyDurationOfExplosion);
    }

    public void ExplodePlayerVFX(GameObject callingObject)
    {
        GameObject explosion = Instantiate(playerdeathVFX,
                                           callingObject.transform.position,
                                           callingObject.transform.rotation) as GameObject;
        Destroy(explosion, playerDurationOfExplosion);
    }
}
