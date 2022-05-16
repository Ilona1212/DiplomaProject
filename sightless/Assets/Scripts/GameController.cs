using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float[,] EnemyPos = { { 14.4f, -2.5f }, { 26.9f, -2.5f }, {76.319f , -2.5f}, { 85.0f, -2.5f } };
    static public bool[] enemydefeat = { false, false, false, false };
    void Start()
    {
        GenerateEnemy();
    }

    private void GenerateEnemy()
    {
        int full = 0;
        for (int col = 0; col < EnemyPos.Length/2; col++)
        {
            GameObject Tile = (GameObject)Instantiate(Resources.Load("EnemyPosition"));
            Tile.transform.position = new Vector2(EnemyPos[col, 0], EnemyPos[col, 1]); // 
            Tile.GetComponent<EnemyFunction>().enemyid = full;
            //Tile.GetComponent<SpriteRenderer>().sortingOrder = 2;
            full++;
        }
        print("Создано " + full + " врагов");
    }
}
