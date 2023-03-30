using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TaskState
{
   ABANDONED,
   COMPLETED,
   FAILED,
   HIDDEN,
   IN_PROGRESS,
   INVALID,
   NOT_STARTED
}
