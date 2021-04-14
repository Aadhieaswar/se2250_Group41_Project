using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesForLevel : ObjectiveManager
{
    public Sub_Spawner subSpawner;

    [HideInInspector] public bool subBossAlive;
    [HideInInspector] public bool notEnteredPortal;

    #region Singleton
    public static ObjectivesForLevel S;

    private void Start()
    {
        S = this;
        subBossAlive = true;
        notEnteredPortal = true;
    }
    #endregion

    public override void CheckObjectives()
    {
        base.CheckObjectives();

        // check objective 1
        if (subSpawner.killsNeeded == Sub_Spawner.killCount && !objectiveChecks[0])
        {
            objectives[0].SetTrigger("Complete");
            objectiveChecks[0] = true;
        }

        // check objective 2
        if (!subBossAlive && !objectiveChecks[1])
        {
            objectives[1].SetTrigger("Complete");
            objectiveChecks[1] = true;
        }

        // check objective 3
        if (!notEnteredPortal && !objectiveChecks[2])
        {
            objectives[2].SetTrigger("Complete");
            objectiveChecks[2] = true;
        }
    }
}
