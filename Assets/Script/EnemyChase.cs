using UnityEngine;
public class EnemyChase : MonoBehaviour
{
    public float chaseSpeed = 3f;
    public float lifeTime = 10f;
    private Transform playerTransform;
    private Rigidbody rb;
    private bool hasCollided = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform =
    GameObject.FindGameObjectWithTag("Player").transform;
        // หายเองถ้าไม่ได้ชนภายในเวลาที่ก าหนด
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (hasCollided) return;
        Vector3 direction = (playerTransform.position -
       rb.position).normalized;
        direction.y = 0f;
        rb.MovePosition(rb.position + direction * chaseSpeed *
       Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasCollided) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            Debug.Log("ศัตรูชน Player แล้ว!");
        }


    }
}
