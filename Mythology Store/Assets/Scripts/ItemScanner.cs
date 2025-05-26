using UnityEngine;

public class ItemScanner : MonoBehaviour
{

    [SerializeField] AudioClip beepSound;
    [SerializeField] GameObject clipPlayer;

    public void ScanProduct(Product product)
    {
        product.ScanProduct();
        Instantiate(clipPlayer).GetComponent<AudioSource>().PlayOneShot(beepSound);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Product product;
        if (collision.TryGetComponent<Product>(out product))
        {
            ScanProduct(product);
        }

    }
}
