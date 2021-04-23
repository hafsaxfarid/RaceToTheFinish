using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5.5f;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private TextMeshProUGUI keysText = null;

    public int keys = 0;

    private Rigidbody playerRB;

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        keysText.text = keys.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // move player left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playerRB.AddForce(Vector3.left * speed);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        // move player right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerRB.AddForce(Vector3.right * speed);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        // player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Debug.Log("Jumping");
            isGrounded = false;
            playerRB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key"))
        {
            keys++;
            keysText.text = keys.ToString();
            Destroy(other.gameObject);
        }

        if(other.name == "Death")
        {
            playerRB.transform.position = spawnPoint.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Is Grounded");
        }
    }
}
