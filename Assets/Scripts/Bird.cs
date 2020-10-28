using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Bird : MonoBehaviour {
    // Movement speed
    public float speed = 2;

    //score text
    public Text score;

    public int scoreNum = 0;
    public string[] textArray = "Xingbu stop telling me what to do you idiot".Split();
    public int sizeArray = 9;
    public int currentIndex = -1;

    // Flap force
    public float force = 300;

    public void updateText()
    {
        scoreNum++;
        score.text = scoreNum.ToString();
    }

    // Use this for initialization


    void Start () {    
        // Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    
    // Update is called once per frame
    void Update () {
        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);

        //Debug.Log(transform.position.x + " x coord");
        //Debug.Log(transform.position.y + " y coord");
        //Debug.Log(transform.position.z + " z coord");
    }
    
    void OnCollisionEnter2D(Collision2D coll) {
        // Restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
