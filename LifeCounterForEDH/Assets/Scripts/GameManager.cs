using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    List<Player> players = new List<Player>();
    public float bottomRowY;
    public float topRowY;
    public float xMargin;
    public float yMargin;
    public float spacing;

    public Transform tCanvas;

    public TextMeshProUGUI gameTimeText;

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
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        gameTimeText.text = GetTimerString(Mathf.RoundToInt(gameTime));

    }
}
