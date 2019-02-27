using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D wallCollider;
    private float wallVerticalLength;

    // Start is called before the first frame update
    void Start()
    {
        wallCollider = GetComponent<BoxCollider2D>();
        wallVerticalLength = wallCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= wallVerticalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 wallOffset = new Vector2(0, -wallVerticalLength);
        transform.position = (Vector2)transform.position + wallOffset;
    }

    /* public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    } */
}
