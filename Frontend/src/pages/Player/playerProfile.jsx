import React, {useState, useEffect} from 'react';
// import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

import messi from './../../assets/images/messi.jpg'
import './../Ecom/playerStyle.css';

import axios from 'axios';

function PlayerProfile () {
    
    const navigate = useNavigate();

    const [info, setInfo] = useState('');
   
    if(info.name === undefined){
        document.title="Profile";  
    }
    document.title="Profile-"+info.name;
 
    useEffect(() => {
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);
            axios.get("https://localhost:44345/api/profile", {
                headers: {
                  Authorization: respData // Set the Authorization header with the token value
                }
              })
              .then(resp => {
                
                if (resp.data != null) {
                    setInfo(resp.data);
                }
              })
              .catch(err => {
                console.log(err);
              });
        
    }, []);
     



    return(
        <div class="banner">
        <section class="vh-100"style={{ backgroundColor: '#f4f5f7' }}>
        <div class="container py-5 h-100">
          <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col col-lg-6 mb-4 mb-lg-0">
              <div class="card mb-3" style={{ borderRadius: '.5rem' }}>
                <div class="row g-0">
                  <div class="col-md-4 gradient-custom text-center text-white"
                    style={{ borderTopLeftRadius: '.5rem', borderBottomLeftRadius: '.5rem' }}>
                    <img src={messi} alt="Avatar" class="img-fluid my-5" style={{ width: '80px' }} />
                    <h2 style={{ color: 'black' }}>{info.Name}</h2>
                    <h4 style={{ color: 'black' }}>{info.Position}</h4>
                    <i class="far fa-edit mb-5"></i>
                  </div>
                  <div class="col-md-8">
                    <div class="card-body p-4">
                      <h6>Information</h6>
                      <hr class="mt-0 mb-4" ></hr>
                      <div class="row pt-1">
                        <div class="col-6 mb-3">
                          <h6>Email</h6>
                          <p class="text-muted">{info.Email}</p>
                        </div>
                        <div class="col-6 mb-3">
                          <h6>Date Of Birth</h6>
                          {new Date(info.Dob).toLocaleDateString('en-US', { dateStyle: 'short' })}
                        </div>
                      </div>
                      <button type="button" className="logIn" id="signUp" onClick={()=> navigate(-1)}>Back</button>
                      <br/>
                      <br/>
                      <div class="d-flex justify-content-start">
                        <a href="#!"><i class="fab fa-facebook-f fa-lg me-3"></i></a>
                        <a href="#!"><i class="fab fa-twitter fa-lg me-3"></i></a>
                        <a href="#!"><i class="fab fa-instagram fa-lg"></i></a>
                      </div>
                    </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        
      </section>
      </div>
    )
}

export default PlayerProfile;