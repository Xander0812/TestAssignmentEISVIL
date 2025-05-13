using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class TaskObject : MonoBehaviour
{
    [HideInInspector] public string taskMessage;

    [HideInInspector] public float taskGoal;

    [HideInInspector] public Shape targetShape;

    [HideInInspector] public bool isTimer;

    [HideInInspector] public int progress;

    public Text taskText;

    public Slider taskSlider;

    public GameObject handle;

    public Image fillBarImage;

    public Color defaultColor;

    public Color completeColor;


    public void InitializeTask()
    {
        UpdateText(0);
        taskSlider.value = 0 / taskGoal;
    }

    public void UpdateTaskProgress(Shape shape = Shape.Any)
    { 
        if(targetShape == Shape.Any || shape == targetShape)
        {
            if(progress >= taskGoal)
            {
                return;
            }

            ++progress;

            

            UpdateText(progress);
            taskSlider.value = progress / taskGoal;

            fillBarImage.color = Color.Lerp(defaultColor,completeColor,taskSlider.value);

            if(progress >= taskGoal)
            {
                handle.SetActive(true);
            } 
        }
    }

    private void UpdateText(float _progress)
    {
        taskText.text = isTimer ? 
        taskMessage + " " + taskGoal + " seconds" + " (" + _progress + "/" + taskGoal + ")" : 
        taskMessage + " " + taskGoal + " " + targetShape + " shapes" + " (" + _progress + "/" + taskGoal + ")";
    }
}
