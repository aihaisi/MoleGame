using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public GameObject beatenMole;
    public int id;
    public GameController gameController;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        gameController = GameObject.FindObjectOfType<GameController>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        score++;
        scoreText.text = "Score: " + score;
        gameController.holes[id].mole = Instantiate(beatenMole, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
