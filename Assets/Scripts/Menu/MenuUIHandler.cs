using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI resetText;

    private int resetConfirm;

    private void Awake()
    {
        if (DataManager.Instance.BestScore != 0)
        {
            bestScoreText.text = "Best Score: " + DataManager.Instance.BestScoreName + " : " + DataManager.Instance.BestScore;
        }
    }

    public void StartNew()
    {
        DataManager.Instance.Name = nameText.text;
        SceneManager.LoadScene(1);
    }

    public void ResetBtn()
    {
        if (resetConfirm == 0)
        {
            resetConfirm = 1;
            resetText.text = "Sure ?";
        }
        else
        {
            DataManager.Instance.BestScore = 0;
            DataManager.Instance.BestScoreName = null;
            DataManager.Instance.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    


    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
