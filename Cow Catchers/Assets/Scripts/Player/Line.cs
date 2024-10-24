using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;
    float closureThreshold = 0.1f;
    bool enclosureCreated;
    PlayerInfo playerInfo;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (IsEnclosedShape() && !enclosureCreated)
        {
            CreateCollider();
            enclosureCreated = true;
        }
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

    bool IsEnclosedShape()
    {
        int pointCount = lineRenderer.positionCount;
        if (pointCount < 3)
        {
            return false;
        }

        for (int i = 0; i < pointCount; i++)
        {
            for (int j = i + 1; j < pointCount; j++)
            {
                if (Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(j)) < closureThreshold)
                {
                    return true;
                }
            }
        }

        return false;
    }

    void CreateCollider()
    {
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = true;

        Vector3[] linePositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(linePositions);

        List<Vector2> enclosedPoints = new List<Vector2>();

        for (int i = 0; i < linePositions.Length; i++)
        {
            enclosedPoints.Add(new Vector2(linePositions[i].x, linePositions[i].y));
        }

        polygonCollider.points = enclosedPoints.ToArray();

        LassoZone lassoZone = polygonCollider.gameObject.GetComponent<LassoZone>();
        lassoZone.SetPlayerInfo(playerInfo);
    }

    public void SetPlayerInfo(PlayerInfo value) => playerInfo = value;
}
