using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthtoAdd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.AddHealth(healthtoAdd); 
                Destroy(gameObject);
            }
        }
    }
}
