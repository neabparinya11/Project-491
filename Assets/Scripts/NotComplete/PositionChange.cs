using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime;
    private static PositionChange instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public static PositionChange GetInstance()
    {
        return instance;
    }

    private IEnumerator AnimationWhenTransformPosition()
    {
        yield return new WaitForSeconds(transitionTime);
        
    }

    public void ChangePosition(GameObject player, Vector3 newPosition)
    {
        player.transform.position = newPosition;
    }
}
