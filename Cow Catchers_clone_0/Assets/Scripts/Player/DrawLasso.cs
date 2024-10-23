using UnityEngine;

public class DrawLasso : MonoBehaviour
{
    [SerializeField] Line linePrefab;
    Camera cam;
    Line currentLine;
    PlayerInfo playerInfo;

    public const float RESOLUTION = 0.1f;

    private void Start()
    {
        cam = Camera.main;
        playerInfo = GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab);

            Line lineScript = currentLine.GetComponent<Line>();
            lineScript.SetPlayerInfo(playerInfo);
        }

        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            currentLine.SetPosition(mousePosition);
        }
        else if (!Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && currentLine != null)
        {
            Destroy(currentLine.gameObject);
        }
    }
}
