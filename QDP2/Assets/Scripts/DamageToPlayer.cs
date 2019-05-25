using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageToPlayer : MonoBehaviour
{
    public int health;
    private int currentHealth;

	public Image healthBar;

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
            SceneManager.LoadScene("LosingScreen");
            Debug.Log("Player Died");
            
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Hit");
		healthBar.fillAmount = currentHealth / 9f;

    }
}
