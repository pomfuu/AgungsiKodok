using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this; 
    }

    public int currentHealth, maxHealth;
    public float invicibilityLength = 1f;
    private float invicibilityCounter;

    public SpriteRenderer theSR;
    public Color normalColor, fadeColor;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if(invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;
            if(invicibilityCounter <= 0 ) {
                theSR.color = normalColor;
            }
        }
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H))
        {
            AddHealth(1);
        }
#endif
    }

    public void DamagePlayer()
    {
        if(invicibilityCounter <= 0)
        {
         //   invicibilityCounter = invicibilityLength;
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                // gameObject.SetActive(false);
                LifeController.instance.Respawn();
            } else
            {
                invicibilityCounter = invicibilityLength;
                theSR.color = fadeColor;
                thePlayer.KnockBack();
            }
            UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);

        }
    }
    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay(currentHealth, maxHealth);

    }
}
