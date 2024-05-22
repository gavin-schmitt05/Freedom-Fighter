
public class MechFlare : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Mech;
    public Transform airdropPoint;
    private float Speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = this.transform.right * Speed;
        StartCoroutine(MechDropper());
    }
    IEnumerator MechDropper()
    {
        Destroy(this, 3);
        yield return new WaitForSeconds(4f);
        airdropPoint.position = new Vector3(this.transform.position.x, 75, 0);
        Instantiate(Mech, airdropPoint.position, airdropPoint.rotation);
    }

}
