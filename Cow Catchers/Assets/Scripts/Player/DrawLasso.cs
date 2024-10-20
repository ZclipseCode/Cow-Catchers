using UnityEngine;

public class DrawLasso : MonoBehaviour
{
    [SerializeField] Line linePrefab;
    Camera cam;
    Line currentLine;

    public const float RESOLUTION = 0.1f;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab);
        }

        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            currentLine.SetPosition(mousePosition);
        }
    }
}
