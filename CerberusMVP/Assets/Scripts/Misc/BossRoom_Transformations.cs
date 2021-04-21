using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossRoom_Transformations : MonoBehaviour
{
    // Start is called before the first frame update

    public float ElevationSpeed = .1f;
    public float TimingOffset;
    
    
    private List<Transform> _platformTransforms = new List<Transform>();
    private List<Transform> _bossRoomChildTransforms = new List<Transform>();
    private Transform _bossRoomTransform; // rotato this obj
    private float _platformHeight;
    
    

    void Start()
    {
        _bossRoomTransform = GetComponent<Transform>(); // parent obj transform
        _bossRoomChildTransforms = gameObject.GetComponentsInChildren<Transform>().ToList();
        
        // get children that need to move up and down
        foreach (Transform child in _bossRoomChildTransforms)
        {
            if (child.gameObject.CompareTag("BossPlatform"))
            {
                _platformTransforms.Add(child);
            }
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        foreach (Transform platform in _platformTransforms)
        {
            var transformPosition = platform.transform.position;
            // The Z transform should go between 0 and .9 to look right. 
            if (transformPosition.z <= .9f)
            {
                transformPosition.z += ElevationSpeed * Time.deltaTime;
            }
            else
            {
                transformPosition.z -= ElevationSpeed * Time.deltaTime;
            }
            
        }
    }

    
}
