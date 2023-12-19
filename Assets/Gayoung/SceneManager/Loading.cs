using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Hojun;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class Loading : MonoBehaviour
{

    public Slider progressBar;
    public Image barColor;
    public TextMeshProUGUI loadtext;
    public PlayManager playManager;
    public PhotonView photon;

    //private float completeTime = 1f;
    //private float uncompleteTime = 0.9f;

    public bool NextSceneCondition 
    {
        get
        {
            return playManager.PlayerCondition;
        }    
    }

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    



    IEnumerator LoadScene()
    {
        yield return null;
        // LoadSceneAsync() �񵿱�ε�.
        // Scene�� �ҷ����� �Ϸ���� �ٸ� �۾��� �������� ����.
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
        // �ε��� ������ ����.
        operation.allowSceneActivation = false;


        while (!operation.isDone)
        {
            yield return null;

            //Color sliderColor = Color.Lerp(Color.white, Color.blue, completeTime);
            //barColor.color = sliderColor;

            if (progressBar.value < 0.9f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime);
            }


            if (progressBar.value >= 1f)
            {
                playManager.Broad();
                break;
            }

        }

        yield return new WaitUntil( () => NextSceneCondition );
        operation.allowSceneActivation = true;
    }

}
