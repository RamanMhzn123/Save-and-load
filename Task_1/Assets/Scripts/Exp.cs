using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5.0f;

    public ExpData ExpData { get; set; } = new ExpData(); //new ExpData instance(set & get)

    private void Start() => ExpData.expName = gameObject.name; //expName

    void Update()
    {
        //exp rotation in x
        transform.Rotate(rotationSpeed* Time.deltaTime, 0, 0);
        ExpData.xRotation = transform.rotation.eulerAngles.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))//if collider have Player script
        {
            player.AddExp();

            Collect();
        }
    }

    public void Collect()
    {
        Debug.Log("Picked exp");
        gameObject.SetActive(false);
        ExpData.WasPickedUp = true;
    }

    public void Load(ExpData expData)
    {
        ExpData = expData;
        gameObject.SetActive(!ExpData.WasPickedUp);
        transform.rotation = Quaternion.Euler(ExpData.xRotation, 0, 0);
    }
}
