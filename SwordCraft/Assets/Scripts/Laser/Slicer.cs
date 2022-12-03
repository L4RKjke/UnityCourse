using UnityEngine;
using EzySlice;

public class Slicer : MonoBehaviour
{
    [SerializeField] private Material materialAfterSlice;
    [SerializeField] private LayerMask sliceMask;
    [SerializeField] private GameObject _model;
    [SerializeField] private Laser _laser;

    private readonly int _childId = 0;

    private void OnEnable()
    {
        _laser.LaserHitted += MoveSlicer;
    }

    private void OnDisable()
    {
        _laser.LaserHitted -= MoveSlicer;
    }

    public void Slice()
    {
        Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);

        foreach (Collider objectToBeSliced in objectsToBeSliced)
        {
            var child = objectToBeSliced.transform.GetChild(_childId);
            var parentRotation = objectToBeSliced.transform.rotation;

            SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

            GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
            GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

            InitLowerHull(parentRotation, lowerHullGameobject, objectToBeSliced);
            InitUpperHull(child, upperHullGameobject, objectToBeSliced);
       
            Destroy(objectToBeSliced.gameObject);

            break;
        }

        gameObject.SetActive(false);
    }

    public void MoveSlicer(Vector3 position)
    {
        transform.position = position;
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
    }
    private void MakeLowerPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

    private void InitLowerHull(Quaternion rotation, GameObject lowelHull, Collider objectToBeSliced)
    {
        lowelHull.transform.position = objectToBeSliced.transform.position;
        lowelHull.transform.localRotation = rotation;
        MakeLowerPhysical(lowelHull);
    }

    private void InitUpperHull(Transform child, GameObject upperHullGameobject, Collider objectToBeSliced)
    {
        upperHullGameobject.transform.position = objectToBeSliced.transform.position;
        upperHullGameobject.transform.SetParent(_model.transform, true);
        upperHullGameobject.transform.localRotation = (Quaternion.Euler(0, 0, 0));
        upperHullGameobject.AddComponent<Sword>();
        child.SetParent(upperHullGameobject.transform, true);
        upperHullGameobject.layer = 8;
        MakeItPhysical(upperHullGameobject);
    }
}
