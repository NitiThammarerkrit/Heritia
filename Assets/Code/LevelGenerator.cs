using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] levelPrefab;
    public float levelwidth = 12;

    private int currentLevelGenerate = 1;

    void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.CompareTag("New Level"))
        {
            int randomIndex = Random.Range(0, 4);
            GameObject nextlevelObj = Instantiate(levelPrefab[randomIndex]);
            nextlevelObj.transform.position =
            new Vector3(Player.transform.position.x, 3.76f, 7.61f);
            currentLevelGenerate += 1;
            Destroy(hitWith.gameObject);

        }
    }

}