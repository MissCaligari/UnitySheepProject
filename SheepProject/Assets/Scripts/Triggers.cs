using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    public GameObject sheep;
    
    private GameObject cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sheep.GetComponent<SheepWaypoints>().isPatrolling = false;
            //sheep.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
            if (cam.GetComponent<CameraFilterPack_Color_Chromatic_Aberration>().enabled == true)
                cam.GetComponent<CameraFilterPack_Colors_HUE_Rotate>().enabled = true;
            if (cam.GetComponent<CameraFilterPack_TV_Artefact>().enabled == true)
                cam.GetComponent<CameraFilterPack_Color_Chromatic_Aberration>().enabled = true;
            if (cam.GetComponent<CameraFilterPack_Distortion_Dream>().enabled == true)
                cam.GetComponent<CameraFilterPack_TV_Artefact>().enabled = true;
            cam.GetComponent<CameraFilterPack_Distortion_Dream>().enabled = true;
            Destroy(this.gameObject);
        }
    }

        void OnDrawGizmos()
    {
        Color giz = gizmoColor;
        giz.a = 0.5f;
        Gizmos.color = giz;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
