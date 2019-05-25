using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;

    public Image healthBarEnemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Died");
            SceneManager.LoadScene("WinningScreen");
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy Hit");
        healthBarEnemy.fillAmount = currentHealth / 40f;
    }
}
