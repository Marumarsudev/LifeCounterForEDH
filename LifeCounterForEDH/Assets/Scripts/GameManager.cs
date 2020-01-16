using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    List<Player> players = new List<Player>();
    public float xMargin;
    public float yMargin;
    public float spacing;

    public Transform tCanvas;

    public TextMeshProUGUI gameTimeText;

    public List<Color> playerColors = new List<Color>();

    private float gameTime;

    private string GetTimerString(int secs)
    {
        int hours = secs / 3600;
        int mins = (secs % 3600) / 60;
        secs = secs % 60;
        return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, secs);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
        CreatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        gameTimeText.text = GetTimerString(Mathf.RoundToInt(gameTime));

    }

    public void StopGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void GenerateRows(int startPos, int countPerRow)
    {
        GameObject temp;
        for (int i = 1; i >= -1; i -= 2)
        {
            for (int j = startPos; j < countPerRow + startPos; j++)
            {
                temp = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, tCanvas);
                Vector3 rot;
                if(i == -1)
                    rot = new Vector3(0,0,0);
                else
                    rot = new Vector3(0,0,180);
                temp.GetComponent<Player>().InitPlayer(Settings.StartingLife, new Vector2(-xMargin + (j * spacing), yMargin * i), rot);

                players.Add(temp.GetComponent<Player>());
            }
        }
    }

    private void GenerateSides(bool both, bool two = false, float marginChange = 0f)
    {
        GameObject temp;

        
        temp = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0,0,90), tCanvas);
        temp.GetComponent<Player>().InitPlayer(Settings.StartingLife, new Vector2(xMargin + marginChange, 0), new Vector3(0,0,90));
        if(two)
        {
            temp.transform.localScale = (Vector3.one * 1.75f);
        }
        players.Add(temp.GetComponent<Player>());

        if(both)
        {
            temp = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0,0,-90), tCanvas);
            temp.GetComponent<Player>().InitPlayer(Settings.StartingLife, new Vector2(-xMargin - marginChange, 0), new Vector3(0,0,-90));
            if(two)
            {
                temp.transform.localScale = (Vector3.one * 1.75f);
            }
            players.Add(temp.GetComponent<Player>());
        }

    }

    private void CreatePlayers()
    {
        switch(Settings.PlayerCount)
        {
            case 2:
                xMargin -= 140;
                tCanvas.localScale = (Vector3.one * 1.5f);
                GenerateSides(true, true);
            break;

            case 3:
                yMargin -= 40;
                tCanvas.localScale = (Vector3.one * 1.5f);
                spacing += 24;
                xMargin -= 120;
                GenerateSides(false);
                GenerateRows(1,1);
            break;

            case 4:
                yMargin -= 60;
                xMargin -= 170;
                tCanvas.localScale = (Vector3.one * 1.5f);
                spacing *= 1.8f;
                GenerateRows(0,2);
            break;

            case 5:
                yMargin -= 40;
                xMargin -= 120;
                tCanvas.localScale = (Vector3.one * 1.3f);
                spacing += 1.3f;
                GenerateSides(false);
                GenerateRows(0,2);
            break;

            case 6:
                if(Settings.AlternativeSeating)
                {
                    xMargin += 40;
                    spacing += 40;
                    tCanvas.localScale = (Vector3.one * 1.2f);
                    GenerateRows(1,2);
                    GenerateSides(true, false, -50);
                }
                else
                {
                    xMargin += 40;
                    tCanvas.localScale = (Vector3.one * 1.2f);
                    spacing *= 1.1f;
                    spacing += 40;
                    tCanvas.GetComponent<RectTransform>().localPosition = new Vector3(144,0,0);
                    GenerateRows(0,3);
                }
            break;

            case 7:
                yMargin -= 20;
                xMargin -= 60;
                tCanvas.localScale = (Vector3.one * 1.2f);
                spacing += 1.3f;
                GenerateSides(false, false, 35);
                GenerateRows(0,3);
            break;

            case 8:
                yMargin -= 10;
                xMargin += 50;
                spacing += 30;
                GenerateRows(0,4);
            break;
        }

        Debug.Log(players.Count);
        players[Random.Range(0, players.Count)].FlashStarter();
        for (int i = 0; i < players.Count; i++)
        {
            players[i].ChangeColor(playerColors[i]);
        }
    }
}
