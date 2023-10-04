import React, {useEffect, useState} from 'react';
import { useLocation } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import SideBarItem from './sidebar-item';
import { confirmAlert } from 'react-confirm-alert'; // Import
import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css
import './styles.css';
import axios from 'axios';
import LogoutIcon from '../../assets/icons/logout.svg';
import {Loading , LoadingClose} from './../Alert/index';
function SideBar ({ menu }) {
    const location = useLocation();

    const [active, setActive] = useState(1);

    useEffect(() => {
        menu.forEach(element => {
            if (location.pathname === element.path) {
                setActive(element.id);
            }
        });
    }, [location.pathname,menu])

    const __navigate = (id) => {
        setActive(id);
    }
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
        Loading();
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);
            axios.get("https://localhost:44345/api/logout", {
                headers: {
                  Authorization: respData // Set the Authorization header with the token value
                }
              })
              .then(resp => {
                LoadingClose();
                if (resp.data) {
                  localStorage.removeItem("user");
                  navigate("/");
                }
              })
              .catch(err => {
                console.log(err);
              });
        }
    
    

    return(
        <nav className='sidebar'>
            <div className='sidebar-container'>
                <div className='sidebar-container'>
                    <div className='sidebar-items'>
                        {menu.map((item, index) => (
                            <div key={index} onClick={() => __navigate(item.id)}>
                                <SideBarItem
                                    active={item.id === active}
                                    item={item} />
                            </div>
                        ))}
                    </div>

                    <div className='sidebar-footer' onClick={logOut}>
                        <span className='sidebar-item-label'>Logout</span>
                        <img 
                            src={LogoutIcon}
                            alt='icon-logout'
                            className='sidebar-item-icon' />
                    </div>
                </div>
            </div>
        </nav>
    )
}

export default SideBar;