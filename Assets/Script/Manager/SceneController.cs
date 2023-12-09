using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;


// �÷��̾� ���� �κе� ���� ������ �ϱ� ������ ���� �����ϰ� ���� �����ϰ� ���� 

public class SceneController : DontDestroySingle<SceneController>
{
    [SerializeField] GameObject titleUi;
    [SerializeField] GameObject mainUi;
    [SerializeField] GameObject lobbyUi;
    [SerializeField] GameObject gameUi;
    [SerializeField] GameObject loadingUi;

    //[SerializeField] G

    List<GameObject> totalUi= new List<GameObject>(); 

    // [SerializeField] private GameObject lobbyMultiUi; //  ��Ƽ �� �� ��� ����
    private new void Awake()
    {
        base.Awake();
    }

    // �ϴ� ���������� ���ᰡ���ϰ� ����� ���� ����� ������ triggerEvnet Ŭ���� ����
    // ����ص� �� �װ� �� �� ���� �ϱ� ��.
    public void Option(string optionUi) // ���� ȭ�� �ɼ�
    {
        
        //OptionImage
        //Button option;
        //option = mainUi.GetComponentInChildren<Button>();

        //optionUi

        //if (optionUi
        //    optionUi.enabled = true;
        //else
        //    optionUi.enabled = false;

    }

    public void Explanation() // ���� ȭ�� ����â
    {
        // �̰� ���� �������� 
        Button explanation;
        explanation = mainUi.GetComponentInChildren<Button>();


    }


    private void Start()
    {
        LoadScene("TitleScene");

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


    private void Update()
    {
        Option("optionUi");
    }

}

