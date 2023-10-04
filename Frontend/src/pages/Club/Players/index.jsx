import React, {useState, useEffect} from 'react';
import ReactHTMLTableToExcel from 'react-html-table-to-excel';

import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';
import {sweetConfirm, CustomAlert, ColorLoading} from '../../../components/Alert';

import {Link} from 'react-router-dom';
import axios from 'axios';



function Players () {
    document.title = "Admins List";
    const [search, setSearch] = useState('');
    const [players, setPlayers] = useState([]);
    const [isLoading, setLoading] = useState(true);
    const [isTrigger, setTrigger] = useState();
    var token = localStorage.getItem('token');
        var respData = JSON.parse(token);

    useEffect(() => {
        setLoading(true);
        axios.get("https://localhost:44345/api/players")
            .then(resp=>{               
                var lists = resp.data;                               
                setPlayers(lists);
                setLoading(false);
            }).catch(err=>{
                console.log(err);
            });

        }, [isTrigger]);

    // Search
    const __handleSearch = (event) => {  
        setLoading(true);   
        setSearch(event.target.value);
    };

//DELETE
const __handleDelete = (event) => {  
    sweetConfirm("?", "Delete !", "Are you sure to delete ?")
    .then(confirmed => {
       
        if(confirmed.isConfirmed){
            axios.get("https://localhost:44345/api/player/delete/"+ event.target.id, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{
                
                if(resp.data){
                    setTrigger(false);                            
                    CustomAlert("success", "Done", "Successfully admin deleted.");
                } 
                else{
                    CustomAlert( "info", "Ops", "Something went wrong.");
                }              
                
            }).catch(err=>{
                
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
                    <h2>Total Players</h2>
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

                {isLoading ?ColorLoading()
                : 
                <table id='table-to-xls'>
                    <thead>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Position</th>
                        <th>Action</th>
                    </thead>

                    {players.length !== 0 ?
                        <tbody>
                            {players.map((players, index) => (
                                <tr key={index}>
                                <td style={{textTransform: "capitalize"}}><Link to={`/getDetails/Players/${players.Id}`}>{players.Name}</Link></td>
                                <td><span>{players.Email}</span></td>
                                <td><span>{players.Position}</span></td>                                   
                                <td>  <button className='smallBtn' id={players.Id} onClick={e => __handleDelete(e)} >Delete</button></td>                                 
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

export default Players;