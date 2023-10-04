import React, {useState, useEffect} from 'react';
import ReactHTMLTableToExcel from 'react-html-table-to-excel';

import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';
import {sweetConfirm, CustomAlert, ColorLoading, LoadingClose} from '../../../components/Alert';

import {Link} from 'react-router-dom';
import axios from 'axios';





function Admin () {
    var token = localStorage.getItem('token');
        var respData = JSON.parse(token);

    document.title = "Customers List";
    const [search, setSearch] = useState('');
    const [admin, setAdmin] = useState([]);
    const [isLoading, setLoading] = useState(true);
    const [isTrigger, setTrigger] = useState();
    useEffect(() => {
        setLoading(true);
        var token = localStorage.getItem('token');
        var respDataa = JSON.parse(token);
    axios.get("https://localhost:44345/api/users", {
        headers: {
          Authorization: respDataa // Set the Authorization header with the token value
        }
      }).then(resp=>{                                            
            setAdmin(resp.data);
            setLoading(false);
        }).catch(err=>{
            console.log(err, "admin list");
        });
    },[isTrigger]);

// Search
    const __handleSearch = (event) => { 
        setLoading(true);    
        setSearch(event.target.value);
    };

//DELETE
    const __handleDelete = (event) => {  
        sweetConfirm("?", "Delete !", "Are you sure to delete selected customer?")
        .then(confirmed => {
            ColorLoading();
            if(confirmed.isConfirmed){
                axios.get("https://localhost:44345/api/user/delete/"+event.target.id, {
                    headers: {
                      Authorization: respData
                    }
                  })
                .then(resp=>{
                    LoadingClose();
                    setTrigger(false);
                    if(resp.data){
                        CustomAlert("success", "Done", "Successfully customer deleted.");
                    } 
                    else{
                        CustomAlert("error", "Ops", "something went wrong.");
                    }              
                }).catch(err=>{
                    setLoading(false);
                    LoadingClose();
                    console.log(err);
                });
            }
        });
};


    
    return(
        <div className='dashboard-container'>
        <SideBar menu={sidebar_menu} />
        <div className='dashboard-content'>
            <DashboardHeader btnText="ADD"/>
            <div className='dashboard-content-container'>
                <div className='dashboard-content-header'>
                    <h2>Total Admin</h2>
                    <ReactHTMLTableToExcel
                    className="export"
                    table="table-to-xls"
                    filename="Admin"
                    sheet="tablexls"
                    buttonText="Export"/>
                    <div className='dashboard-content-search'>
                        
                        <input
                            type='text'
                            id='src'
                            value={search}
                            placeholder='email/id/name..'
                            className='dashboard-content-input'
                            onChange={e => __handleSearch(e)} />
                    </div>
                </div>

                {isLoading ?  ColorLoading()
                : 
                <table id='table-to-xls'>
                    <thead>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Action</th>
                    </thead>

                    {admin.length !== 0 ?
                        <tbody>
                            {admin.map((admin, index) => (
                                <tr key={index}>
                                    <td style={{textTransform: "capitalize"}}><Link to={`/getDetails/Admins/${admin.Id}`}>{admin.Name}</Link></td>
                                    <td><span>{admin.Email}</span></td>                                
                                    <td>  <button className='smallBtn' id={admin.Id} onClick={e => __handleDelete(e)} >Delete</button></td>                                 
                                </tr>
                            ))}
                        </tbody>
                    : 
                    <tbody>    
                        <tr>              
                        <td></td>
                        <td></td>
                        <td></td>
                        <td><span>NO DATA AVAILABLE</span></td>                                           
                        <td></td>
                        </tr>
                    </tbody>
                }
                  
                </table>
                }
                
            </div>
        </div>
        </div>
    )
}

export default Admin;