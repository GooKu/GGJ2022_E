using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellIndex : MonoBehaviour
{
    [SerializeField] private bool m_ShowSkillRange = false;

    private int m_CurrectCellIndex;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 vector = Camera.main.WorldToScreenPoint(transform.position);
        Ray ray = Camera.main.ScreenPointToRay(vector);
        RaycastHit2D hit;
        if (Input.GetMouseButton(0) && Physics2D.Raycast(ray.origin, ray.direction))
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true);
            Debug.Log(hit.transform.name);
        }
    }

}
