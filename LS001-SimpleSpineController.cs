using Spine.Unity;
using UnityEngine;

public class SpineController : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation; // Animation controller
    public Rigidbody2D rb;                      // Rigidbody2D cho nhân vật
    public float speed = 5f;                    // Tốc độ di chuyển
    public float jumpForce = 10f;               // Lực nhảy

    private string currentAnimation;            // Animation hiện tại để tránh lặp
    private bool isGrounded = true;             // Kiểm tra nhân vật có đang trên mặt đất
    private string currentState = "Idle";       // Trạng thái hiện tại của nhân vật
    private bool isPlayingSpecialAnimation = false; // Cờ để kiểm tra animation đặc biệt

    void Start()
    {
        // Đặt animation ban đầu là "idle"
        SetAnimation("idle", true);

        // Đăng ký callback để xử lý khi animation hoàn tất
        skeletonAnimation.AnimationState.Complete += OnAnimationComplete;
    }

    void Update()
    {
        // Nếu đang phát animation đặc biệt, không xử lý thêm
        if (isPlayingSpecialAnimation) return;

        // Ưu tiên xử lý các phím kích hoạt đặc biệt
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Phím 1: "portal"
        {
            PlaySpecialAnimation("Portal", "portal");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return)) // Phím Enter: "shoot"
        {
            PlaySpecialAnimation("Shoot", "shoot");
            return;
        }

        // Lấy Input và velocity
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.linearVelocity;

        // Di chuyển nhân vật theo Input Horizontal
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // Lật nhân vật dựa trên hướng di chuyển
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Kiểm tra trạng thái để chuyển animation
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Nhảy
            isGrounded = false; // Đánh dấu là không còn trên mặt đất
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            ChangeState("Jumping", "jump", false);
        }
        else if (!isGrounded && velocity.y < -0.1f)
        {
            // Khi đang rơi
            ChangeState("Falling", "hoverboard", true);
        }
        else if (horizontalInput != 0 && isGrounded)
        {
            // Di chuyển
            ChangeState("Running", "run", true);
        }
        else if (isGrounded)
        {
            // Mặc định là "idle" khi nhân vật đứng yên trên mặt đất
            ChangeState("Idle", "idle", true);
        }
    }

    // Xử lý va chạm với mặt đất
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Đánh dấu nhân vật đang ở trên mặt đất
        }
    }

    // Hàm callback khi animation hoàn tất
    private void OnAnimationComplete(Spine.TrackEntry trackEntry)
    {
        // Nếu animation đặc biệt hoàn tất, cho phép logic khác chạy
        if (trackEntry.Animation.Name == "portal" || trackEntry.Animation.Name == "shoot")
        {
            isPlayingSpecialAnimation = false; // Kích hoạt lại logic khác
            SetAnimation("idle", true);        // Quay lại "idle"
        }
    }

    // Hàm chuyển trạng thái và animation
    void ChangeState(string newState, string animationName, bool loop)
    {
        if (currentState == newState) return; // Không chuyển trạng thái nếu giống nhau

        SetAnimation(animationName, loop);
        currentState = newState; // Cập nhật trạng thái mới
    }

    // Hàm để thay đổi animation, tránh lặp lại nếu animation đang chạy
    void SetAnimation(string animationName, bool loop)
    {
        if (currentAnimation == animationName) return; // Tránh lặp lại cùng một animation

        skeletonAnimation.AnimationState.SetAnimation(0, animationName, loop);
        currentAnimation = animationName; // Lưu trạng thái animation hiện tại
    }

    // Hàm xử lý animation đặc biệt
    void PlaySpecialAnimation(string stateName, string animationName)
    {
        isPlayingSpecialAnimation = true; // Khóa các logic khác
        ChangeState(stateName, animationName, false); // Phát animation đặc biệt
    }
}
