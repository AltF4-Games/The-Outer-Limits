using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform centerOfOrbit;
    public float orbitSpeed = 10f;
    public float orbitRadius = 5f;

    private Vector3 orbitAxis = Vector3.up; // Axis of rotation (y-axis for simple 2D orbits)

    void Update()
    {
        Vector3 orbitPosition = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0) * (transform.position - centerOfOrbit.position);
        transform.position = centerOfOrbit.position + orbitPosition.normalized * orbitRadius;

        transform.LookAt(centerOfOrbit);
    }

    public void OnDrawGizmos()
    {
        Vector3[] points = new Vector3[360];
        for (int i = 0; i < 360; i++)
        {
            float angle = i * Mathf.Deg2Rad;
            Vector3 position = centerOfOrbit.position + new Vector3(Mathf.Sin(angle) * orbitRadius, 0, Mathf.Cos(angle) * orbitRadius);
            points[i] = position;
        }

        for (int i = 0; i < points.Length - 1; i++)
        {
            Debug.DrawLine(points[i], points[i + 1], Color.blue);
        }
    }
}