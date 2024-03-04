using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTutorialManager : MonoBehaviour
{
    TutorialComponent tutorial;

    public void AddTutorial(TutorialComponent _tutorial)
    {
        tutorial = _tutorial;
    }

    public void TutorialDetail()
    {
        TutorialDetailManager.GetInstance().ClearAllData();

        TutorialDetailManager.GetInstance().headerTutorial = tutorial.headerTutorial;
        TutorialDetailManager.GetInstance().bodyTutorial = tutorial.bodyTutorial;
        TutorialDetailManager.GetInstance().imageTutorial = tutorial.imageTutorial;
        TutorialDetailManager.GetInstance().SetActivate(true);
    }
}
