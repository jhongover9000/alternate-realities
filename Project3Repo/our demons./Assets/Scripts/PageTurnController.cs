using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurnController : MonoBehaviour
{
    public MegaBookBuilder book;
    public Transform pageTurner;
    public Transform pageTurnStart;

    public AudioSource[] voiceOvers;
    public float pageTurnHintAmount = 0.1f;

    float currentPage = 0;

    public void TurnPage(float amount)
    {
        book.page = currentPage + amount;
    }

    public void HintPageTurn()
    {

    }

    public void ResetForNextPage()
    {
        if (currentPage < voiceOvers.Length && voiceOvers[(int)currentPage] !=null)
        {
            if(currentPage > 0)
            {
                if(voiceOvers[(int)currentPage - 1].isPlaying)
                {
                    voiceOvers[(int)currentPage - 1].Stop();
                }
            }
            voiceOvers[(int)currentPage].Play();
        }

        if (currentPage < book.GetPageCount())
        {
            currentPage++;
            pageTurner.position = pageTurnStart.position;
        }
        else if (currentPage == book.GetPageCount())
        {
            pageTurner.gameObject.SetActive(false);
        }
    }

   
}

