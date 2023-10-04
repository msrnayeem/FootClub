import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios"; 

import {Loading, LoadingClose, CustomAlert} from "../../../components/Alert";

function Reset() {
  document.title = "Reset";
  let[Otp, setOtp] = useState("");
  const navigate = useNavigate();
  
  function cancel(){
    navigate("/reset");
  }


  const otpSubmit = (e) => {
    e.preventDefault();
    Loading();
    var Email = localStorage.getItem('email');
    axios.get("https://localhost:44345/api/matchotp",{ params: {otp: Otp, email: Email} })
        .then(resp=>{   
          if(resp.data){
            LoadingClose();
            localStorage.removeItem("otp");
            navigate("/newPassword");
          }
          else{
              LoadingClose();
              CustomAlert( "error", "Wrong Info", "please provide correct otp");
          }
          
        }).catch(err=>{ 
          LoadingClose();
          CustomAlert( "info", "Error !", "Axios Connection Error");
        }); 
  };

  return (
    <div className="Login">
          <div className="loginForm">
                <div className="Lcontainer">
                <div className="header">
                <h3 className="hd">OTP</h3>
                </div>
                
                <form autoComplete="off">
                
                <div> 
                    <input
                            type="text"
                            id="email"
                            value={Otp}
                            onChange={(e)=>setOtp(e.target.value)}
                            placeholder="Enter Otp"                            
                        />

                </div>
                
                <button type="button" className="logIn" name="logIn" onClick={otpSubmit}>Submit</button>
                <button type="button" className="logIn" id="signUp" onClick={cancel}>Back</button>
                </form>           
        </div>     
      </div>
    </div>
  );
}


export default Reset;