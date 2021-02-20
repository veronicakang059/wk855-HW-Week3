using System;
using UnityEngine;

public class Prize : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.instance.Score++;
        print("Score:"+GameManager.instance.Score);
    }
}