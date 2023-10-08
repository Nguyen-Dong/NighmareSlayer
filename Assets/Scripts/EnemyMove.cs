using UnityEngine;
public class AIController : MonoBehaviour
{
    public Transform Player;
    public float ChaseSpeed = 5f;
    public float Range = 5f;
    float CurrentSpeed;

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
}