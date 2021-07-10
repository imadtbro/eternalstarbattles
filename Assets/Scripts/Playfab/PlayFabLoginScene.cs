using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabLoginScene : MonoBehaviour
{


    // registration vars
    [Header("Registration Elements")]
    public TextMeshProUGUI RegistrationInfoText;
    public TextMeshProUGUI RegistrationErrorText;
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    [Header("Registration Info Variables")]
    public string baseInfoMessage = "CREATE A FREE ACCOUNT!";
    public string usernameInfoMessage = "";
    public string emailInfoMessage = "";
    public string passwordInfoMessage = "";

    [Header("Registration Error Variables")]
    public string noUsernameError = "";
    public string userNameShortError = "";
    public string userNameLongError = "";
    public string userNameSpecialCharsError = "";
    public string noEmailError = "";
    public string emailNotValidError = "";
    public string passwordNoMatchError = "";
    public string passwordRequirementsError = "";
    public string noPasswordError = "";


    // Start is called before the first frame update
    void Start()
    {
        //var request = new RegisterPlayFabUserRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegistrationSubmit() {
        RegistrationErrorText.gameObject.SetActive(false);

        if (!ValidateUsername()) {
            RegistrationErrorText.gameObject.SetActive(true);
            return;
        }

        if (!ValidateEmail()) {
            RegistrationErrorText.gameObject.SetActive(true);
            return;
        }
    }

    private bool ValidateUsername() {
        if (usernameInput != null) {
            if (string.IsNullOrEmpty(usernameInput.text)) {
                RegistrationErrorText.text = noUsernameError;
                return false;
            }

            if (usernameInput.text.Length < 3) {
                RegistrationErrorText.text = userNameShortError;
                return false;
            }

            if (usernameInput.text.Length > 20) {
                RegistrationErrorText.text = userNameLongError;
                return false;
            }

            if (usernameInput.text.Any(c => !char.IsLetterOrDigit(c))) {
                RegistrationErrorText.text = userNameSpecialCharsError;
                return false;
            }

        } else {
            return false;
        }

        return true;
    }

    private bool ValidateEmail() {
        if (emailInput != null) {
            if (string.IsNullOrEmpty(emailInput.text)) {
                RegistrationErrorText.text = noEmailError;
                return false;
            }

            if (!isValidEmail(emailInput.text)) {
                RegistrationErrorText.text = emailNotValidError;
                return false;
            }

        } else {
            return false;
        }

        return true;
    }

    private bool isValidEmail(string email) {
        try {
            var addr = new MailAddress(email);
            return addr.Address == email;
        } catch {
            return false;
        }
    }

    private bool ValidatePAssword() {
        if (passwordInput != null && confirmPasswordInput != null) {
            if (string.IsNullOrEmpty(passwordInput.text) || string.IsNullOrEmpty(confirmPasswordInput.text)) {
                RegistrationErrorText.text = noPasswordError;
                return false;
            }

            if (!string.Equals(passwordInput.text, confirmPasswordInput.text)) {
                RegistrationErrorText.text = passwordNoMatchError;
                return false;
            }

            if (!CheckPasswordRequirements(passwordInput.text)) {
                RegistrationErrorText.text = passwordRequirementsError;
                return false;
            }

        } else {
            return false;
        }

        return true;
    }

    private bool CheckPasswordRequirements(string password) {

        if (password.Length < 6) {
            return false;
        }

        if (password.Length > 100) {
            return false;
        }

        //number only //"^\d+$" if you need to match more than one digit.
        if (!Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?")) { 
            return false;
        }  

        //both, lower and upper case
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$")) {
            return false;
        } 

        //^[A-Z]+$
        if (!Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]")) {
            return false;
        } 


        return true;
    }

    public void ResetRegistrationInfoText() {
        RegistrationInfoText.text = baseInfoMessage;
    }

    public void SetUsernameInfo() {
        RegistrationInfoText.text = usernameInfoMessage;
    }

    public void SetEmailInfo() {
        RegistrationInfoText.text = emailInfoMessage;
    }

    public void SetPasswordInfo() {
        RegistrationInfoText.text = passwordInfoMessage;
    }
}
