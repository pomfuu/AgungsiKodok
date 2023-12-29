using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{

    public static CollectiblesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int collectibleCount;
    public int extraLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCollectible(int amount)
    {
        collectibleCount += amount;
        if(collectibleCount >= extraLife) {
            collectibleCount -= extraLife;

            if(LifeController.instance != null) { 
                LifeController.instance.AddLife();
            }
        }

        if(UIController.instance != null)
        {
            UIController.instance.UpdateCollect(collectibleCount);
        }
    }
}
