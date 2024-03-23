using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMatrix : MonoBehaviour {

    public GameObject WallObj;
    public GameObject HeroObj;
    public GameObject EmptyObj;
    public GameObject GreenDoorObj;
    public GameObject GreenKeyObj;
    public GameObject BlueDoorObj;
    public GameObject BlueKeyObj;
    public GameObject FinishObj;

    public int HeroX = 6;
    public int HeroY = 6;

    public int[,] Level = new int[15, 20];
	
    // Use this for initialization
	void Start ()
    {
        
        for (int i = 0; i < 20; i++)
        {
            Level[0, i] = 1;
            Level[14, i] = 1;
            if (i < 14)
            {
                Level[i, 0] = 1;
                Level[i, 19] = 1;
            }
        }

        for (int i = 5; i < 15; i++)
        {
            Level[15 - i, 4] = 1;
        }

        Level[2, 4] = 3;

        for (int i = 1; i < 5; i++)
        {
            Level[14 - i, 17] = 1;
            Level[14 - i, 18] = 1;
        }

        for (int i = 4; i < 14; i++)
        {
            Level[4, i] = 1;
        }

        Level[4, 5] = 2;
        Level[4, 7] = -2;

        for (int i = 4; i < 14; i++)
        {
            Level[10, i] = 1;
        }

        Level[10, 11] = -3;

        for (int i = 4; i < 10; i++)
        {
            Level[i, 13] = 1;
        }

        Level[6, 13] = 2;

        for (int i = 14; i < 17; i++)
        {
            Level[7, i] = 1;
        }

        for (int i = 0; i < 8; i++)
        {
            Level[i, 16] = 1;
        }

        for (int i = 6; i < 9; i++)
        {
            Level[i, 7] = 1;
        }

        Level[9, 14] = 3;
        Level[10, 14] = 2;
        Level[9, 15] = 2;
        Level[10, 15] = 3;
        Level[9, 16] = 3;
        Level[10, 16] = 2;

        Level[6, 6] = 5;

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (Level[i, j] == 1)
                {
                    Instantiate(WallObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }
                if (Level[i, j] == 0)
                {
                    Instantiate(EmptyObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }
            }
        }

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (Level[i, j] == 2)
                {
                    Instantiate(GreenDoorObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }
                if (Level[i, j] == -2)
                {
                    Instantiate(GreenKeyObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }

                if (Level[i, j] == 3)
                {
                    Instantiate(BlueDoorObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }
                if (Level[i, j] == -3)
                {
                    Instantiate(BlueKeyObj, new Vector3(0.32f * j - 3.3f, 0.32f * i - 2.2f, 0f), Quaternion.identity);
                }
            }
        }

        Instantiate(HeroObj, new Vector3(0.32f * 6 - 3.3f, 0.32f * 6 - 2.2f, 0f), Quaternion.identity);
        Instantiate(FinishObj, new Vector3(0.32f * 19 - 3.3f, 0.32f * 1 - 2.2f, 0f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {

    }
}
