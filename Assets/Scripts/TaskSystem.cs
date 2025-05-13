using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    public List<Task> tasksList;
    public List<TaskObject> spawnedTaskObjects;

    public GameObject taskPrefab;

    public static Action<ObjectData> objectDestroyed = default;

    private IEnumerator timerTaskCoroutine;

    private void Awake()
    {
        objectDestroyed += UpdateTasks;
        foreach(Task _task in tasksList)
        {
            GameObject _spawnedObject = Instantiate(taskPrefab, transform);
            TaskObject _taskObject  = _spawnedObject.GetComponent<TaskObject>();

            _taskObject.taskMessage = _task.taskMessage;
            _taskObject.taskGoal = _task.taskGoal;
            _taskObject.targetShape = _task.shape;
            _taskObject.isTimer = _task.isTimer;

            _taskObject.InitializeTask();

            spawnedTaskObjects.Add(_taskObject);
        }

        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while(spawnedTaskObjects[0].progress != spawnedTaskObjects[0].taskGoal)
        {
            yield return new WaitForSecondsRealtime(1);
            spawnedTaskObjects[0].UpdateTaskProgress();
        }
    }

    public void UpdateTasks(ObjectData _objData)
    {
        for(int i = 1; i < spawnedTaskObjects.Count; i++)
        {
            spawnedTaskObjects[i].UpdateTaskProgress(_objData.objectShape);
        }
    }

    private void OnDestroy()
    {
        objectDestroyed -= UpdateTasks;
    }
}

public enum Shape {Any, Sphere, Cube}

public class ObjectData
{ 
    public Shape objectShape;
    public Color objectColor;

    public ObjectData(Shape objectShape, Color objectColor)
    {
        this.objectShape = objectShape;
        this.objectColor = objectColor;
    }
}

[System.Serializable]
public class Task
{
    public string taskMessage;

    public float taskGoal;

    public Shape shape;

    public bool isTimer;
}