using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    public GameObject cube;

    public int cubeAmount;

    public Material blueMaterial;
    public Material redMaterial;

    public static CubesSpawner instance;

    private void Start()
    {
        GameStart();
        instance = this;
    }

    public void GameStart()
    {
        if (ScoreCounter.instance.isPlaying)
        {
            return;
        }

        ScoreCounter.instance.winImage.gameObject.SetActive(false);

        ScoreCounter.instance.isPlaying = true;

        for (int i = 0; i < cubeAmount; i++)
        {
            GameObject cubeTemp = Instantiate(cube, new Vector3(transform.position.x + Random.Range(-1,1), transform.position.y + Random.Range(-1, 1), transform.position.z + Random.Range(-1, 1)), Quaternion.identity);

            if (i < cubeAmount / 2)
            {
                cubeTemp.GetComponent<MeshRenderer>().material = blueMaterial;
            }
            else
            {
                cubeTemp.GetComponent<MeshRenderer>().material = redMaterial;
            }

            ScoreCounter.instance.cubeCount = cubeAmount;
        }


        ScoreCounter.instance.scoreBlue = 0;
        ScoreCounter.instance.scoreRed = 0;

        ScoreCounter.instance.UpdateUI();
    }

}
