import React from 'react';
import { confirmAlert } from 'react-confirm-alert'; // Import
import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css
import './styles.css';
import { useNavigate } from "react-router-dom";
import LogoutIcon from '../../assets/icons/user.svg';

import axios from 'axios';


function DashboardHeader ({ btnText, onClick }) {
    const navigate = useNavigate();
    function logOut(){
        confirmAlert({
      title: 'Logout',
      message: 'Are you sure to logout.?',
      buttons: [
        {
          label: 'Yes',
          onClick: () =>doLogout()
        },
        {
          label: 'No',
          onClick: () => console.log('')
        }
      ]
    });
    }

    function doLogout (){
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);
            axios.get("https://localhost:44345/api/logout", {
                headers: {
                  Authorization: respData // Set the Authorization header with the token value
                }
              })
              .then(resp => {
                var result = resp.data;
                if (result === "done") {
                  localStorage.removeItem("user");
                  navigate("/");
                }
              })
              .catch(err => {
                console.log(err);
              });
    
    }


    return(
        <div className='dashbord-header-container'>
            
            <div></div>
            

            <div className='dashbord-header-right'>
                <img 
                    src={LogoutIcon}
                    alt='Logout-icon'
                    className='dashbord-header-icon' 
                    onClick={logOut}/>
              
            </div>
        </div>
    )
}

export default DashboardHeader;