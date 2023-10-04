import '../Ecom/playerStyle.css';
import { useNavigate } from 'react-router-dom';
function PlayerHome(){

    const navigate = useNavigate();
    
    return(<div class="banner">
    <div class="navbar">
        <div class="logo">
            <a href="HomePage.html">
            <img src="Images/logo.png" alt="logo" />
            </a>
        </div>
        <div class="menu">
        <button type="button" className="logIn" id="signUp" >Notice</button>
                <button type="button" className="logIn" id="signUp" onClick={()=> navigate("/playerprofile")}>Profile</button>
				<button type="button" className="logIn" id="signUp" onClick={()=> navigate("/")}>Logout</button>
        </div>
    </div>
    
    <div class="slogan">
        <h1>Welcome <br/>
        Player</h1>
        <br/>
        <p>
        See What you have
        <br/> <a href="announce.html">Missed!</a></p>
      </div>
    
    </div>)  
}

export default PlayerHome;