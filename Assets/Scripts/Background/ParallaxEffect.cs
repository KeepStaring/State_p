using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    [SerializeField] private float parallaxFactor;

    private Vector2 startPositionLayer;

    private float widthSpriteLayer;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main.transform;

        startPositionLayer = transform.position;
        widthSpriteLayer = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = mainCamera.position.x * (1 - parallaxFactor);
        float distance = mainCamera.position.x * parallaxFactor;

        if (temp > startPositionLayer.x + (widthSpriteLayer / 2))
            startPositionLayer.x += widthSpriteLayer;
        else if (temp < startPositionLayer.x - (widthSpriteLayer / 2))
            startPositionLayer.x -= widthSpriteLayer;

        transform.position = new Vector2(startPositionLayer.x + distance, transform.position.y);
    }
}
