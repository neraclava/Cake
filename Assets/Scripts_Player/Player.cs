using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1.0f;

    private Rigidbody2D mRigidbody;

    private bool mIsGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        mRigidbody.linearVelocityX = 1 * MoveSpeed;
    }

    // オブジェクトに衝突した瞬間検知
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突した瞬間が""の場合
        if (collision.gameObject.CompareTag("Ground"))
        {
            mIsGrounded = true;
        }
        if (collision.gameObject.CompareTag("Dead"))
        {
            // スタート地点に移動
            transform.position = Vector3.zero;
        }
    }

    // オブジェクトから離れた瞬間検知
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 離れた瞬間が""の場合
        if (collision.gameObject.CompareTag("Ground"))
        {
            mIsGrounded = false;
        }
    }
}
