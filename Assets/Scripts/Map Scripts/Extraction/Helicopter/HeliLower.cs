using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliLower : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private void Start()
    {
        this.gameObject.transform.position = start.position;
    }

    void Update()
    {
        this.gameObject.transform.position = Vector2.Lerp(this.gameObject.transform.position, end.position, Time.deltaTime / 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(start.position, Vector3.one * 0.1f);
        Gizmos.DrawCube(end.position, Vector3.one * 0.1f);
    }
}
