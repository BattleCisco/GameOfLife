using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {

    public int x, y;
    public Color cellColor;
    public bool alive;

    public Cell(int x, int y, Color cellColor, bool alive) {
        this.x = x;
        this.y = y;
        this.cellColor = cellColor;
        this.alive = alive;
    }

    public Cell(Cell cell) {
        this.x = cell.x;
        this.y = cell.y;
        this.cellColor = cell.cellColor;
        this.alive = cell.alive;
    }

	public void setState(bool alive) {
        this.alive = alive;
    }

    public static bool Equals(Cell obj1, Cell obj2)
    {
        return obj1 == obj2;
    }

    public static bool operator ==(Cell obj1, Cell obj2){
        if (ReferenceEquals(obj1, obj2)) {
            return true;
        }

        if (ReferenceEquals(obj1, null)) {
            return false;
        }

        if (ReferenceEquals(obj2, null)) {
            return false;
        }

        return (obj1.x == obj2.x
                && obj1.y == obj2.y
                && obj1.alive == obj2.alive);
    }

    // this is second one '!='
    public static bool operator !=(Cell obj1, Cell obj2) {
        return !(obj1 == obj2);
    }
}
