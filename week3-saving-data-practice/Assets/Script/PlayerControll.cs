using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //set up rigid body
    public Rigidbody2D rb20;
    public float forceAmt = 5;


    // Start is called before the first frame update
    private void Start()
    {
        rb20 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) rb20.AddForce(Vector2.up * forceAmt);

        if (Input.GetKey(KeyCode.LeftArrow)) rb20.AddForce(Vector2.left * forceAmt);

        if (Input.GetKey(KeyCode.RightArrow)) rb20.AddForce(Vector2.right * forceAmt);
    }
}