using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    //Set fields to detece if specific subbosses are defeated
    private static bool _subBossOneDefeated = false;
    private static bool _subBossTwoDefeated = false;
    //set fields of game objects for the projectiles and where the projectiles will instantiate from
    [SerializeField] private GameObject attackOneProjectile;
    [SerializeField] private GameObject attackTwoProjectile;
    [SerializeField] private GameObject attackShooter;
    //fields to create a delay in firing
    private float currentTime;
    private float interval;
    // Start is called before the first frame update
    void Start()
    {
        //Set the current time and interval variables (will create an interval of 5)
        currentTime = 0.0f;
        interval = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //if either of the subbosses are defeated, fire the projectiles depending on the key
        //space for fire attack, q for grass attack
        if (SubBossOneDefeated || SubBossTwoDefeated) {
            if (Input.GetKey("q")) {
                FireAttackOne();
            }
            if (Input.GetKey(KeyCode.Space)) {
                FireAttackTwo();
            }
        }
        currentTime += Time.deltaTime;
    }

    //Create getters and setters to set the subBossDefeated fields to true
    public bool SubBossOneDefeated {
        get {
            return _subBossOneDefeated;
        }

        set {
            _subBossOneDefeated = true;
        }
    }

    public bool SubBossTwoDefeated
    {
        get
        {
            return _subBossTwoDefeated;
        }

        set
        {
            _subBossTwoDefeated = true;
        }
    }

    //Fire the projectiles, create an interval of 5 seconds for grass attack, 7 for fire attack
    public void FireAttackOne() {
        if (currentTime > interval) {
            Instantiate(attackOneProjectile, attackShooter.transform.position, Quaternion.Euler(0f, 0f, 0f));
            currentTime = 0.0f;
        }
     }

    public void FireAttackTwo() {
        if (currentTime > interval + 2)
        {
            Instantiate(attackTwoProjectile, attackShooter.transform.position, Quaternion.Euler(0f, 0f, 0f));
            currentTime = 0.0f;
        }
    }
}
