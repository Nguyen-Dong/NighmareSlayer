using UnityEngine;
public class AIController : MonoBehaviour
{
    public Transform Player;
    public float ChaseSpeed = 5f;
    public float Range = 5f;
    float CurrentSpeed;
    Health PlayerHealth;

    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= Range)
        {
            CurrentSpeed = ChaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, CurrentSpeed);
        }
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if(Player.position.x<transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth = collision.GetComponent<Health>();
            InvokeRepeating("DamagePlayer", 0, 1f);
        }
        if (collision.CompareTag("FireRange"))
        {
            FindObjectOfType<WeaponManager>().AddEnemyToFireRange(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("DamagePlayer");
            PlayerHealth = null;
        }
        if (collision.CompareTag("FireRange"))
        {
            FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
        }
    }
    void DamagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        PlayerHealth.TakeDam(damage);
        PlayerHealth.GetComponent<Player>().TakeDamageEffect(damage);
    }

}