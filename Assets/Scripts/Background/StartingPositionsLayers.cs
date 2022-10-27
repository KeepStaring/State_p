using UnityEngine;

public class StartingPositionsLayers : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] layers;

    private void Start()
    {
        sbyte coeffPosition = 1;

        for (int i = 0; i < layers.Length; i++)
        {
            for (int j = 0; j < layers[i].transform.childCount; j++)
            {
                var layer = layers[i].transform.GetChild(j);

                float posX = layers[i].transform.position.x + layers[i].bounds.size.x * coeffPosition;

                layer.transform.position = new Vector2(posX, layers[i].transform.position.y);

                coeffPosition *= -1;
            }
        }
    }
}
