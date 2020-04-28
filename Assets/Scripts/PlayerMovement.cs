﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Character")]
    public CharacterController controller;
    public GameObject Player;

    int WayClimb = 1;
    float climbTimer;
    bool isClimbing;
    bool canClimbing;
    bool lookAt;
    bool canWalk = true;
    bool LightOn = false;
    public static bool useRaycast;
    [HideInInspector] public Raycast myRaycast;
    public GameObject LanternLight;

    [Header("Camera")]
    public CinemachineVirtualCamera VirtualCam1;
    public CinemachineVirtualCamera VirtualCam2;
    public CinemachineVirtualCamera VirtualCam3;

    [Header("WayPoints")]
    public GameObject WayPoint1;
    public GameObject WayPoint2;

    [Header("Climbing")]
    public GameObject CamMovment;
    public GameObject ClimbText;

    [Header("Stats")]
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    private void Start()
    {
        useRaycast = true;
        myRaycast = GameObject.Find("VCam1").GetComponent<Raycast>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        LightOn = LanterneAction.isLighting;

        if(LightOn == false)
        {
            canWalk = true;
        }
        else
        {
            canWalk = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(canWalk)
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        lookAt = Raycast.isLooking;
        ClimbText.SetActive(false);

        //Augmente le timer si on enjambe l'obstalce
        if (isClimbing)
        {
            LanternLight.SetActive(false);
            climbTimer += Time.deltaTime;
        }

        //Si le joueur observe l'obstacle, le joueur peut enjamber
        if (lookAt)
        {
            ActivateClimb();
        }
        else
        {
            DeactivateClimb();
        }

        //Si on appuie sur E et que l'on peut enjamber l'obstacle
        if (Input.GetKeyDown(KeyCode.F) && canClimbing)
        {
            Player.gameObject.SetActive(false);
            CamMovment.GetComponent<CameraMovement>().enabled = false;
            canWalk = false;
            isClimbing = true;
            useRaycast = false;

            //Si l'on vient de la droite, change la priorité sur la première caméra
            if (WayClimb > 0)
            {
                VirtualCam2.Priority = 15;
            }
            //Sinon change la priorité sur la deuxième caméra
            else
            {
                VirtualCam3.Priority = 15;
            }
        }

        if (climbTimer > 0)
        {
            DeactivateClimb();
        }

        if(climbTimer == 0f)
        {
            LanternLight.SetActive(true);
        }

        //Si le timer d'enjambement est plus grand que 0 et si l'on vient de la gauche
        if (climbTimer >= 1f && WayClimb > 0)
        {
            gameObject.transform.position = WayPoint2.transform.position;
            VirtualCam2.Priority = 5;
        }

        //Si le timer d'enjambement est plus petit que 0 et si l'on vient de la droite
        if (climbTimer >= 1f && WayClimb < 0)
        {
            gameObject.transform.position = WayPoint1.transform.position;
            VirtualCam3.Priority = 5;
        }

        //s'éxécute quand l'enjambement est fini
        if (climbTimer >= 2f)
        {
            Player.gameObject.SetActive(true);
            CamMovment.GetComponent<CameraMovement>().enabled = true;
            canWalk = true;
            isClimbing = false;
            useRaycast = true;

            climbTimer = 0f;

            if (WayClimb < 0)
            {
                WayClimb = 1;
            }
            else
            {
                WayClimb = -1;
            }
        }

    }

    void ActivateClimb()
    {
        canClimbing = true;
        ClimbText.SetActive(true);
    }

    void DeactivateClimb()
    {
        canClimbing = false;
        ClimbText.SetActive(false);
    }

}
