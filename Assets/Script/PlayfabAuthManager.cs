using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabAuthManager : MonoBehaviour
{
    public InputField user_name_login;
    public InputField user_password_login;

    public InputField user_name_register;
    public InputField user_email_register;
    public InputField user_password1_register;
    public InputField user_password2_register;

    public void Login()
    {


            var request = new SendAccountRecoveryEmailRequest();
            request.Email = "SanDong0313@gmail.com";
            request.TitleId = "4D6EC";

            PlayFabClientAPI.SendAccountRecoveryEmail(request ,
            res => 
            {
                Debug.Log("Initialize request has been sent your email");
            },
            err => {
                Debug.Log(err.ErrorMessage);
            });

        LoginWithPlayFabRequest  req = new LoginWithPlayFabRequest 
        {
            Username = user_name_login.text,
            Password = user_password_login.text
        };

        PlayFabClientAPI.LoginWithPlayFab (req,
        res =>
        {
            Debug.Log("Success Login");
        },
        err =>
        {
            Debug.Log(err.ErrorMessage);
        });
    }

    public void Register()
    {
        RegisterPlayFabUserRequest req = new RegisterPlayFabUserRequest
        {
            Username = user_name_register.text,
            Email = user_email_register.text,        
            Password = user_password1_register.text,
            RequireBothUsernameAndEmail = true
        };

        PlayFabClientAPI.RegisterPlayFabUser(req,
        res =>
        {
            AddOrUpdateContactEmail();
        },
        err =>
        {
            Debug.Log(err.ErrorMessage);
        });
    }

    public void AddOrUpdateContactEmail()
    {
        var request = new AddOrUpdateContactEmailRequest();
        request.EmailAddress = user_email_register.text;

        PlayFabClientAPI.AddOrUpdateContactEmail(request ,
        res => {
            Debug.Log("The player's account has been updated with a contact email");
        },
        err => {
            Debug.Log(err.ErrorMessage);
        });
    }
}
