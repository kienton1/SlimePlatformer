using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public Vector3 offset;
    public float minZoom = 140f;
    public float maxZoom = 120f;
    public float zoomLimiter = 10f;
    public float groundY = 0f; // Y position when player is on the ground
    public float followY = 0f; // Y position when camera starts following

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = newPosition;
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 0)
        {
            // Handle the case where there are no targets (or all targets are destroyed)
            return Vector3.zero; // You can return a default position or handle it differently
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            // Check if the target is destroyed or null before accessing its position
            if (targets[i] != null && targets[i].gameObject != null)
            {
                bounds.Encapsulate(targets[i].position);
            }
        }

        Vector3 centerPoint = bounds.center;

        // Adjust the camera's Y position based on player's position
        if (centerPoint.y <= groundY)
        {
            centerPoint.y = groundY;
        }
        else if (centerPoint.y > followY)
        {
            centerPoint.y = followY;
        }

        return centerPoint;
    }

    public void AddTarget(Transform newTarget)
    {
        if (!targets.Contains(newTarget))
        {
            targets.Add(newTarget);
        }
    }

    public void RemoveTarget(Transform targetToRemove)
    {
        if (targets.Contains(targetToRemove))
        {
            targets.Remove(targetToRemove);
        }
    }
}
