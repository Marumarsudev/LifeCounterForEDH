using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI playerCountText;
    public TextMeshProUGUI startingLifeText;

    public Toggle alternativeSeatingToggle;

    void Start()
    {
        startingLifeText.text = string.Format("Starting Life : {0}", Settings.StartingLife);
        playerCountText.text = string.Format("Players : {0}", Settings.PlayerCount);
        alternativeSeatingToggle.isOn = Settings.AlternativeSeating;
    }

    public void ChangeSeating(bool value)
    {
        Settings.AlternativeSeating = alternativeSeatingToggle.isOn;

        Debug.Log(Settings.AlternativeSeating);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChangeStartingLife(int value)
    {
        Settings.StartingLife += value;
        startingLifeText.text = string.Format("Starting Life : {0}", Settings.StartingLife);
    }

    public void ChangePlayerCount(int value)
    {
        Settings.PlayerCount += value;
        playerCountText.text = string.Format("Players : {0}", Settings.PlayerCount);
    }
}
