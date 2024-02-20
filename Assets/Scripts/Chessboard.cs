using UnityEngine;

public class Chessboard : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < 10; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                var gameObject = Instantiate(prefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                var renderer = gameObject.GetComponent<Renderer>();
                if (i % 2 == j % 2)
                {
                    renderer.material.color = Color.white;
                }
                else
                {
                    renderer.material.color = Color.black;
                }
            }
        }
    }

}
