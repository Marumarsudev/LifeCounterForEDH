using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Player : MonoBehaviour
{
    public RectTransform rectTransform;

    public SpriteRenderer poisonSprite;
    public SpriteRenderer playerSprite;

    public TextMeshProUGUI lifeText;

    public int life;
    public int poison;

    private bool isPoison = false;

    public void InitPlayer(int _life, Vector2 _pos, Vector3 _rot)
    {
        life = _life;
        poison = 0;

        lifeText.text = _life.ToString();

        rectTransform.localPosition = _pos;
        rectTransform.localRotation = Quaternion.Euler(_rot);
    }

    public void ChangeColor(Color color)
    {
        playerSprite.color = color;
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

    public void FlashStarter()
    {
        lifeText.DOColor(Color.yellow, 0.2f)
        .SetEase(Ease.Flash)
        .SetLoops(9, LoopType.Yoyo)
        .OnComplete(() => {lifeText.DOColor(Color.white, 0.5f);});
    }

    private void FlashCounter(Color color)
    {
        lifeText.DOColor(color, 0.2f)
        .OnComplete(() => {lifeText.DOColor(Color.white, 0.2f);});
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
            playerSprite.DOFade(0, 0.5f);
            poisonSprite.DOFade(1, 0.5f);
        }
        else
        {
            playerSprite.DOFade(1, 0.5f);
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
        if(value < 0)
        {
            FlashCounter(Color.red);
        }
        else
        {
            FlashCounter(Color.green);
        }
    }

    private void ChangePoison(int value)
    {
        poison += value;
    }
}
