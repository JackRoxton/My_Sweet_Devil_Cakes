using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : Singleton<MinigameManager>
{
    public MinigameBowl Bowl;
    public Spatula Spatula;
    public Image ProgressBar;
    bool soundFlag = false;

    void Update()
    {
        if (Bowl.turning)
        {
            ProgressBar.fillAmount += Time.deltaTime / 3;
            if(!soundFlag)
            {
                SoundManager.Instance.Play("Mix");
                soundFlag = true;
            }
            if(ProgressBar.fillAmount >= 1) 
            {
                GameManager.Instance.GrannyPick();
            }
        }
    }

    public void Clear()
    {
        ProgressBar.fillAmount = 0;
        soundFlag = false;
    }
}
