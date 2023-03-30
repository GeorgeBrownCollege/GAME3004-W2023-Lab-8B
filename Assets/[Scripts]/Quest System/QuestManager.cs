using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class QuestManager : MonoBehaviour
{
    public GameObject player;
    public Transform startLocation;
    public List<Quest> quests;
    public PatrolQuest currentQuest;
    public List<Transform> patrolPath;

    // Start is called before the first frame update
    void Start()
    {
        currentQuest = new PatrolQuest("Patrol1", "Patrol the Area",
            new LocationTask("locationTask1", "Patrol Start Location", null, null, player, startLocation), patrolPath);

        quests.Add(currentQuest);
        currentQuest.state = ProgressState.IN_PROGRESS;
        currentQuest.BuildQuest();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentQuest.state == ProgressState.IN_PROGRESS)
        {
            if (currentQuest.currentTask.Condition())
            {
                currentQuest.currentTask.state = ProgressState.COMPLETED;
                print(currentQuest.currentTask.name + " is complete!");
                if (currentQuest.currentTask.nextTask != null)
                {
                    currentQuest.currentTask = currentQuest.currentTask.nextTask;
                    currentQuest.currentTask.state = ProgressState.IN_PROGRESS;
                }
                else
                {
                    print(currentQuest.name + " is complete!");
                    currentQuest.state = ProgressState.COMPLETED;
                }
            }
        }
    }
}
