using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationTask : Task
{
    public GameObject target;
    public Transform location;

    public LocationTask(string id, string name, Task prevTask, Task nextTask, GameObject taskTarget, Transform taskLocation, ProgressState state = ProgressState.NOT_STARTED) 
        : base(id, name, prevTask, nextTask, state)
    {
        this.target = taskTarget;
        this.location = taskLocation;
    }

    public override bool Condition()
    {
        return Vector3.Distance(target.transform.position, location.position) < 0.5f;
    }
}
