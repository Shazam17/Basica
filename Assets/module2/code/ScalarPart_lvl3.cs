using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarPart_lvl3 : MonoBehaviour
{
    public int loadedWeight = 0;
    private Rigidbody2D rb;

    public ScalarPart_lvl3 rightScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Move(float val)
    {
        transform.Translate(new Vector3(0, val, 0));
    }

    public void SetWeight(int weight)
    {
        loadedWeight = weight;
        Move(-weight * 15);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        loadedWeight += other.GetComponent<ScalableItem_lvl3>().weight;
        Move(-other.GetComponent<ScalableItem_lvl3>().weight * 15);
        rightScale.Move(other.GetComponent<ScalableItem_lvl3>().weight);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        loadedWeight -= other.GetComponent<ScalableItem_lvl3>().weight;
        Move(other.GetComponent<ScalableItem_lvl3>().weight * 15);
        rightScale.Move(-other.GetComponent<ScalableItem_lvl3>().weight);

    }
}
