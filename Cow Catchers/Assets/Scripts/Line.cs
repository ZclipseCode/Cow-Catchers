using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetPosition(Vector2 position)
    {
        if (!CanAppend(position))
        {
            return;
        }

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
    }

    bool CanAppend(Vector2 position)
    {
        if (lineRenderer.positionCount == 0)
        {
            return true;
        }

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), position) > DrawLasso.RESOLUTION;
    }
}
