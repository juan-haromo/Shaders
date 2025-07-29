using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] Material _material;
    [SerializeField] Color _color;
    [SerializeField] string _propertyName = "_MainColor";
    [SerializeField] string _globalName = "_SecondaryColor";
    [SerializeField] ModifyMaterialType _modifyMaterialType;

    private MaterialPropertyBlock _materialPropertyBlock;

    public enum ModifyMaterialType
    {
        Instance,
        Material,
        SharedMaterial,
        PropertyBlock,
        Global
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            switch (_modifyMaterialType) 
            {
                //Crea una copia de la instacia del material en memoria
                case ModifyMaterialType.Instance: 
                    //_renderer.material.color = _color; //Solo funciona ocn la propiedad _MainColor
                    //_renderer.material.SetColor(_propertyName, _color); //Cambia cualquier propiedad de color
                    _renderer.material.SetColor(_propertyName, Color.HSVToRGB(Random.value,1,1));
                    break;
                //Modifica el material directamente, afectando a todas las instancias que lo usan
                case ModifyMaterialType.Material:
                    _material.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                    break;
                //Modifica el material comparido afectando a todos los objetos que usan el material
                case ModifyMaterialType.SharedMaterial:
                    _renderer.sharedMaterial.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                    break;
                // Modifica el MaterialProperyBlock, afectando al objeto actual
                case ModifyMaterialType.PropertyBlock:
                    _materialPropertyBlock.SetColor(_propertyName, Color.HSVToRGB(Random.value, 1, 1));
                    _renderer.SetPropertyBlock(_materialPropertyBlock);
                    break;
                case ModifyMaterialType.Global:
                    Shader.SetGlobalColor(_globalName, Color.HSVToRGB(Random.value, 1, 1));
                    break;
                default:
                    break;
            }
        }
    }
}
