using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    void Update()
    {
        transform.DOJump(new Vector2(0.5f, 0.5f), 0.5f, 1, 1f, false);
        transform.DOJump(new Vector2(-1f, -1f), 0.5f, 1, 1f, false);
    }
}
