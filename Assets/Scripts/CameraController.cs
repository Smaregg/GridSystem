using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class CameraController : MonoBehaviour
{
    public float Speed = 5;

    private float m_fMoveForward = 0;
    private float m_fMoveBackword = 0;
    private float m_fMoveLeft = 0;
    private float m_fMoveRight = 0;
    private float m_fMoveUp = 0;
    private float m_fMoveDown = 0;

    private float m_fHorizontal = 0;
    private float m_fVertival = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_fMoveForward = 0;
        m_fMoveBackword = 0;
        m_fMoveLeft = 0;
        m_fMoveRight = 0;
        m_fMoveUp = 0;
        m_fMoveDown = 0;
        m_fHorizontal = 0;
        m_fVertival = 0;

        if (Input.GetKey(KeyCode.W))
            m_fMoveForward = 1;
        if (Input.GetKey(KeyCode.S))
            m_fMoveBackword = 1;
        if (Input.GetKey(KeyCode.A))
            m_fMoveLeft = 1;
        if (Input.GetKey(KeyCode.D))
            m_fMoveRight = 1;
        if (Input.GetKey(KeyCode.E))
            m_fMoveUp = 1;
        if (Input.GetKey(KeyCode.Q))
            m_fMoveDown = 1;
        m_fHorizontal = Input.GetAxis("Mouse X");
        m_fVertival = Input.GetAxis("Mouse Y");

        bool isRotateCam = false;
        if (Input.GetMouseButton(1))
        {
            isRotateCam = true;
        }

        UpdateMovement(isRotateCam);

        if (m_fHorizontal != 0 || m_fVertival != 0)
            RayCastDetectCell();
    }

    private void UpdateMovement(bool rotateCam)
    {
        Vector3 moveDelta = new Vector3(Speed * Time.deltaTime * (m_fMoveRight - m_fMoveLeft),
                                        Speed * Time.deltaTime * (m_fMoveUp - m_fMoveDown), 
                                        Speed * Time.deltaTime * (m_fMoveForward - m_fMoveBackword));
        Vector3 rotateDelta = new Vector3(-m_fVertival, m_fHorizontal, 0);
        if (rotateCam)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotateDelta);
        transform.position += transform.rotation * moveDelta;
    }

    private void RayCastDetectCell()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycast;
        Cell hitTile = null;
        if (Physics.Raycast(ray, out raycast, 100, 1 << 9))
        {
            hitTile = GridPlugin.Instance.grid.GetCellByWorldPos(raycast.point);
        }

        if (hitTile != null)
        {
            GridPlugin.Instance.SetBuildToCell(hitTile);
        }
        else
        {
            GridPlugin.Instance.SetBuildActive(false);
        }
    }
}
