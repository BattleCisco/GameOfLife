using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float chanceOfMutation;
    public float fillPercentage;
    public int cellsInRow;
    public int cellsInColumn;


    public float tick;
    float nextTick = 0f;

    public GameObject cell;
    Simulation simulation;

    GameObject[] cellObjects;

    // Use this for initialization
    void Start()
    {
        simulation = new Simulation(this);
        cellObjects = new GameObject[this.cellsInRow * this.cellsInColumn];

        for (int y = 0; y < this.cellsInRow; ++y)
            for (int x = 0; x < this.cellsInColumn; ++x) {
                Vector3 spawnOffset = new Vector3(x + 1, 0, y);
                cellObjects[x + this.cellsInRow * y] = Instantiate(cell, transform.position + spawnOffset, transform.rotation, transform);

                if (Random.Range(0, 100) > (this.fillPercentage * 100)) {
                    simulation.setCell(x, y, false);
                    cellObjects[x + this.cellsInRow * y].GetComponent<MeshRenderer>().enabled = false;
                }
                else {
                    simulation.setCell(x, y, true);
                }
            }
    }

    // Update is called once per frame
    void Update() {
        if (this.nextTick > this.tick)
        {
            this.setCellRendering(this.simulation.cells);
            simulation.step();
            this.nextTick -= this.tick;
        }
        this.nextTick += Time.deltaTime;
    }

    void setCellRendering(Cell[] newCells)
    {
        for (int i = 0; i < newCells.Length; i++)
        {
            if (newCells[i].alive)
            {
                cellObjects[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                cellObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}

