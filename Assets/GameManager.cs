using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCountSelectionPanel; // Panel containing player count buttons
    [SerializeField] private Button eightPlayersButton;
    [SerializeField] private Button tenPlayersButton;
    [SerializeField] private Button twelvePlayersButton;
    [SerializeField] private Button showRoleButton;
    [SerializeField] private TextMeshProUGUI roleText;
    [SerializeField] private TextMeshProUGUI nextPlayerText;
    
    private List<string> playerRoles;
    private int currentPlayerIndex = 0;
    private int totalPlayers;
    
    void Start()
    {
        // Initial UI setup
        showRoleButton.gameObject.SetActive(false);
        roleText.gameObject.SetActive(false);
        nextPlayerText.gameObject.SetActive(false);
        
        // Add button listeners for player count selection
        eightPlayersButton.onClick.AddListener(() => StartGame(8));
        tenPlayersButton.onClick.AddListener(() => StartGame(10));
        twelvePlayersButton.onClick.AddListener(() => StartGame(12));
        
        // Add show role button listener
        showRoleButton.onClick.AddListener(ShowRole);
    }
    
    void StartGame(int playerCount)
    {
        totalPlayers = playerCount;
        InitializeGame();
        playerCountSelectionPanel.SetActive(false); // Hide the player count selection panel
        showRoleButton.gameObject.SetActive(true);
        showRoleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Click to show role";
        currentPlayerIndex = 0;
    }
    
    void InitializeGame()
    {
        // Initialize roles based on the total number of players
        playerRoles = new List<string>();

        if (totalPlayers == 8)
        {
            playerRoles.Add("Godfather");
            playerRoles.Add("Simple Mafia");
            playerRoles.Add("Professional Mafia");
            playerRoles.Add("Detective");
            playerRoles.Add("Doctor");
            playerRoles.Add("Ranger");
            playerRoles.Add("Citizen Number 1");
            playerRoles.Add("Citizen Number 2");
        }
        else if (totalPlayers == 10)
        {
            playerRoles.Add("Godfather");
            playerRoles.Add("Simple Mafia");
            playerRoles.Add("Professional Mafia");
            playerRoles.Add("Detective");
            playerRoles.Add("Doctor");
            playerRoles.Add("Ranger");
            playerRoles.Add("Mayor");
            playerRoles.Add("Citizen Number 1");
            playerRoles.Add("Citizen Number 2");
            playerRoles.Add("Citizen Number 3");
        }
        else if (totalPlayers == 12)
        {
            playerRoles.Add("Godfather");
            playerRoles.Add("Simple Mafia");
            playerRoles.Add("Professional Mafia");
            playerRoles.Add("Killer");
            playerRoles.Add("Detective");
            playerRoles.Add("Doctor");
            playerRoles.Add("Ranger");
            playerRoles.Add("Mayor");
            playerRoles.Add("Armored");
            playerRoles.Add("Researcher");
            playerRoles.Add("Citizen Number 1");
            playerRoles.Add("Citizen Number 2");
        }

        // Shuffle roles
        ShuffleRoles();
    }
    
    void ShuffleRoles()
    {
        for(int i = playerRoles.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            string temp = playerRoles[i];
            playerRoles[i] = playerRoles[randomIndex];
            playerRoles[randomIndex] = temp;
        }
    }
    
    void ShowRole()
    {
        if(currentPlayerIndex < playerRoles.Count)
        {
            roleText.gameObject.SetActive(true);
            roleText.text = playerRoles[currentPlayerIndex];
            showRoleButton.gameObject.SetActive(false);
            nextPlayerText.gameObject.SetActive(true);
            
            // Add delay before showing "Next Player" button
            Invoke("ShowNextPlayerPrompt", 2f);
        }
    }
    
    void ShowNextPlayerPrompt()
    {
        currentPlayerIndex++;
        
        if(currentPlayerIndex < playerRoles.Count)
        {
            roleText.gameObject.SetActive(false);
            showRoleButton.gameObject.SetActive(true);
            showRoleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Click to show role";
            nextPlayerText.gameObject.SetActive(false);
        }
        else
        {
            // Game has finished showing all roles
            roleText.text = "All roles have been distributed!";
            nextPlayerText.gameObject.SetActive(false);
        }
    }
}