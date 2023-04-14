using DG.Tweening;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal void moveRight()
    {
        transform.DOMove(new Vector3(10, this.transform.position.y, 0),2f);
        //transform.DOMove(new Vector3(-10, 0, 0), _cycleLength);
    }
}
