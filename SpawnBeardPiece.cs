using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBeardPiece : MonoBehaviour
{
    public GameObject StraightPiece;
    public GameObject CornerPiece;

    private Vector3 last_dir;

    public void Trigger(Vector3 dir, Vector3 pos)
    {
        if( dir == last_dir )
        {
            var obj = Instantiate(StraightPiece, pos, Quaternion.identity);
            obj.transform.LookAt(pos + dir);
        }
        else if( dir == Quaternion.Euler(0, 90, 0) * last_dir )
        {
            // clockwise turn
            var obj = Instantiate(CornerPiece, pos, Quaternion.identity);
            obj.transform.LookAt(pos + dir);
        }
        else if( dir == Quaternion.Euler(0, -90, 0) * last_dir )
        {
            // counter-clockwise
            var obj = Instantiate(CornerPiece, pos, Quaternion.identity);
            obj.transform.LookAt(pos - last_dir);
        }
        else // moving backwards (only once)
        {
            // do nothing?
            // check for existing beard piece?
        }
        last_dir = dir;
    }
}
