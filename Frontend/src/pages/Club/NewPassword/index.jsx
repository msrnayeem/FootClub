import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

import {Loading, LoadingClose, CustomAlert} from "../../../components/Alert";

function Login() {
  document.title = "New Password";
  const navigate = useNavigate();
  let[password, setPassword] =useState("");
  let[rePassword, setRePassword] =useState("");

  function cancel(){
    navigate("/");
  }

  const changeSubmit = (e) => {
    e.preventDefault();
    Loading();
    var obj = {
      Email : localStorage.getItem('email'),
      Password : password
    }
    axios.post("https://localhost:44345/api/changepassword",obj)
        .then(resp=>{ 
          LoadingClose();
           if(resp.data){
            localStorage.removeItem("email");
            CustomAlert("success", "Done", "Password Changed Successfully.Redirecting to Login...");
            navigate("/login");
           } 
           else{
            CustomAlert( "error", "Failed !", "please try again with different password");
           }  
        }).catch(err=>{
          LoadingClose();
           // CustomAlert("error", "Error !", "Axios cunnection error");
            console.log("Failed ", err);
        });
  };

  return (
    <div className="Login">
      <div className="loginForm">
          <div className="Lcontainer">
                <div className="header">
                <h3 className="hd">Change Password</h3>
                </div>
                
                
                <form autoComplete="off">
                
                <div> 
                    <input
                            name="password"
                            type="text"
                            id="email"
                            value={password}
                            onChange={(e)=>setPassword(e.target.value)}
                            placeholder="New Password"                            
                        />

                </div>
                <div>
                  <input
                  name="repassword"
                      type="text"
                      id="password"
                      value={rePassword} 
                      onChange={(e)=>setRePassword(e.target.value)}
                      placeholder="Re-type Password"                           
                />
                </div>
                
                <button type="button" className="logIn" name="logIn" onClick={changeSubmit}>Change</button>

                <button type="button" className="logIn" id="signUp" onClick={cancel}>Cancel</button>
                
                </form>          
        </div>     
      </div>
    </div>
  );
}


export default Login;