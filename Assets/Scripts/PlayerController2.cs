using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private GameObject GlobalManager;
    public GameObject MintNFTMenu;
    public GameObject VoucherMintNFTMenu;
    public GameObject VerifyMenu;
    public GameObject SignMenu;
    public GameObject TransferMenu;
    public GameObject ContractMenu;
    public GameObject VoucherMenu;
    public GameObject MarketplaceMenu;
    public GameObject WelcomeMenu;
    public GameObject AchievementText;
    public Text WalletText;
    public Text CoinsText;
    public Text LivesText;
    private Rigidbody rb;
   

    void Awake()
    {
        // finds global object
        GlobalManager = GameObject.FindGameObjectWithTag("Global");
        // sets texts
        WalletText.text = PlayerPrefs.GetString("Account");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        LivesText.text = "Lives: " + GlobalManager.GetComponent<Global>().globalLives.ToString();
        rb = GetComponent<Rigidbody>();

        // pops up welcome menu at start of game
        if (GlobalManager.GetComponent<Global>().globalLives == 5)
        {
            WelcomeMenu.SetActive(true);
            SignMenu.SetActive(true);
        }
    }

    // used when player collides with tagged objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            // checks if player has 0 lives on hit, if greater than 0, subract 1
            if (GlobalManager.GetComponent<Global>().globalLives > 0)
            {
                GlobalManager.GetComponent<Global>().globalLives -= 1;
                LivesText.text = "Lives: " + GlobalManager.GetComponent<Global>().globalLives.ToString();
                FindObjectOfType<AudioManager>().Play("Cluck");
                SceneManager.LoadScene("Game");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Cluck");
                SceneManager.LoadScene("Game");
            }
        }
    }

    // used when player collides with tagged objects
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        // adds 1 to coin score, displays it and destroys the coin
        if (hit.transform.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            FindObjectOfType<AudioManager>().Play("Cluck");
            GlobalManager.GetComponent<Global>().globalCoins += 1;
            CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
            Destroy(hit.gameObject);
        }

        void OnCollisionEnter(Collision collision)
        {
            // If the AI character collides with a specific object
            if (collision.gameObject.tag == "Sign")
            {
                // Enable the menu
                SignMenu.SetActive(true);
            }
        }

        // makes menus pop up
        if (hit.transform.tag == "MintNFT")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            MintNFTMenu.SetActive(true);
        }

        if (hit.transform.tag == "VoucherMintNFT")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            VoucherMintNFTMenu.SetActive(true);
        }

        if (hit.transform.tag == "Verify")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            VerifyMenu.SetActive(true);
        }

        if (hit.transform.tag == "Sign")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            SignMenu.SetActive(true);
        }

        if (hit.transform.tag == "Transfer")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            TransferMenu.SetActive(true);
        }

        if (hit.transform.tag == "Contract")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            ContractMenu.SetActive(true);
        }

        if (hit.transform.tag == "Voucher")
        {
            if (GlobalManager.GetComponent<Global>().globalCoins > 0)
            {
                FindObjectOfType<AudioManager>().Play("Pop");
                VoucherMenu.SetActive(true);
            }
            else
            {
                Debug.Log("Get More Coins!");
            }
        }

        if (hit.transform.tag == "Marketplace")
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            MarketplaceMenu.SetActive(true);
        }
    }

    // menu close buttons, usually you would subtract a coin once the blockchain call has suceeded, I've just done it here to show you how in the voucher script

    public void CloseVoucherMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        if (GlobalManager.GetComponent<Global>().globalCoins > 0)
        {
            GlobalManager.GetComponent<Global>().globalCoins -= 1;
            CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        }
        VoucherMenu.SetActive(false);
    }

    public void CloseMintNFTMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        MintNFTMenu.SetActive(false);
    }

    async public void CloseVoucherMintNFTMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        VoucherMintNFTMenu.SetActive(false);
        AchievementText.SetActive(true);
        await new WaitForSeconds(5);
        AchievementText.SetActive(false);
    }

    public void CloseVerifyMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        VerifyMenu.SetActive(false);
    }

    public void CloseSignMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        SignMenu.SetActive(false);
    }

    public void CloseTransferMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        TransferMenu.SetActive(false);
    }

    public void CloseContractMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        CoinsText.text = "Coins: " + GlobalManager.GetComponent<Global>().globalCoins.ToString();
        ContractMenu.SetActive(false);
    }

    public void CloseMarketplaceMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        MarketplaceMenu.SetActive(false);
    }

    public void CloseWelcomeMenu()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
        WelcomeMenu.SetActive(false);
        SignMenu.SetActive(true);
    }

    public void OpenMarketplace()
    {
        Application.OpenURL("https://marketplace-ui.onrender.com/");
    }

  
}
