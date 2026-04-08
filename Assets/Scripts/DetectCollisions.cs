using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Animal animal;

    private void Awake()
    {
        animal = GetComponent<Animal>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Acertou comida → ganha ponto
    if (other.CompareTag("Food"))
        {
            if (animal != null)
            {
                animal.FeedAnimal(1);
            }

            Destroy(other.gameObject); // destrói só a comida
        }
        // Errou (animal chegou no player ou passou)
        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife(1);

            Destroy(gameObject); // destrói só o objeto que bateu
            // NÃO destrói o player
        }
    }
}