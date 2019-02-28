using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {
    public ReferenceController refCtrl;
    public Agent agentPrefab;
    Agent agent;
    MapController mc;

    int agentX;
    int agentY;

    private void Start()
    {
        mc = refCtrl.mapCtrl;

        agent = Instantiate(agentPrefab, this.transform);


        while (true)
        {
            agentX = Random.Range(0, mc.Map.GetLength(0));
            agentY = Random.Range(0, mc.Map.GetLength(1));

            agent.transform.position = new Vector3(agentX, agentY, -1f);

            TerrainObj agentTerrain = mc.Map[agentX, agentY];

            Debug.Log(agentTerrain.GetType());

            if (agentTerrain.type == TerrainObj.Type.grass)
            {
                Debug.Log("Set Home");
                break;
            }
            else
                Debug.Log("Roll Again");
        }

    }
}
