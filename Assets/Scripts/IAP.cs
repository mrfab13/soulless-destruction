using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    public static string RemoveAds = "moveads";

    void Start()
    {
        if (storeController == null)
        {
            initialisePurchasing();
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("purchase failed " + product.definition.storeSpecificId + " " + failureReason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, RemoveAds, StringComparison.Ordinal))
        {
            Debug.Log("turn ads off");
            PlayerPrefs.SetInt("noads", 1);
            //apply other no ads things here
        }
        else
        {
            Debug.Log("unknowen product");
        }

        return (PurchaseProcessingResult.Complete);
    }

    public void buyProductID(string productID)
    {
        if (isInitialized() == true)
        {
            Product product = storeController.products.WithID(productID);

            Debug.Log(productID);
            Debug.Log(product.transactionID);

            if ((product != null) && product.availableToPurchase)
            {
                Debug.Log("purchacing product");
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("product not found or unavilibe for purchace");
            }
        }
        else
        {
            Debug.Log("buy product failed, not initlised");
        }
    }

    public void initialisePurchasing()
    {
        if (isInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(RemoveAds, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed because: " + error);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized passed");
        storeController = controller;
        extensionProvider = extensions;
    }

    private bool isInitialized()
    {
        return ((storeController != null) && (extensionProvider != null));
    }
}
