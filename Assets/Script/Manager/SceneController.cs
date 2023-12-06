using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;


public class SceneController : DontDestroySingle<SceneController>
{
    [SerializeField] GameObject titleUi;
    [SerializeField] GameObject mainUi;
    [SerializeField] GameObject lobbyUi;
    [SerializeField] GameObject gameUi;
    [SerializeField] GameObject loadingUi;


    List<GameObject> totalUi; 

    // [SerializeField] private GameObject lobbyMultiUi; //  ��Ƽ �� �� ��� ����
    private new void Awake()
    {
        base.Awake();
        
    }

   
    private void Start()
    {
        LoadScene("TitleScene");

        totalUi = new List<GameObject>();
        totalUi.Add(titleUi);
        totalUi.Add(mainUi);
        totalUi.Add(lobbyUi);
        totalUi.Add(gameUi);
        totalUi.Add(loadingUi);

    }

   
    public void ChangeScene(string sceneName)
    {
        foreach (GameObject ui in totalUi) 
        {
            ui.SetActive(false);
        }

        // �����丵 �ؾ��� �� �ڵ� ������...?
        switch (sceneName)
        {
            case "TitleScene":
                titleUi.SetActive(true);
                break;

            case "MainScene":
                mainUi.SetActive(true);
                break;

            case "LobbySceneSingle":
                lobbyUi.SetActive(true);
                break;

            case "GameScene":
                gameUi.SetActive(true);
                break;

            case "LoadingScene":
                loadingUi.SetActive(true);
                break;
            //case "LobbyMultiScene":
            //  ��Ƽ �� �� ��� ����
            //    break;
        }

    }


    //button click component [SerializeField] use
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        instance.ChangeScene(sceneName);
   
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        //Debug.Log("���� ����"); �۵� Ȯ��
    }


}
