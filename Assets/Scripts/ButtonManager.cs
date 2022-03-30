using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToGame_1(int input)
    {
        ManageCards.Mode = input;
        SceneManager.LoadScene("Game_1");
    }

    public void ToGame_2(int input)
    {
        ManageCards.Mode = input;
        SceneManager.LoadScene("Game_2");
    }

    public void ToGame_3(int input)
    {
        ManageCards.Mode = input;
        SceneManager.LoadScene("Game_3");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Reset(int input)
    {
        switch (input)
        {
            case 1:
                PlayerPrefs.SetInt("Recorde1", 999);
                break;

            case 2:
                PlayerPrefs.SetInt("Recorde2", 999);
                break;

            default:
                PlayerPrefs.SetInt("Recorde3", 999);
                break;
        }
    }
}
