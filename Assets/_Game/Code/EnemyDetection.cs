using UnityEngine;

public class EnemyChase2D : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float chasezone = 5f;
    public float punchdistance = 0.8f;
    public SpriteRenderer sword;
    private bool flippadippa = false;

    SpriteRenderer SpriteImage;
    Animator Animator;

    void Awake()
    {
        SpriteImage = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player == null || SpriteImage == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        bool chasing = distance < chasezone;
        bool punching = chasing && distance <= punchdistance;

        if (Animator)
        {
            Animator.SetBool("IsWalking", chasing);
            Animator.SetBool("IsPunching", punching);
        }

        if (chasing)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position = new Vector2(
                transform.position.x + dir.x * speed * Time.deltaTime,
                transform.position.y
            );

            if (dir.x != 0)
            {
                bool movingRight = dir.x > 0;
                bool flip = flippadippa ? !movingRight : movingRight;
                SpriteImage.flipX = flip;
                if (sword) sword.flipX = flip;
            }
        }
    }
}
