import Logo from './../../assets/images/logo.png';
import Manage from './../../assets/images/manage.jpeg';
import financial from './../../assets/images/financial.jpeg';
import Merchant from './../../assets/images/merchant.jpeg'
import { useNavigate } from 'react-router-dom';
import  styles from './land.module.css';
function Landing(){
	const navigate = useNavigate();
return(
<>
<div className={styles.banner3}>
		<div className={styles.navbarr}>
			<div className={styles.logo}>
				<a href="HomePage.html">
				<img src={Logo} alt="plk"/>
				</a>
			</div>
			<div className={styles.menu3}>
				<button type="button" onClick={()=> navigate("/products")}>Product</button>
				<button type="button" onClick={()=> navigate("/customerreg")}>Customer</button>
				<button type="button" onClick={()=> navigate("/login")}>Login</button>
				<button type="button" onClick={()=> navigate("/Registration")}>Sign Up</button>
			</div>
		</div>

		<div className={styles.slogan}>
		  <h1>Boost your <br/>
		  football club's <br/>	
	      success with US!</h1>
	      <br/>
		  <p>
	      Take your football club to the next level with our management 
	      <br/>tools and merchant services.</p>
		</div>
	</div>

	<div className={styles.about}>
		<div className={styles.manage_img}>
			<img src={Manage} alt="manage"/>
		</div>
		<div className={styles.manage_img}>
			<h1>Manage Your Club Like A Pro</h1>
			<br/>
			<p>Our ProClubManager tool helps you manage everything from <br/>
				player recruitment to match scheduling and team <br/>
				communication. Stay organized and on top of your game.
			</p>
		</div>

		<div className={styles.merchant_img}>
			<img src={Merchant } alt="manage"/>
		</div>
		<div className={styles.merchant_msg}>
			<h1>Generate Revenue Through <br/>Merchandising</h1>
			<br/>
			<p>With GoalMerchant, you can easily create and sell custom merchandise  <br/>
				for your club. From jerseys to coffee mugs, our platform makes it easy  <br/>
				to generate revenue and increase brand awareness.
			</p>
		</div>

        <div className={styles.financial_img}>
			<img src={financial} alt="finance"/>
		</div>
		<div className={styles.financial_img}>
			<h1>Simplify Financial Management</h1>
			<br/>
			<p>Our TeamCash software streamlines financial management <br/>
			   for your club. From tracking expenses to managing player  <br/>
			   salaries, our platform takes the hassle out of financial  <br/>
			   management.
			</p>
		</div>

		<div className={styles.credits}>

			<div className={styles.logo}>
				<img src={Logo} alt="logo"/>
			</div>
	        <br/>
			<div className={styles.contacts}>
				Contact Us | Terms of Service | Privacy Policy | MyFC App (Android) | MyFC App (iOS)
			</div>
	
		</div>
       
		<div id="footer" align="center">
			<br/>
			Copyright © nayeem | 2023
		</div>
		
    </div>
</>
    
);
}

export default Landing;