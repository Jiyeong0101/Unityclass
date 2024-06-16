using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeStage()
    {
        SceneManager.LoadScene("Stage");
    }
    public void ChangeTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ChangeStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void ChangeStage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void ChangeStage4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void ChangeStage5()
    {
        SceneManager.LoadScene("Stage5");
    }
}
