using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform DirectionPoint;
    public Transform Apple;
    //public LayerMask AppleLayerMask;
    public Vector3 Normal;

    public float MoveSpeed;
    public float RotationSpeed;
    public float SmoothRotation;

    private Vector3 direction;
    private float inputX;
    private float inputY;
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        direction = (DirectionPoint.position - transform.position) * Time.deltaTime * MoveSpeed * inputY;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction);

        Quaternion newRotationPart = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y + inputX * RotationSpeed, 
            transform.rotation.eulerAngles.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotationPart, Time.deltaTime * SmoothRotation);

        
        if (RaycastToSurface())
        {
            AlignToSurface();
        }
    }

    bool RaycastToSurface()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Vector3.Distance(transform.position, Apple.position)/*, AppleLayerMask*/))
        {
            Normal = hit.normal;
            return true;
        }
        return false;
    }

    void AlignToSurface()
    {
        Quaternion rotationToPlanet = Quaternion.FromToRotation(transform.up, -Apple.position) * transform.rotation;
        Quaternion surfaceRotation = Quaternion.FromToRotation(transform.up, Normal) * transform.rotation;

        Quaternion halfwayRotation = Quaternion.Lerp(rotationToPlanet, surfaceRotation, 0.1f);
        transform.rotation = halfwayRotation;
    }
}
