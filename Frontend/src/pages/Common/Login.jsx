import React, {useState} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios"; 

import {Loading, LoadingClose, CustomAlert} from "../../components/Alert"; 

import styles from '../../assets/CSS/login.module.css'
import bgImage from './../../assets/images/bg-01.jpg'
const Submitted = (e) =>{
  e.preventDefault();
  console.log(e.data);
}

function Login() {
  document.title="Login to GrandView";
  let[email, setEmail] = useState("");
  let[password, setPassword] =useState("");
  const navigate = useNavigate();

  const loginSubmit = (e) => {
    e.preventDefault();
    Loading();
    var obj = {Email: email, Password: password};
    
    axios.post("https://localhost:44345/api/login",obj)
        .then(resp=>{ 
          // console.log(resp.data.Tkey);
              
            if(resp.data != null){
              localStorage.setItem('token', JSON.stringify(resp.data.Tkey));
              localStorage.setItem('customerMail', JSON.stringify(email));
                    axios.get("https://localhost:44345/api/checktable", {
                      headers: {
                        Authorization: resp.data.Tkey
                      }
                    })
                    .then(resp=>{
                      
                      LoadingClose(); 
                       if(resp.data === "Users"){
                            navigate("/profile");
                       }
                       else if(resp.data === "Players"){
                        navigate("/playerhome");}
                        else{
                          navigate("/products");
                        }
                    }).catch(err=>{
                      LoadingClose();
                        console.log("Failed ", err);
                    });
            }
            else{
              LoadingClose();
              CustomAlert("error", "Error !", "Email/Password not mathced");
            }
        }).catch(err=>{
          LoadingClose();
            CustomAlert("error", "Error !", "Axios cunnection error");
            console.log("Failed ", err);
        });
  };


  //Checking right mail or not
/*   const send = () =>{  
      
    axios.get('https://emailvalidation.abstractapi.com/v1/?api_key=b535ff641c2740ec8c211dad7bfe259d&email=msrnayeemm@gmail.com')
    .then(response => {
        console.log(response.data.deliverability);
    })
    .catch(error => {
        console.log(error);
    });       
    }
 */
  
  /* return (
    <div className="Login">
      <div className="loginForm">
        <div className="Lcontainer">
            <div className="header">
              <h3 className="hd">Welcome</h3>
            </div>
              <form>              
              
                  <input
                          type="email"
                          id="email"
                          value={email}
                          onChange={(e)=>setEmail(e.target.value)}
                          placeholder="Email"                            
                      />
             
              
                <input
                type="password"
                id="password"
                value={password} 
                onChange={(e)=>setPassword(e.target.value)}
                placeholder="Password"                           
              />
              
              <div>
                  <input type="checkbox" className="formCheckInput" name="remember" value="remember" />
                  <label>Remember me</label> <br></br>
                  <span  className="formCheckInput" onClick={()=> navigate("/reset")} style={{ cursor : 'pointer', color: 'darkBlue', textDecoration : 'underline'}}>Forgot password ?</span>
              </div>
              <button type="button" className="logIn" name="logIn" onClick={loginSubmit}>Log In</button>

              <button type="button" className="logIn" id="signUp" onClick={()=> navigate("/Registration")}>Sign Up</button>
              </form>          
      </div>    
      </div>
    </div>
  ); */

  return(
<div class="limiter">
		<div class="container-login100" style={{ backgroundImage: `url(${bgImage})` }}>
			<div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
				<form class="login100-form validate-form">
					<span class="login100-form-title p-b-49">
						Login
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Username is reauired">
						<span class="label-input100">Username</span>
						<input class="input100" type="text" name="username" placeholder="Type your username" />
						<span class="focus-input100" data-symbol="&#xf206;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Password is required">
						<span class="label-input100">Password</span>
						<input class="input100" type="password" name="pass" placeholder="Type your password" />
						<span class="focus-input100" data-symbol="&#xf190;"></span>
					</div>
					
					<div class="text-right p-t-8 p-b-31">
						<p>
							Forgot password?
						</p>
					</div>
					
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<button class="login100-form-btn">
								Login
							</button>
						</div>
					</div>

					<div class="txt1 text-center p-t-54 p-b-20">
						<span>
							Or Sign Up Using
						</span>
					</div>

					<div class="flex-c-m">
						<p class="login100-social-item bg1">
							<i class="fa fa-facebook"></i>
						</p>

						<p class="login100-social-item bg2">
							<i class="fa fa-twitter"></i>
						</p>

						<p class="login100-social-item bg3">
							<i class="fa fa-google"></i>
						</p>
					</div>

					<div class="flex-col-c p-t-155">
						<span class="txt1 p-b-17">
							Or Sign Up Using
						</span>

						<p class="txt2">
							Sign Up
						</p>
					</div>
				</form>
			</div>
		</div>
	</div>
	
    
  );
}


export default Login;