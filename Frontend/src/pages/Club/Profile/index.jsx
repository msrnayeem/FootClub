import React, {useState, useEffect} from 'react';
// import { Link } from 'react-router-dom';



import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';
import {sweetConfirm, CustomAlert, ColorLoading, LoadingClose} from '../../../components/Alert';

import axios from 'axios';

function Profile () {
    const [isLoading, setLoading] = useState(true);
    const [isChange, setChange] = useState(true);
    const [isUpdateBtn, setIsUpdateBtn] = useState(true);
    const [isNew, setNew] = useState(false);
    const [info, setInfo] = useState('');
    const [currentPass, setCurrentPass] = useState('');
    const [newPass, setNewPass] = useState('');
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
     
    useEffect(() => {
        setLoading(true);
        const user = localStorage.getItem('user'); 
        
        axios.get("http://127.0.0.1:8000/api/profile",{ params: {user_token: user} })
            .then(resp=>{  
                LoadingClose();
                //console.log(resp.data);
                setInfo(resp.data);
                setLoading(false);  
            }).catch(err=>{
                setLoading(false); 
                console.log("profile", err);
            });
        
    }, []);

    function handleNewPass(){
        setChange(false);
        setNew(true);
        setIsUpdateBtn(false);
    }
    function handleNewPassCancel() {
        setChange(true);
        setNew(false);
        setIsUpdateBtn(true);
    }

    const saveNewPass = () => {
        if (currentPass === '' || newPass === '') {
            CustomAlert("info", "Alert", "Select all the requirements");
        }
        else {
            sweetConfirm("?", "New Password !", "Are you sure to change password?")
                .then(confirmed => {
                    if (confirmed.isConfirmed) {
                        ColorLoading();
                        var obj = {
                            Email : info.Email,
                            Password : newPass
                          }
                          
                          axios.post("https://localhost:44345/api/changepassword",obj)
                              .then(resp=>{ 
                                LoadingClose();
                                 if(resp.data){
                                  
                                  CustomAlert("success", "Done", "Password Changed Successfully.Redirecting to Login...");
                                  handleNewPassCancel();
                                 } 
                                 else{
                                  CustomAlert( "error", "Failed !", "please try again with different password");
                                 }  
                              }).catch(err=>{
                                LoadingClose();
                                 // CustomAlert("error", "Error !", "Axios cunnection error");
                                  console.log("Failed ", err);
                              });
                        
                    }
                });

        }

    }

    function newPassField()
    {
        return (
            <>
            <form autoComplete="off">
                    <div className="col-md-12">
                        <label className="labels" >Current Password</label>
                        <input type="password" className="form-control"   placeholder="Enter Current Password" value={currentPass} onChange={(e) => setCurrentPass(e.target.value)} />
                    </div>
                    <br />
                    <div className="col-md-12">
                        <label className="labels" >New Password</label>
                        <input type="password" className="form-control"  placeholder="Enter new Password" value={newPass} onChange={(e) => setNewPass(e.target.value)} />
                    </div>
                    <br />
                    <div className="col-md-12">
                        <label className="labels" >Confirm Password</label>
                        <input type="password" className="form-control"   placeholder="Re-Enter new Password" />
                    </div>
                    <div className="col">
                        <button className="btn btn-primary" type="button" style={{ marginLeft: "0px" }} onClick={ saveNewPass }>Save</button>
                        <button className="btn btn-primary" type="button" style={{ marginLeft: "22px" }} onClick={handleNewPassCancel }>Cancel</button>
                    </div>
                               
            </form>
            </>)
    }

    function updateBtn() {
        return (
            <>
                <div className="col-md-3">
                  {/* <Link to={`/update/${ +"s" }/${info.Id}`} className="btn btn-primary">Update</Link> */}
                </div>
            </>)
    }

    function newBtn() {
        return (
            <>
                <div className="col-md-6">
                    <button onClick={handleNewPass}>change password</button>
                </div>
            </>)
    }

    return(
        <div className='dashboard-container'>
        <SideBar menu={sidebar_menu} />
        <div className='dashboard-content'>
            <DashboardHeader />
            

                
{isLoading ? ColorLoading() :
                    <>
                        <div className="container bg-white">
                <div className="row">
                    <div className="col-md-4 border-right">
                                        <div className="d-flex flex-column align-items-center text-center p-3 py-5">
                                            <img className="rounded-circle mt-5" width="150px"
                                             src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg" alt="profile pic" />
                                        <span style={{ textTransform: "capitalize" }} className="font-weight-bold"> {info.Name}</span>
                                       
                                        {isNew ? null : newBtn()}
                                    </div>
                    </div>
                    <div className="col-md-5 border-right">
                        <div className="p-3 py-5">
                            <div className="d-flex justify-content-between align-items-center mb-3">
                                <h4 className="text-right">Profile</h4>
                            </div>
                            <div className="row mt-2">
                                <div className="col-md-12">
                                    <label className="labels">Name</label>
                                                <input type="text" className="form-control" style={{ textTransform: "capitalize" }} value={info.Name} disabled={true} />
                                </div>
                                
                            </div>
                            <div className="row mt-3">
                                
                                          
                                <div className="col-md-12">
                                    <label className="labels">Email</label>
                                                <input type="text" className="form-control" value={info.Email} disabled={true} />
                                </div>
                                
                                
                            </div>
                            
                                        <div className="row mt-3">
                                            { isUpdateBtn ?  updateBtn() : null }
                                           
                                        </div>
                        </div>
                    </div>
                    <div className="col-md-3">
                                    <div className="p-3 py-5">
                                        {isChange ? null : newPassField()}
                                </div>
                        </div>
                    </div>
                </div>
                           
                       
        </>
    }
                 
            </div>
        </div>
       
    )
}

export default Profile;