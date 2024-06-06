using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerBuster : MonoBehaviour
{
    [Header("Explosion Radius")]
    public GameObject explosionDistanceGo; // Child object of bomb with polygon collider on it
    public LayerMask whatisPlatform; // What bomb destroys
    public PolygonCollider2D polygonCollider2D; // Radius/Shape of explosion

    [Header("Others")]
    public float Damage; // Amount of damage bomb deals upon explosion
    //private Rigidbody2D rb;

    void Start()
    {
        explosionDistanceGo.SetActive(true);
        DestroyArea();
    }

    void DestroyArea()
    {
        // Get all points inside the polygon collider
        List<Vector3> points = new List<Vector3>();
        Bounds bounds = polygonCollider2D.bounds;
        for (float x = bounds.min.x; x <= bounds.max.x; x += 1f)
        {
            for (float y = bounds.min.y; y <= bounds.max.y; y += 1f)
            {
                Vector2 point = new Vector2(x, y);
                if (polygonCollider2D.OverlapPoint(point))
                {
                    points.Add(point);
                }
            }
        }

        // Destroy tiles in the area
        foreach (Vector3 checkCellPos in points)
        {
            Collider2D[] overCollider2d = Physics2D.OverlapCircleAll(checkCellPos, 0.01f, whatisPlatform);
            if (overCollider2d.Length > 0)
            {
                foreach (Collider2D overColl in overCollider2d)
                {
                    overColl.GetComponent<Ground>().MakeDot(checkCellPos);
                }
            }
        }

        // Damage nearby objects
        Collider2D[] colliders = Physics2D.OverlapAreaAll(bounds.min, bounds.max);

        foreach (Collider2D nearbyObject in colliders)
        {
            var obj = nearbyObject.GetComponent<Enemy>();
            var obs = nearbyObject.GetComponent<crateHealth>();
            var play = nearbyObject.GetComponent<playerHealth>();
            var dr = nearbyObject.GetComponent<doorHealth>();
            var extraction = nearbyObject.GetComponent<extractionHealth>();
            if (obj != null)
            {
                obj.TakeDamage(Damage);
            }
            if (obs != null)
            {
                obs.TakeDamage(Damage);
            }
            if (play != null)
            {
                play.gameObject.GetComponent<playerHealth>().health -= Damage;
            }
            if (dr != null)
            {
                dr.TakeDamage(Damage);
            }
            if (extraction != null)
            {
                extraction.TakeDamage(Damage);
            }
        }
    }

    public void DeleteBoom()
    {
        Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        Destroy(explosionDistanceGo);
        Destroy(this.gameObject);
    }
}
