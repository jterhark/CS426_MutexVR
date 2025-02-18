﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int) trackedObj.index); }
    }

    // 1
    public GameObject laserPrefab;

// 2
    private GameObject laser;

// 3
    private Transform laserTransform;

// 4
    private Vector3 hitPoint;


    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit) {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
                                                hit.distance);
    }

    void Start() {
        // 1
        laser = Instantiate(laserPrefab);
// 2
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update() {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100)) {
                hitPoint = hit.point;
                ShowLaser(hit);
            }
        }
        else // 3
        {
            laser.SetActive(false);
        }
    }
}