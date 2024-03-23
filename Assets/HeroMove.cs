using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroMove : MonoBehaviour
{

    Rigidbody2D rb;

    public GameObject SpentObj;
    public GameObject GreenDoorObj;
    public GameObject GreenKeyObj;
    public GameObject BlueDoorObj;
    public GameObject BlueKeyObj;
    public GameObject EmptyObj;
    public GameObject HeroObj;

    public Text InfoText;

    int CurY;
    int CurX;
    int[,] LevelInfo;
    public int Color;
    public int KeyX = 100, KeyY = 100;
    public int PlayerX = 100, PlayerY = 100;
    public int DoorX = 100, DoorY = 100;
    public int DoorColor;

    int[] constX = new[] { -1,  1, -1, 1, 0, 1, -1,  0};
    int[] constY = new[] { -1, -1,  1, 1, 1, 0,  0, -1};

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LevelInfo = Camera.main.GetComponent<LevelMatrix>().Level;
        CurX = Camera.main.GetComponent<LevelMatrix>().HeroX;
        CurY = Camera.main.GetComponent<LevelMatrix>().HeroY;
        rb.GetComponent<SpriteRenderer>().sprite = HeroObj.GetComponent<SpriteRenderer>().sprite;
        InfoText = GameObject.FindGameObjectWithTag("message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.getComponent<SpriteRenderer>().sprite = ..
        
        //Movement, Door/Key checks and delete if necessary

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (LevelInfo[i, j] == 2)
                {
                    if (PlayerCheck(i, j) != -1)
                    {
                        if (LevelInfo[i, j] == PlayerCheck(i, j))
                        {
                            Instantiate(EmptyObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                            LevelInfo[i, j] = 0;
                        }
                    }
                }
                if (LevelInfo[i, j] == 3)
                {
                    if (PlayerCheck(i, j) != -1)
                    {
                        if (LevelInfo[i, j] == PlayerCheck(i, j))
                        {
                            Instantiate(EmptyObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                            LevelInfo[i, j] = 0;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (check(CurX + 1, CurY))
            {
                if (KeyCheck(CurX + 1, CurY) != -1)
                {
                    Color = KeyCheck(CurX + 1, CurY);
                    if (Color == 2)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = GreenKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                    if (Color == 3)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = BlueKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                }
                Instantiate(SpentObj, new Vector3(0.32f * CurX - 3.3f, 0.32f * CurY - 2.2f, 0f), Quaternion.identity);
                LevelInfo[CurY, CurX] = 1;
                rb.transform.Translate(0.32f, 0, 0);
                CurX++;
                LevelInfo[CurY, CurX] = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (check(CurX, CurY + 1))
            {
                if (KeyCheck(CurX, CurY + 1) != -1)
                {
                    Color = KeyCheck(CurX, CurY + 1);
                    if (Color == 2)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = GreenKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                    if (Color == 3)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = BlueKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                }
                Instantiate(SpentObj, new Vector3(0.32f * CurX - 3.3f, 0.32f * CurY - 2.2f, 0f), Quaternion.identity);
                LevelInfo[CurY, CurX] = 1;
                rb.transform.Translate(0, 0.32f, 0);
                CurY++;
                LevelInfo[CurY, CurX] = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (check(CurX - 1, CurY))
            {
                if (KeyCheck(CurX - 1, CurY) != -1)
                {
                    Color = KeyCheck(CurX - 1, CurY);
                    if (Color == 2)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = GreenKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                    if (Color == 3)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = BlueKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                }
                Instantiate(SpentObj, new Vector3(0.32f * CurX - 3.3f, 0.32f * CurY - 2.2f, 0f), Quaternion.identity);
                LevelInfo[CurY, CurX] = 1;
                rb.transform.Translate(-0.32f, 0, 0);
                CurX--;
                LevelInfo[CurY, CurX] = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (check(CurX, CurY - 1))
            {
                if (KeyCheck(CurX, CurY - 1) != -1)
                {
                    Color = KeyCheck(CurX, CurY - 1);
                    if (Color == 2)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = GreenKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                    if (Color == 3)
                    {
                        rb.GetComponent<SpriteRenderer>().sprite = BlueKeyObj.GetComponent<SpriteRenderer>().sprite;
                    }
                }
                Instantiate(SpentObj, new Vector3(0.32f * CurX - 3.3f, 0.32f * CurY - 2.2f, 0f), Quaternion.identity);
                LevelInfo[CurY, CurX] = 1;
                rb.transform.Translate(0, -0.32f, 0);
                CurY--;
                LevelInfo[CurY, CurX] = 6;
            }

            if (CurY == 1 && CurX == 18)
            {
                InfoText.text = "Congratulations";
            }
        }

        //print(DoorY + " " + DoorX + " " + Color + " " + DoorColor);

        //Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("Level");
        }
        //exit
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    int DoorCheck(int i, int j)
    {
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == 2)
            {
                DoorY = j + constX[k];
                DoorX = i + constY[k];
                return 2;
            }
        }
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == 3)
            {
                DoorY = j + constX[k];
                DoorX = i + constY[k];
                return 3;
            }
        }
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == 4)
            {
                DoorY = j + constX[k];
                DoorX = i + constY[k];
                return 4;
            }
        }

        return -1;
    }

    int PlayerCheck(int i, int j)
    {
        for (int k = 0; k < 8; k++)
        {
            if (CoordCheck(i + constX[k], j + constY[k]) && LevelInfo[i + constX[k], j + constY[k]] == 6)
            {
                PlayerY = i + constX[k];
                PlayerX = j + constY[k];
                return Color;
            }
        }
        return -1;
    }

    bool CoordCheck(int x, int y)
    {
        return (x >= 0 && x <= 14 && y >= 0 && y <= 19);
    }

    int KeyCheck(int i, int j)
    {
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == -2)
            {
                KeyY = j + constX[k];
                KeyX = i + constY[k];
                return 2;
            }
        }
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == -3)
            {
                KeyY = j + constX[k];
                KeyX = i + constY[k];
                return 3;
            }
        }
        for (int k = 0; k < 8; k++)
        {
            if (LevelInfo[j + constX[k], i + constY[k]] == -4)
            {
                KeyY = j + constX[k];
                KeyX = i + constY[k];
                return 4;
            }
        }

        return -1;

    }

    bool check(int i, int j)
    {
        return (LevelInfo[j, i] != 1 && LevelInfo[j, i] != 2 && LevelInfo[j, i] != 3 && LevelInfo[j, i] != -2 && LevelInfo[j, i] != -3);
    }
}
