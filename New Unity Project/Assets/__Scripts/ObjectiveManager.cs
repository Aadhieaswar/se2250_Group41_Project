using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public List<Animator> objectives;

    [HideInInspector]
    public Dictionary<int, bool> objectiveChecks = new Dictionary<int, bool>();

    private void Awake()
    {
        // initialize the objectives check dictionary for the number of objectives present
        for (int i = 0; i < objectives.Count; i++)
        {
            objectiveChecks[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckObjectives();
    }

    public virtual void CheckObjectives()
    {
        // method to be overrided to check objectives
    }
}
