using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // config params
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 200;
    [SerializeField] int healthCount = 3;
    int mainHealth;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab = default;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("Input Manager Controls")]
    [SerializeField] string horizontalButton = default;
    [SerializeField] string verticalButton = default;
    [SerializeField] string fireButton = default;

    VFX vfx;
    SFX sfx;
    Level level;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    int magicNumber = 2;
    GameSession game;
    Vector2 originalPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        level = FindObjectOfType<Level>();
        if (level.singlePlayer)
        {
            GameObject.Find("Player2").SetActive(false);
        }
    }
    void Start()
    {
        SetUpMoveBoundaries();
        vfx = FindObjectOfType<VFX>();
        sfx = FindObjectOfType<SFX>();
        
        game = FindObjectOfType<GameSession>();
        mainHealth = health;
        originalPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis(horizontalButton) * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis(verticalButton) * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
        var newYPos = Mathf.Clamp((transform.position.y + deltaY), yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown(fireButton) && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp(fireButton) && !Input.GetButton(fireButton))
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                    laserPrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            sfx.PlayerShootingSFX();
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
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
        if (damageDealer.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (health > 0)
            {
                vfx.ExplodeEnemyVFX(damageDealer.gameObject);
                sfx.EnemyKilledSFX();
                game.AddToScore(damageDealer.gameObject.GetComponent<Enemy>().enemyScore);
            }
        }
        damageDealer.Hit();
        if (health <= 0)
        {
            healthCount--;
            vfx.ExplodePlayerVFX(this.gameObject);
            sfx.PlayerKilledSFX();
            transform.position = originalPosition;
            health = mainHealth;
            if (healthCount == 0)
            {
                Die();
            }
        }
    }

    public int GetHealth()
    {
        if (health <= 0 || GetHealthCount()==0)
        {
            health = 0;
        }
        return health;
    }

    public int GetHealthCount()
    {
        return healthCount;
    }

    private void Die()
    {
        Destroy(gameObject);
        if (FindObjectsOfType<Player>().Length < magicNumber)
        {
            level.LoadGameOver();
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + GetComponent<SpriteRenderer>().bounds.size.x / 2;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - GetComponent<SpriteRenderer>().bounds.size.x / 2;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + GetComponent<SpriteRenderer>().bounds.size.y / 2;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
}
