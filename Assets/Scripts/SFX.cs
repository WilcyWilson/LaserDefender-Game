using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [Header("Enemy Killed")]
    [SerializeField] AudioClip enemyKilledClip = default;
    [SerializeField] [Range(0, 1)] float enemyKilledVolume = 1f;

    [Header("Enemy Shooting")]
    [SerializeField] AudioClip enemyShootingClip = default;
    [SerializeField] [Range(0, 1)] float enemyShootingVolume = 1f;

    [Header("Player Killed")]
    [SerializeField] AudioClip playerKilledClip = default;
    [SerializeField] [Range(0, 1)] float playerKilledVolume = 1f;

    [Header("Player Shooting")]
    [SerializeField] AudioClip playerShootingClip = default;
    [SerializeField] [Range(0, 1)] float playerShootingVolume = 1f;

    public void EnemyKilledSFX()
    {
        AudioSource.PlayClipAtPoint(enemyKilledClip, Camera.main.transform.position, enemyKilledVolume);
    }

    public void EnemyShootingSFX()
    {
        AudioSource.PlayClipAtPoint(enemyShootingClip, Camera.main.transform.position, enemyShootingVolume);
    }

    public void PlayerKilledSFX()
    {
        AudioSource.PlayClipAtPoint(playerKilledClip, Camera.main.transform.position, playerKilledVolume);
    }

    public void PlayerShootingSFX()
    {
        AudioSource.PlayClipAtPoint(playerShootingClip, Camera.main.transform.position, playerShootingVolume);
    }

}
