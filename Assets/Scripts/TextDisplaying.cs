﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplaying : MonoBehaviour
{

    public GameObject TextNoRessource;

    public GameObject TextRessource;

    public GameObject TextLadderBroken;
    public GameObject TextLadderFixed;

    public GameObject TextHammer;
    public GameObject TextPlanks;

    public GameObject Etabli;

    public CaseManager CaseManager;


    public bool EtabliNoRessource = false;
    public bool EtabliRessource = false;
    public bool LadderBroken = false;
    public bool LadderFixed = false;
    public bool hammerBool = false;
    public bool planksBool = false;

    public bool textDelay = true;

    private void Update()
    {
        if (EtabliNoRessource == true && textDelay == true)
        {
            textDelay = false;
            EtabliNoRessource = false;
            EtablietextNoRessources();
        }

        if(EtabliRessource == true && textDelay == true)
        {
            textDelay = false;
            EtabliRessource = false;
            CaseManager.HammerCheck = true;
            CaseManager.PlanksCheck = true;
            EtablietextRessources();
        }

        if (LadderBroken == true && textDelay == true)
        {
            textDelay = false;
            LadderBroken = false;
            LadderBrokenText();
        }

        if(LadderFixed == true && textDelay == true)
        {
            textDelay = false;
            LadderFixed = false;
            LadderFixedText();
        }

        if (hammerBool == true && textDelay == true)
        {
            textDelay = false;
            hammerBool = false;
            HammerText();
        }

        if(planksBool == true && textDelay == true)
        {
            textDelay = false;
            planksBool = false;
            PlanksText();
        }
    }

    public void EtablietextNoRessources()
    {
        StartCoroutine(ShowMessageNoRessource(2));
    }

    IEnumerator ShowMessageNoRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextNoRessource.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextNoRessource.SetActive(false);
        Etabli.GetComponent<BoxCollider>().enabled = true;
        textDelay = true;
    }

    public void EtablietextRessources()
    {
        StartCoroutine(ShowMessageRessource(2));
    }

    IEnumerator ShowMessageRessource(float delay)
    {
        Etabli.GetComponent<BoxCollider>().enabled = false;
        TextRessource.SetActive(true);
        CaseManager.Ladder = true;
        yield return new WaitForSeconds(delay);
        TextRessource.SetActive(false);
        textDelay = true;
    }

    public void LadderBrokenText()
    {
        StartCoroutine(ShowMessageLadderBroken(2));
    }

    IEnumerator ShowMessageLadderBroken(float delay)
    {
        TextLadderBroken.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextLadderBroken.SetActive(false);
        textDelay = true;
    }

    public void LadderFixedText()
    {
        StartCoroutine(ShowMessageLadderFixed(2));
    }

    IEnumerator ShowMessageLadderFixed(float delay)
    {
        TextLadderFixed.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextLadderFixed.SetActive(false);
        textDelay = true;
    }

    public void HammerText()
    {
        StartCoroutine(ShowMessageHammer(2));
    }

    IEnumerator ShowMessageHammer(float delay)
    {
        TextHammer.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextHammer.SetActive(false);
        textDelay = true;
    }

    public void PlanksText()
    {
        StartCoroutine(ShowMessagePlanks(2));
    }

    IEnumerator ShowMessagePlanks(float delay)
    {
        TextPlanks.SetActive(true);
        yield return new WaitForSeconds(delay);
        TextPlanks.SetActive(false);
        textDelay = true;
    }

   
}