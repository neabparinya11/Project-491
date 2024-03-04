using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTaskManager : MonoBehaviour
{
    TaskComponent task;

    public void AddTask(TaskComponent _task)
    {
        task = _task;
    }
    public void TaskDetail()
    {
        TaskDetailManager.GetInstance().ClearAllDetail();

        TaskDetailManager.GetInstance().taskHeader = task.headTask;
        TaskDetailManager.GetInstance().taskDetail = task.descriptionTask;
        TaskDetailManager.GetInstance().SetctivtePanel(true);
    }
}
