using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : Singleton<Level>
{
    [SerializeField] private GameObject _levelPanel;

    public void ShowLevelCanvas()
    {
        _levelPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _levelPanel.SetActive(false);
    }
}
