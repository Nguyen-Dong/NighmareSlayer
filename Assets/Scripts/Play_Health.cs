using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Play_Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currenHealth;

    public HealthBar healthBar;

    public UnityEvent OnDeath;

    public float safeTime;
    float _safeTimeCooldowm;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }
    public void Start()
    {
        currenHealth = maxHealth;

        healthBar.UpdateBar(currenHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_safeTimeCooldowm <= 0)
        {
            currenHealth -= damage;

            if (currenHealth <= 0)
            {
                currenHealth = 0;
                OnDeath.Invoke();
            }

            _safeTimeCooldowm = safeTime;
            healthBar.UpdateBar(currenHealth, maxHealth);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        _safeTimeCooldowm -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
