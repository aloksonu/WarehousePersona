using System.Collections;
using UnityEngine;

namespace WarehousePersona.Inbound.Scripts
{
    public class AssignGate : MonoBehaviour
    {
        internal Rigidbody2D rbd2;
        internal float moveSpeed;
        internal bool isMove;
        bool isCompleted;
        void Start()
        {
            rbd2 = GetComponent<Rigidbody2D>();
            moveSpeed = 300f;
            isMove = false;
            isCompleted = false;
        }

        void FixedUpdate()
        {
            if (isMove == true && isCompleted == false)
            {
                this.rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
                //Debug.Log("Moving");
            }
            else
            {
                this.rbd2.velocity = Vector2.left * 0;
                //Debug.Log("Stoped");
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<ProcessName>().strProcessName == "AssignGate")
            {
                Debug.Log("AssignGate Done");
                isCompleted = true;
                StartCoroutine(StartDefOfAssignGate());
            }
        }
        private IEnumerator StartDefOfAssignGate()
        {
            yield return new WaitForSeconds(2f);
            InboundManager.Instance.StartDefOfAssignGate();
        }

        public void MoveStart()
        {
            isMove = true;
            //rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        }
        public void MoveStop()
        {
            isMove = false;
            //rbd2.velocity = Vector2.left * 0;
        }
    }
}
