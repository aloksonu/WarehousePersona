using UnityEngine;

namespace WarehousePersona.Sandbox
{
    public class DragAndDrop2d : MonoBehaviour
    {
        Vector3 mousePosition;
        Vector3 initialPosition;
        [SerializeField] private Transform otherTransform;
        private bool isDropDone;

        void Start()
        {
            initialPosition = this.transform.position;
            isDropDone = false;
        }

        private Vector3 GetMousePosition()
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }

        private void OnMouseDown()
        {
            if(isDropDone==false)
                mousePosition = Input.mousePosition - GetMousePosition();
        }

        private void OnMouseDrag()
        {
            if (isDropDone == false)
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }

        private void OnMouseUp()
        {
            float distance = Vector3.Distance(transform.position, otherTransform.position);
            if (distance > 1.5f)
            {
                transform.position = initialPosition;
            }
            else
            {
                isDropDone = true;
                transform.position = otherTransform.position;
            }
            Debug.Log("mouse up");
        }

        //private void Update()
        //{
        //    float distance = Vector3.Distance(transform.position, otherTransform.position);
        //    Debug.Log(distance);
        //    if (distance <= 1.5f && isMouseUp == true)
        //    {
        //        transform.position = otherTransform.position;
        //    }
        //}
        //void OnTriggerEnter2D(Collider2D other)
        //{
        //    Debug.Log("colide");
        //    if (other.gameObject.GetComponent<ProcessName>().strProcessName == "put" && isMouseUp == true)
        //    {
        //        Debug.Log("AssignGate Done");
        //        transform.position = otherTransform.position;
        //    }
        //}
    }
}
