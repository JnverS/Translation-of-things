using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Transform handsPosition;
    [SerializeField] float maxRayDistance = 5f;

    private GameObject current;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (current == null)
                Pickup();
            else
                Drop();
        }
    }

    private void Drop()
    {
        if (current == null) return;

        current.transform.parent = null;
        current.GetComponent<Rigidbody>().isKinematic = false;
        current = null;
    }

    private void Pickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            if (hit.collider.CompareTag("pickupItem"))
            {
                current = hit.collider.transform.root?.gameObject ?? hit.collider.gameObject;
                current.transform.parent = handsPosition;
                current.transform.localPosition = Vector3.zero;
                current.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            if (current != null)
            {
                GameObject car = collision.transform.root.gameObject;
                Transform place = car.GetComponent<Car>().GetFreePlace();

                if (place != null)
                {
                    current.transform.parent = place;
                    current.transform.localPosition = Vector3.zero;
                    current.GetComponent<Rigidbody>().isKinematic = true;
                    current = null;
                }
                else
                    Drop();
            }
        }
    }
}
