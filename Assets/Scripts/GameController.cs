using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public struct Hole
    {
        public bool isAppear;
        public int holeX;
        public int holeY;
        public GameObject mole;
    }
    // Start is called before the first frame update
    public Hole[] holes;
    public GameObject holeObj;
    public GameObject moleObj;
    public float intervalPosX = 2, intervalPosY = 1;
    public Timer timer;
    
    void Start()
    {
        if (holeObj == null)
        {
            Debug.LogError("holeObj is not assigned in the inspector.");
            return;
        }

        if (moleObj == null)
        {
            Debug.LogError("moleObj is not assigned in the inspector.");
            return;
        }

        if (timer == null)
        {
            timer = FindObjectOfType<Timer>();
            if (timer == null)
            {
                Debug.LogError("No Timer object found in the scene.");
                return;
            }
        }
        InitMap();
        InvokeRepeating("MoleAppear", 0f, 0.5f);
        timer.StartCountDown(true);
    }

    private void InitMap()
    {
        Vector2 originalPos = new Vector2(-2, -2);
        holes = new Hole[9];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                holes[i * 3 + j] = new Hole();
                holes[i * 3 + j].holeX = (int)(originalPos.x + j * intervalPosX);
                holes[i * 3 + j].holeY = (int)(originalPos.y + i * intervalPosY);
                holes[i * 3 + j].isAppear = false;
                Instantiate(holeObj, new Vector3(holes[i * 3 + j].holeX, holes[i * 3 + j].holeY, 0), Quaternion.identity);
            }
        }
    }

    private void MoleAppear()
    {
        int id = UnityEngine.Random.Range(0, 9);
        while (holes[id].isAppear)
        {
            id = UnityEngine.Random.Range(0, 9);
        }
        holes[id].mole = Instantiate(moleObj, new Vector3(holes[id].holeX, holes[id].holeY + 0.5f, 0), Quaternion.identity);
        holes[id].mole.GetComponent<Mole>().id = id;
        holes[id].isAppear = true;
    }

    // Update is called once per frame

    private void CleanHoleState()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (holes[i * 3 + j].mole!= null)
                {
                    holes[i * 3 + j].isAppear = false;
                }
            }
        }
    }
    void Update()
    {
        CleanHoleState();
        if (timer.time <= 0)
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        timer.StartCountDown(false);
        CancelInvoke();
    }
}
