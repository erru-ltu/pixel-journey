using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //array of enemies to spawn
    public GameObject[] enemies;

    public Transform target;

    private float xBoundary = 23.0f;
    private float yBoundary = 18.0f;

    private float difference = 5;

    private float time = 2;
    private float repeatTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", time, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector2 SetSpawnBoundaries()
    {
        //set random X and Y coordinates and return random vector
        float xRandomSpot = Random.Range(-xBoundary, xBoundary);
        float yRandomSpot = Random.Range(-yBoundary, yBoundary);

        return new Vector2(xRandomSpot, yRandomSpot);
    }

    private void SpawnEnemy()
    {
        //random enemy from enemies array
        int randomIndex = Random.Range(0, enemies.Length);

        //create random enemy in random position
        GameObject enemy = Instantiate(enemies[randomIndex], SetSpawnBoundaries(), Quaternion.identity);

        //if distance between player and enemy more than 5 destroy enemy. ????????
        if(Vector2.Distance(target.position, enemy.transform.position) < difference)
        {
            Destroy(enemy.gameObject);
        }

    }
}
