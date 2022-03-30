using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour {

    //for screen borders
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true; 

    public static PlayerMoving instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();
    }

    private void Update()
    {
        if (controlIsActive)
        {
            if (Input.touchCount == 1) // if there is a touch
            {
                Touch touch = Input.touches[0];
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position); 
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, 30 * Time.deltaTime);
            }

            //returning player to main point
            float positionX = Mathf.Clamp(transform.position.x, borders.minX, borders.maxX);
            float positionY = Mathf.Clamp(transform.position.y, borders.minY, borders.maxY);
            transform.position = new Vector3(positionX, positionY, 0);
        }
    }

    void ResizeBorders() 
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
