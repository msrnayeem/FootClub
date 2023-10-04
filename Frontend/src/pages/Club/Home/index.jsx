
import * as React from 'react';

import "react-datepicker/dist/react-datepicker.css";


import DashboardHeader from '../../../components/DashboardHeader';
import SideBar from '../../../components/Sidebar';
import sidebar_menu from '../../../constants/sidebar-menu';


function Home () {
    document.title="Homepage";
    

    //CUStOMER
   
        
    
   
    return(
        <div className='dashboard-container'>
        <SideBar menu={sidebar_menu} />
        
        <div className='dashboard-content'>
            <DashboardHeader btnText="Dashboard"/>
            <div className='booking-content-container' >
            
            
                
            </div>
        </div>
        
        </div>
    )
}

export default Home;