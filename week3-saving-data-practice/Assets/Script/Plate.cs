using UnityEngine;

public class Plate : MonoBehaviour
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
        transform.Rotate(0, 0, 90, Space.Self);
    }
}