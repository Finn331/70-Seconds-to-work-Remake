using UnityEngine;

public class Footstep : MonoBehaviour
{
    [Header("For Ground Checking")]
    public LayerMask groundLayer;
    public float raycastDistance = 0.1f;

    [Header("For Wall Checking")]
    public LayerMask wallLayer;
    public float wallRaycastDistance = 0.5f;

    [Header("Footstep Sounds")]
    public AudioClip[] footstepClips; // Array untuk menyimpan suara footstep
    private bool isFootstepPlaying = false;
    private float footstepInterval = 0.5f; // Jeda antar footstep
    private float nextFootstepTime = 0f;

    void Update()
    {
        bool isGrounded = CheckGround();
        bool isHittingWall = CheckWall();

        if (isGrounded && !isHittingWall && (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            if (Time.time >= nextFootstepTime)
            {
                PlayFootstepSound();
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
    }

    void PlayFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepClips.Length);
            AudioManager.instance.PlaySound(footstepClips[randomIndex]);
        }
    }

    bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer);
    }

    bool CheckWall()
    {
        return Physics.Raycast(transform.position, transform.forward, wallRaycastDistance, wallLayer);
    }
}
