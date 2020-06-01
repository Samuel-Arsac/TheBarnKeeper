﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMonstreDepop : MonoBehaviour
{
    public GameObject Monstre;
    public GameObject Pop;
    public GameObject Depop;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Monstre.SetActive(false);
            Pop.SetActive(false);
            Depop.SetActive(false);
        }
    }
}
