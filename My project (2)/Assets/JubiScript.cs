using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JubiScript : MonoBehaviour
{
    public float moveSpeed = 50;
    public float rotateSpeed = 25;
    public Rigidbody rb;
    public bool isGrounded;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public GameManager gm;
    public GameObject Confetti;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);

        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            for (int i = 0; i < 100; i++)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = "sphere" + i;
                Renderer sRend = sphere.GetComponent<Renderer>();
                sRend.material.color = new Color(Random.value, Random.value, Random.value);
                Debug.Log(sRend.material.color);
                sphere.transform.position = gameObject.transform.position;
                float rotXAmount = Random.Range(-89, -10);
                float rotYAmount = Random.Range(0, 360);
                sphere.transform.Rotate(rotXAmount, rotYAmount, 0);
                Rigidbody sphereRB = sphere.AddComponent<Rigidbody>();
                sphereRB.AddForce(sphere.transform.forward * 1000);
                Destroy(sphere, 2f);
            }
            
        }
    }
    // private void OnTriggerEnter(Collider other) {
    //      if (other.CompareTag("enemy"))
    //     {
    //         Destroy(other.gameObject);
    //         gm.IncrementScore();
    //         Debug.Log("hhh");

    //     }
    // }

}
