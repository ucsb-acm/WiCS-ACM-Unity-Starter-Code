using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    // Movement Speed (0 means don't move)
    public float speed = 0;
    public int counter = 0;
    //public GameObject pipeDown;
    private Bird bird;
    
    // Switch Movement Direction every x seconds
    public float switchTime = 2;

    void Start() {
        // Initial Movement Direction
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        
        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);

        bird = FindObjectOfType<Bird>();
    }

    void Update()
    {
        Debug.Log(bird.transform.position.x - this.transform.position.x);

        if(bird.transform.position.x > this.transform.position.x)
        {
            Instantiate(this, new Vector2(bird.transform.position.x + 4, this.transform.position.y), this.transform.rotation);
            Destroy(gameObject);
        }
     
        
    }

    void Switch() {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
}
