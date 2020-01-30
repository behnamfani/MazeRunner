using UnityEngine;
using System.Collections;

public class ProceduralNumberGenerator {

	public static int GetNextNumber() {
        return Random.Range(1,5);
	}
}
