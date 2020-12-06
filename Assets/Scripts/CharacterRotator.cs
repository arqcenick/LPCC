using UnityEngine;
using System.Collections;
 
public class CharacterRotator : MonoBehaviour
{

    [SerializeField]
    private Transform _characterTransform;
    [SerializeField]
    private float _sensitivity = 0.1f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
     
    void Start ()
    {
        _rotation = Vector3.zero;
    }
     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;
            _mouseReference = Input.mousePosition;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
            Cursor.visible = true;
        }
        
        if(_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
             
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
             
            _characterTransform.Rotate(_rotation);
             
            _mouseReference = Input.mousePosition;
        }
    }
    
    
}