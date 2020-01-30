using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	public int mazeRows, mazeColumns , coinnumber;
    public GameObject coin;
	public GameObject wall;
	public float size = 2f;
	private MazeCell[,] mazeCells;
    public static int timeBycoins , NumberOfcoins;
    public Text allcoin ; 

	// Use this for initialization
	void Start () {
        allcoin.text = " / " + coinnumber.ToString();
        NumberOfcoins = coinnumber;
        timeBycoins = mazeRows;
		InitializeMaze ();
		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		ma.CreateMaze ();
       
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void InitializeMaze() {

		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				
				mazeCells [r, c] .floor = Instantiate (wall, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);



                if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
			    mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
			}
		}
        coinGenerator();


	}

    private void coinGenerator()
    {
        int randomrow, randomcolumn;
        for (int i = 0; i < coinnumber ; i++)
        {
            randomrow = Random.Range(1, mazeRows);
            randomcolumn = Random.Range(1, mazeColumns);

            if (mazeCells[randomrow, randomcolumn].exist) i = i - 1;

            else{
                mazeCells[randomrow, randomcolumn].coin = Instantiate(coin, new Vector3(randomrow * size, -(size / 2f), randomcolumn * size), Quaternion.identity) as GameObject;
                mazeCells[randomrow, randomcolumn].coin.name = "coin " + randomrow + "," + randomcolumn;
                mazeCells[randomrow, randomcolumn].coin.transform.Translate(Vector3.up * size / 2);
                mazeCells[randomrow, randomcolumn].coin.transform.Rotate(90, 0, 0);
                mazeCells[randomrow, randomcolumn].exist = true;
            }

        }
    }
}
