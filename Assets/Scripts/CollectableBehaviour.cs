using Unity.VisualScripting;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    double offset = .1;
    float mSpeed = 0.2f;
    double startingPosY = 0;
    double min = 0;
    double max = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        startingPosY = transform.position.y;
        min = startingPosY - offset;
        max = startingPosY + offset;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * mSpeed * Time.deltaTime, Space.World);

        if (transform.position.y > max) { mSpeed = -mSpeed; }
        if (transform.position.y < min) { mSpeed = -mSpeed; }

    }
}
