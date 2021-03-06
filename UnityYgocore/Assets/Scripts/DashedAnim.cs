﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashedAnim : MonoBehaviour
{
    private RawImage image;

    private Texture texture1;
    private Texture texture2;

    private Texture texture_select;

    void Awake()
    {
        image = this.GetComponent<RawImage>();
        texture1 = Resources.Load("Texture/dashed1") as Texture;
        texture2 = Resources.Load("Texture/dashed2") as Texture;
        texture_select = Resources.Load("Texture/dashed_select") as Texture;
        gameObject.SetActive(false);
    }


    public void StartSelectState(bool isMySelect)//网络模式下，己方选择时才显示
    {
        if (Duel.GetInstance().IsNetWork)
        {
            if (isMySelect)
            {
                gameObject.SetActive(true);
                StartCoroutine(anim(texture2));
            }
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(anim(texture2));
        }
    }

    public void EndSelectState()
    {
        if (gameObject.activeSelf)
        {
            EndAnim();
            gameObject.SetActive(false);
            image.texture = texture1;
        }
    }

    private void EndAnim()
    {
        StopAllCoroutines();
    }

    IEnumerator anim(Texture tex)
    {
        yield return new WaitForSeconds(0.1f);
        image.texture = tex;
        if (image.texture == texture1)
            StartCoroutine(anim(texture2));
        else
            StartCoroutine(anim(texture1));
    }

    public void SetSelect()
    {
        EndAnim();
        image.texture = texture_select;

    }

    public void SetNotSelect()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(anim(texture2));
        }
    }
}
  





