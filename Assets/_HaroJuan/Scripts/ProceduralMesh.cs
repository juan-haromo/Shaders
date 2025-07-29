using UnityEngine;

public class ProceduralMesh : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private Mesh _mesh;
    private MeshRenderer _meshRenderer;
    [SerializeField] private Material _material;

    void Start()
    {
        //Create components
        _meshFilter = gameObject.AddComponent<MeshFilter>();
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();

        //Create mesh
        _mesh = new Mesh();
        _mesh.name = "Procedural mesh";

        //Configure mesh
        _mesh.vertices = new Vector3[]
        {
            //cara trasera 
            new Vector3 (0,0,0),//0
            new Vector3 (0,1,0),//1
            new Vector3 (1,1,0),//2
            new Vector3 (1,0,0),//3

            //cara frontal
            new Vector3 (1,0,1),//4
            new Vector3 (1,1,1),//5
            new Vector3 (0,1,1),//6
            new Vector3 (0,0,1),//7
            
            //Cara derecha
            new Vector3 (1,0,0),//8
            new Vector3 (1,1,0),//9
            new Vector3 (1,1,1),//10
            new Vector3 (1,0,1),//11
            
            //Cara  izquierda
            new Vector3 (0,0,1),//12
            new Vector3 (0,1,1),//13
            new Vector3 (0,1,0),//14
            new Vector3 (0,0,0),//15
            
            //Cara superior
            new Vector3 (0,1,0),//16
            new Vector3 (0,1,1),//17
            new Vector3 (1,1,1),//18
            new Vector3 (1,1,0),//19
            
            //Cara inferior
            new Vector3 (0,0,1),//20
            new Vector3 (0,0,0),//21
            new Vector3 (1,0,0),//22
            new Vector3 (1,0,1),//23

        };

        _mesh.triangles = new int[]
        {
            //Cara trasera
            0,1,2,//A
            0,2,3,//B
            
            //Cara frontal
            4,5,6,//C
            4,6,7, //D

            //Cara derecha
            8,9,10,//E
            8,10,11,//F

            //Cara izquierda 
            12,13,14,//G
            12,14,15,//H

            //Cara superior 
            16,17,18,//I
            16,18,19,//J

            //Cara inferior 
            20,21,22,//K
            20,22,23//L
        };

        _mesh.uv = new Vector2[]
        {
            //Cara trasera
            new Vector2(0,0),//0
            new Vector2(0,1),//1
            new Vector2(1,1),//3
            new Vector2(1,0),//4

            //Cara frontal
            new Vector2(0,0),//4
            new Vector2(0,1),//5
            new Vector2(1,1),//7
            new Vector2(1,0),//6

            //Cara derecha
            new Vector2(0,0),//11
            new Vector2(0,1),//10
            new Vector2(1,1),//8
            new Vector2(1,0),//9

            //Cara izquierda
            new Vector2(0,0),//15
            new Vector2(0,1),//14
            new Vector2(1,1),//12
            new Vector2(1,0),//13

            //Cara superior
            new Vector2(0,0),//21
            new Vector2(0,1),//16
            new Vector2(1,1),//17
            new Vector2(1,0),//18

            //Cara inferior
            new Vector2(0,0),//23
            new Vector2(0,1),//20
            new Vector2(1,1),//22
            new Vector2(1,0),//19

        };

        _mesh.normals = new Vector3[]
        {
            //Cara trasera
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,

            //Cara frontal
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,

            
            //Cara derecha
            Vector3.right,
            Vector3.right,
            Vector3.right,
            Vector3.right,

            //Cara izquierda
            Vector3.left,
            Vector3.left,
            Vector3.left,
            Vector3.left,

            //Cara superior
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,

            //Cara inferior
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.down
            
        };

        _mesh.colors = new Color[]
        {
            //Cara trasera
            Color.black,
            Color.green,
            Color.yellow,
            Color.red,

            //Cara frontal
            Color.magenta,
            Color.white,
            Color.cyan,
            Color.blue,

            //Cara derecha
            Color.red,
            Color.yellow,
            Color.white,
            Color.magenta,

            //Cara izquierda
            Color.blue,
            Color.cyan,
            Color.green,
            Color.black,

            //Cara superior
            Color.green,
            Color.cyan,
            Color.white,
            Color.yellow,

            //Cara inferior
            Color.blue,
            Color.black,
            Color.red,
            Color.magenta
        };
        

        //Assign references
        _meshFilter.mesh = _mesh;
        _meshRenderer.material = _material;
    }

    void Update()
    {
        
    }
}
