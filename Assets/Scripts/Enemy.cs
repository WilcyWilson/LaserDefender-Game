using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100;
    public int enemyScore = 50;

    [Header("Shots")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    float shotCounter;

    [Header("Projectile")]
    [SerializeField] GameObject enemyProjectile = default;
    [SerializeField] float projectileSpeed = 5f;

    VFX vfx;
    SFX sfx;
    GameSession game;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        vfx = FindObjectOfType<VFX>();
        sfx = FindObjectOfType<SFX>();
        game = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        var laser = Instantiate(enemyProjectile,
                                        transform.position,
                                        Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -projectileSpeed);
        sfx.EnemyShootingSFX();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        vfx.ExplodeEnemyVFX(this.gameObject);
        sfx.EnemyKilledSFX();
        game.AddToScore(enemyScore);
    }
}
