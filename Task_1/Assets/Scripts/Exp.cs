using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5.0f;

    public ExpData ExpData { get; set; } = new ExpData();

    private void Start() => ExpData.expName = gameObject.name;

    void Update()
    {
        transform.Rotate(rotationSpeed* Time.deltaTime, 0, 0);
        ExpData.xRotation = transform.rotation.eulerAngles.x;
    }

    public string PickedUpKey => $"Exp-{gameObject.name}-PickedUp";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.AddExp();
            gameObject.SetActive(false);
            ExpData.WasPickedUp = true;
        }
    }

    public void Load(ExpData expData)
    {
        ExpData = expData;
        gameObject.SetActive(!ExpData.WasPickedUp);
        transform.rotation = Quaternion.Euler(ExpData.xRotation, 0, 0);
    }
}
