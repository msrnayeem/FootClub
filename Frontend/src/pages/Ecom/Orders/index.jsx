import React, {useState, useEffect} from 'react';
import ReactHTMLTableToExcel from 'react-html-table-to-excel';

import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';

import {Link} from 'react-router-dom';
import axios from 'axios';


import { ColorLoading } from '../../../components/Alert';


function Orders () {


    document.title = "Customers List";
    const [search, setSearch] = useState('');
    const [admin, setAdmin] = useState([]);
    const [isLoading, setLoading] = useState(true);
    const [isTrigger] = useState(true);
    
    useEffect(() => {
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);
        setLoading(true);
    axios.get("https://localhost:44345/api/orders", {
        headers: {
          Authorization: respData // Set the Authorization header with the token value
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
                        <th>Order Id</th>
                        <th>Quantity</th>
                        <th>Status</th>
                        <th>Customer Id</th>
                    </thead>

                    {admin.length !== 0 ?
                        <tbody>
                            {admin.map((admin, index) => (
                                <tr key={index}>
                                    <td style={{textTransform: "capitalize"}}><Link to={`/getDetails/orders/${admin.Id}`}>{admin.Id}</Link></td>
                                    <td>{admin.Quantity}</td>
                                    <td><span>{admin.Status}</span></td>
                                    <td>{admin.CustomerId}</td>                                                               
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

export default Orders;