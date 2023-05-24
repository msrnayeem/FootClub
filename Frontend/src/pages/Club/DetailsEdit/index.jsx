import React, {useState, useEffect} from 'react';

import {useNavigate, useParams} from 'react-router-dom';

import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';
import {Loading, LoadingClose, CustomAlert} from '../../../components/Alert';

import axios from 'axios';

function Update () {
    let { table_name } = useParams();
    let { idd } = useParams();
    
    const [user, setUser] = useState({
        name: "",
        email: ""
      });
    
    const { name, email } = user;
    
    const onInputChange = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value });
      };
    
      
      useEffect(() => {
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);

        if(table_name === "Admins"){
            axios.get("https://localhost:44345/api/user/"+idd, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{               
                setUser(resp.data);
              
            }).catch(err=>{
               
                console.log(err);
            });
        } else if (table_name === "Players"){
            axios.get("https://localhost:44345/api/player/"+idd, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{    
                        
                setUser(resp.data);
                
            }).catch(err=>{
               
                console.log(err);
            });
        }
        else{
            axios.get("https://localhost:44345/api/customers/"+idd)
            .then(resp=>{    
                          
                setUser(resp.data);
                
            }).catch(err=>{
                
                console.log(err);
            });
        }
    
        }, [idd, table_name]);
    
       const onSubmit = async (e) => {
        Loading();
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);

        e.preventDefault();
        
        if(table_name === "Admins"){
            var obj = { Id:idd, Name:name, Email: email, Password : user.Password};
            axios.post("https://localhost:44345/api/user/update/"+idd,obj, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{     
                LoadingClose();
                if(resp.data){
                    CustomAlert("success", "Done", "Successfully updated.");             
                    back();
                }
                else{
                    CustomAlert("error", "Ops", "something went wrong.");
                }
    
            }).catch(err=>{
                LoadingClose();
                console.log("edit error", err);
            }); 
        } else if (table_name === "Players"){
            var objj = { Id:idd, Name:name, Email: email, Password : user.Password,
                 Height : user.Height, Position : user.Position, Salary: user.Salary, Price: user.Price, Dob :user.Dob
                };
            axios.post("https://localhost:44345/api/player/update/"+idd, objj, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{    
                LoadingClose();
                if(resp.data){
                    CustomAlert("success", "Done", "Successfully updated.");             
                    back();
                }
                else{
                    CustomAlert("error", "Ops", "something went wrong.");
                }
                
            }).catch(err=>{
                LoadingClose();
                console.log(err);
            });
        }
        else{
            axios.get("https://localhost:44345/api/customers/update/", {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{    
                LoadingClose();
                if(resp.data){
                    CustomAlert("success", "Done", "Successfully updated.");             
                    back();
                }
                else{
                    CustomAlert("error", "Ops", "something went wrong.");
                }
                
            }).catch(err=>{
                LoadingClose();
                console.log(err);
            });
        }
        
        
      };
      const navigate = useNavigate();

      const back = () => {
       navigate(-1);
      }; 
    
    return(
        <div className='dashboard-container'>
        <SideBar menu={sidebar_menu} />
        <div className='dashboard-content'>
            <DashboardHeader />
            <div className='profile-content-container'>
                <div className='dashboard-content-header'>
                    <h2>Personal Information</h2> 
                </div>
                
            <div className="form">
              <form onSubmit={(e) => onSubmit(e)}>     
            <div className="form-body">
                <div className="name">
                    <label className="form__label" >Name </label>
                    <input className="form__input" type="text"   placeholder="First Name"
                    name="name" value={name}
                    onChange={(e) => onInputChange(e)}/>
                </div>
                
                <div className="email">
                    <label className="form__label" >Email </label>
                    <input  type="email"  className="form__input" placeholder="Email"
                    name="email" value={email}
                    onChange={(e) => onInputChange(e)}/>
                </div>
            </div>
            <div className="row">
                <div className="col-md-3">
                        <button className="btn btn-primary" type='submit'>Update</button>
                    </div>
                <div className="col-md-3">
                        <button className="btn btn-primary" type='button' onClick={back}>Cancel</button>
                    </div>  
                </div>
            </form> 
        </div>
                

            </div>
        </div>
        </div>
    )
}

export default Update;