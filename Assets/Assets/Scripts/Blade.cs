using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public bool isCutting=false;
    public GameObject bladeTrailPrefab;

    Rigidbody2D rb;
    Camera cam;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
        

    }
	
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
	}

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

}
