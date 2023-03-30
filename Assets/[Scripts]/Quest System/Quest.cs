using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest 
{
    public string id;
    public string name;
    public ProgressState state;
    public ProgressStateText text;
    public List<Task> tasks;

    public Quest(string id, string name, Task rootTask, ProgressState state = ProgressState.NOT_STARTED)
    {
        this.id = id;
        this.name = name;
        this.state = state;
        tasks = new List<Task> { rootTask }; // creates a new empty Task container
    }

    public virtual void BuildQuest()
    {

    }
}
