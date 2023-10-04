import React, {useState} from "react";
import emailjs from '@emailjs/browser';
import { useNavigate } from "react-router-dom";
import axios from "axios"; 

import {Loading, LoadingClose, CustomAlert} from "../../../components/Alert";

function Reset() {
  document.title = "Reset";
  let[findMail, setFindMail] = useState("");
  const navigate = useNavigate();
  
  function back(){
    navigate("/");
  };

  const findSubmit = (e) => {
    e.preventDefault();
    Loading();
    axios.get("https://localhost:44345/api/sendotp", {
      params: {
        email: findMail // Replace with the actual email
      }
      }).then(resp=>{            
            var  templateParams = {
                reply_to: findMail,
                otp: resp.data.otp,
                to_name: "RESET"
              }; 
            
            LoadingClose();
            if(resp.data !== 0){
              localStorage.setItem('otp',resp.data);
              localStorage.setItem('email',findMail);
               //navigate("/otp");
              
              emailjs.send('service_2dnh3gy', 'template_5vd1fv9',templateParams, 'wDdiUyapX3W2uuiOU')
              .then((result) => {
                   //navigate("/otp");
                console.log("done");
              }, (error) => {
                console.log(error);
              }); 
                   
            }
            else{
              LoadingClose();
              CustomAlert( "error", "Wrong info", "We did not found any account");
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
                <h3 className="hd">Find Account</h3>
                </div>
                <form autoComplete="on">
                <div> 
                    <input
                            name="findEmail"
                            type="email"
                            id="email"
                            value={findMail}
                            onChange={(e)=>setFindMail(e.target.value)}
                            placeholder="Enter Email" 
                            required                           
                        />
                </div>  
              <button type="button" className="logIn" name="logIn" onClick={findSubmit}>Find</button>
              <button type="button" className="logIn" id="signUp" onClick={back}>Cancel</button>
                </form>           
        </div>      
      </div>
    </div>
  );
}

export default Reset;