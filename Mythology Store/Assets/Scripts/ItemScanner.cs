using UnityEngine;

public class ItemScanner : MonoBehaviour
{

    [SerializeField] AudioClip beepSound;
    [SerializeField] GameObject clipPlayer;
    [SerializeField] FoodScannerManager foodScannerManager;

    public void ScanProduct(Product product)
    {
        if (product.scanned == false)
        {
            product.ScanProduct();
            foodScannerManager.foodScanned++;
        }
        else
        {
            // Roku?
        }
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
