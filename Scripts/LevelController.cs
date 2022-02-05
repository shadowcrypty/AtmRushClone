using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController 
{
    


    public void LevelUp(int CurrentLevel)
    {
        SceneManager.LoadScene(CurrentLevel+1);
        

    }
    public void LevelRepeat(int CurrentLevel)
    {
        SceneManager.LoadScene(CurrentLevel);

    }

}
