using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveForFinalLevel : ObjectiveManager
{
    public FinalBossStats finalBossStats;

    public override void CheckObjectives()
    {
        base.CheckObjectives();

        if (!finalBossStats.isAlive && !objectiveChecks[0])
        {
            objectives[0].SetTrigger("Complete");
            objectiveChecks[0] = true;
        }
    }
}
