using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class PatrolQuest : Quest
{
    public GameObject target;
    public Transform startLocation;
    public List<Transform> checkPoints;

    public PatrolQuest(string id, string name, LocationTask rootTask, ProgressState state = ProgressState.NOT_STARTED) 
        : base(id, name, rootTask, state)
    {
        target = rootTask.target;
        startLocation = rootTask.location;

        BuildQuest();
    }

    public override void BuildQuest()
    {
        checkPoints = new List<Transform>();

        // add as many location tasks as there are transforms
        for (int i = 0; i < checkPoints.Count; i++)
        {
            tasks.Add(new LocationTask("task " + i, "Location " + i, (i > 0) ? tasks[i - 1] : null, null, target, checkPoints[i]));
        }

        // create links (relationships) between tasks
        for (int i = 0; i < tasks.Count; i++)
        {
            tasks[i].nextTask = (i < tasks.Count - 1) ? tasks[i + 1] : null;
        }
    }
}
