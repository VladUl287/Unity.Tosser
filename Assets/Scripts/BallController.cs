using UnityEngine;

public sealed class BallController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int numPoints = 50;
    public float timeInterval = 0.1f;

    private void Start()
    {
        lineRenderer.positionCount = numPoints;
    }

    private void Update()
    {
        UpdateTrajectory();
    }

    private void UpdateTrajectory()
    {
        Vector3[] points = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float time = i * timeInterval;
            points[i] = CalculateTrajectoryPoint(time);
        }

        lineRenderer.SetPositions(points);
    }

    private Vector3 CalculateTrajectoryPoint(float time)
    {
        float gravity = Physics.gravity.y;
        float initialVelocity = 10f;

        float x = transform.position.x + initialVelocity * time;
        float y = transform.position.y + (initialVelocity * time) + (0.5f * gravity * time * time);
        float z = transform.position.z;

        return new Vector3(x, y, z);
    }
}
