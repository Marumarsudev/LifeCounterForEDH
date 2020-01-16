using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Player : MonoBehaviour
{
    public RectTransform rectTransform;

    public SpriteRenderer poisonSprite;

    public TextMeshProUGUI lifeText;

    public int life;
    public int poison;

    private bool isPoison = false;

    public void InitPlayer(int _life, Vector2 _pos, Vector3 _rot)
    {
        life = _life;
        poison = 0;

        lifeText.text = _life.ToString();

        rectTransform.position = _pos;
        rectTransform.rotation = Quaternion.Euler(_rot);
    }

    private void UpdateUI()
    {
        if(isPoison)
        {
            lifeText.text = poison.ToString();
        }
        else
        {
            lifeText.text = life.ToString();
        }
    }

    public void SwapPoison()
    {
        isPoison = !isPoison;

        lifeText.DOFade(0, 0.25f).OnComplete(() =>
        {
            UpdateUI();
            lifeText.DOFade(1, 0.25f);
        });

        if(isPoison)
        {
            poisonSprite.DOFade(1, 0.5f);
        }
        else
        {
            poisonSprite.DOFade(0, 0.5f);
        }
    }

    public void ChangeCounter(int value)
    {
        if(isPoison)
        {
            ChangePoison(value);
        }
        else
        {
            ChangeLife(value);
        }
        UpdateUI();
    }

    private void ChangeLife(int value)
    {
        life += value;
    }

    private void ChangePoison(int value)
    {
        poison += value;
    }
}
