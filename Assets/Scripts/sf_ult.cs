using UnityEngine;
using Vuforia;

public class ARAnimationController : MonoBehaviour
{
    public GameObject pudge; 
    public GameObject nevermore; 
    public GameObject tornadoPrefab;
    public float tornadoHeightOffset = 5f; 
    public float moveSpeed = 2f; 
    public float tornadoLifetime = 2f; 

    private Animator pudgeAnimator;
    private Animator nevermoreAnimator;
    private GameObject spawnedTornado; 
    private bool isMovingPudgeToTornado = false; 
    private bool isTornadoActive = false;
    private float tornadoCreationTime; 

    private void Start()
    {
        pudgeAnimator = pudge.GetComponent<Animator>();
        nevermoreAnimator = nevermore.GetComponent<Animator>();
    }

    public void PlayAnimations()
    {
        if (!isTornadoActive && tornadoPrefab != null)
        {
            spawnedTornado = Instantiate(
                tornadoPrefab,
                pudge.transform.position,
                Quaternion.identity
            );
            isTornadoActive = true;
            tornadoCreationTime = Time.time;
        }

        if (pudgeAnimator != null)
        {
            pudgeAnimator.Play("Eul");
            isMovingPudgeToTornado = true;
        }

        if (nevermoreAnimator != null)
        {
            nevermoreAnimator.Play("Ultimate");
        }
    }

    private void Update()
    {
        if (isMovingPudgeToTornado && spawnedTornado != null)
        {
            Vector3 targetPosition = spawnedTornado.transform.position + Vector3.up * tornadoHeightOffset;

            pudge.transform.position = Vector3.MoveTowards(
                pudge.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
            

            if (Vector3.Distance(pudge.transform.position, targetPosition) < 0.1f)
            {
                isMovingPudgeToTornado = false;
            }
        }

        if (isTornadoActive)
        {
            if (Time.time - tornadoCreationTime >= tornadoLifetime)
            {
                RemoveTornado();
            }
        }
    }

    private void RemoveTornado()
    {
        if (spawnedTornado != null)
        {
            Destroy(spawnedTornado);
            isTornadoActive = false;

            float groundHeight = 0f; 
            Vector3 groundPosition = new Vector3(pudge.transform.position.x, groundHeight, pudge.transform.position.z);

            pudge.transform.position = groundPosition;
        }
    }
}
