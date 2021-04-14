using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    private static bool _subBossOneDefeated = false;
    private static bool _subBossTwoDefeated = false;
    [SerializeField] private GameObject attackOneProjectile;
    [SerializeField] private GameObject attackTwoProjectile;
    [SerializeField] private GameObject attackShooter;
    private float currentTime;
    private float interval;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        interval = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SubBossOneDefeated);
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
