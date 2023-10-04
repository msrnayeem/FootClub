import React, {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';
import { Link } from 'react-router-dom';
import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';
import {ColorLoading} from '../../../components/Alert';




import axios from 'axios';

function Details () {
    const [details, setDetails] = useState('');
    let { idd } = useParams();
    let {table_name} = useParams();
    const [isLoading, setLoading] = useState(true);

    document.title = "Details-"+details.name;

    useEffect(() => {
        setLoading(true);
        var token = localStorage.getItem('token');
        var respData = JSON.parse(token);

        if(table_name === "Admins"){
            axios.get("https://localhost:44345/api/user/"+idd, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{               
                setDetails(resp.data);
                setLoading(false);
            }).catch(err=>{
                setLoading(false);
                console.log(err);
            });
        } else if (table_name === "Players"){
            axios.get("https://localhost:44345/api/player/"+idd, {
                headers: {
                  Authorization: respData
                }
              })
            .then(resp=>{    
                        
                setDetails(resp.data);
                setLoading(false);
            }).catch(err=>{
                setLoading(false);
                console.log(err);
            });
        }
        else{
            axios.get("https://localhost:44345/api/customers/"+idd)
            .then(resp=>{    
                          
                setDetails(resp.data);
                setLoading(false);
            }).catch(err=>{
                setLoading(false);
                console.log(err);
            });
        }
            
        
       
    }, [idd, table_name]); 

  
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
                                        <span style={{ textTransform: "capitalize" }} className="font-weight-bold"> {details.Name}</span>
                                        <b className="text-black-50" style={{ textTransform: "capitalize" }}>{ table_name }</b>
                                    </div>
                    </div>
                    <div className="col-md-5 border-right">
                        <div className="p-3 py-5">
                            <div className="d-flex justify-content-between align-items-center mb-3">
                                <h4 className="text-right">Details</h4>
                            </div>
                            <div className="row mt-2">
                                <div className="col-md-12">
                                    <label className="labels">Name</label>
                                                <input type="text" className="form-control" style={{ textTransform: "capitalize" }} value={details.Name} disabled={true} />
                                </div>
                                
                            </div>
                          
                                <div className="col-md-12">
                                    <label className="labels">Email</label>
                                                <input type="text" className="form-control" value={details.Email} disabled={true} />
                                </div> 
                            </div>
                            {table_name !== "Players" ? (
                                            <>
                                            
                                            </>
                                            ) : (
                                            <>
                                            <div className="col-md-12">
                                                <label className="labels">Date of birth</label>
                                                <input type="text" className="form-control" value={details.Dob.split("T")[0]} disabled={true} />
                                            </div> 
                                            <div className="col-md-12">
                                                <label className="labels">Height</label>
                                                <input type="text" className="form-control" value={details.Height} disabled={true} />
                                            </div>
                                            <div className="col-md-12">
                                                <label className="labels">Position</label>
                                                <input type="text" className="form-control" value={details.Position} disabled={true} />
                                            </div>
                                            <div className="col-md-12">
                                                <label className="labels">Salary</label>
                                                <input type="text" className="form-control" value={details.Salary} disabled={true} />
                                            </div>
                                            <div className="col-md-12">
                                                <label className="labels">Price</label>
                                                <input type="text" className="form-control" value={details.Price} disabled={true} />
                                            </div>
                                            </>
                                            )}
                            <div className="col-md-3">
                                <Link to={`/update/${ table_name }/${idd}`} className="btn btn-primary">Update</Link>
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

export default Details;