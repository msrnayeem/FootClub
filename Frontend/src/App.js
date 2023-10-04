import React from 'react';
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import PrivateRoute from './components/Hook/PrivateRoute';

import Reset from './pages/Club/Reset';
import Otp from './pages/Club/Otp';
import NewPassword from './pages/Club/NewPassword';

import Registration from './pages/Club/Registration';
import PlayerReg from './../src/pages/Club/PlayerReg.jsx'
import Login from './pages/Common/Login';
import Home from './pages/Club/Home';
import Profile from './pages/Club/Profile';
import Players from './pages/Club/Players';
import Admin from './pages/Club/Admin';


import PlayerHome from './pages/Ecom/PlayerHome';
import PlayerProfile from './pages/Player/playerProfile';
import Landing from './pages/Common/Landing';
import ProductHome from './pages/Ecom/ProductHome.jsx'

import Customers from './pages/Ecom/Customers/index.jsx';
import CustomerReg from './pages/Ecom/Customers/CustomerReg.jsx';
import Orders from './pages/Ecom/Orders/index';

import Rooms from './pages/Club/Rooms';
import Details from './pages/Club/Details';
import DetailsEdit from './pages/Club/DetailsEdit';

import Error from './pages/Club/Error';

function App () {
 
  return(
    
    <Router>  

              <Routes>        
                <Route exact path="/reset" element={< Reset/>} />
                <Route exact path="/otp" element={< Otp/>} />
                <Route exact path="/newPassword" element={< NewPassword/>} />

                <Route exact path="/Registration" element={< Registration/>} />
                <Route exact path="/addplayer" element={< PlayerReg/>} />
                
                <Route exact path="/" element={< Landing/>} />
                <Route path="/login" element={< Login/>} />
                <Route exact path="/adminhome" element={< Home/>} />
                <Route exact path="/playerhome" element={< PlayerHome/>} />
                <Route exact path="/playerprofile" element={< PlayerProfile/>} />
                <Route exact path="/products" element={< ProductHome/>} />
                <Route exact path="/orders" element={< Orders/>} />
                <Route exact path="/profile" element=
                  {
                    <PrivateRoute> 
                      < Profile/> 
                    </PrivateRoute>
                  } 
                />
                <Route exact path="/players" element={< Players/>} />
                <Route exact path="/customers" element={< Customers/>} />
                <Route exact path="/customerreg" element={< CustomerReg/>} />
                <Route exact path="/admins" element={< Admin/>} />
                <Route exact path="/Rooms" element={< Rooms/>} />

                
                <Route exact path="/getDetails/:table_name/:idd" element={< Details/>} />
                <Route exact path="/update/:table_name/:idd" element={< DetailsEdit/>} />

                <Route path="/*" element={< Error/>}/>   
                {/*import Navigate <Route path="/*" element={< Navigate to="/" />} /> */}   
              </Routes>         
    </Router>
  )
}

export default App;