using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    [Header("Task Properties")]
    public string id;
    public string name;
    public Task prevTask;
    public Task nextTask;
    public ProgressState state;
    public ProgressStateText text;

    public Task(string id, string name, Task prevTask, Task nextTask, ProgressState state = ProgressState.NOT_STARTED)
    {
        this.id = id;
        this.name = name;
        this.prevTask = prevTask;
        this.nextTask = nextTask;
        this.state = state;

        // if this task has a previous as a dependency then this task is INVALID and can't be started
        if ((prevTask != null) && (prevTask.state != ProgressState.COMPLETED))
        {
            this.state = ProgressState.INVALID;
        }
    }

    public virtual bool Condition()
    {
        return false;
    }
}
