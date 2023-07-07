using UnityEngine;
using WarehousePersona.Inbound.Scripts;

namespace WarehousePersona.Outbound.Scripts
{
    public class Shiping : MonoBehaviour
    {
        internal Rigidbody2D rbd2;
        internal float moveSpeed;
        internal bool isMove;

        public Move m1,m2;

        void Start()
        {
            rbd2 = GetComponent<Rigidbody2D>();
            moveSpeed = 700f;
            isMove = false;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<ProcessName>().strProcessName == "Shiping")
            {
                Debug.Log("Shiping Done");
                m1.moveRight();
                m2.moveRight();
                Invoke(nameof(StartDefOfShipping), 2f);
                // StartCoroutine(StartVarificationE());
            }
        }
        //private IEnumerator StartVarificationE()
        //{
        //    yield return new WaitForSeconds(2f);
        //    InboundManager.Instance.callVarification();
        //}

        public void MoveStart()
        {
            isMove = true;
            rbd2.velocity = Vector2.right * moveSpeed * Time.deltaTime;
        }
        public void MoveStop()
        {
            isMove = false;
            rbd2.velocity = Vector2.left * 0;
        }

        private void StartDefOfShipping()
        {
            OutboundManager.Instance.StartDefOfShipping();
        }
    }
}
