import axios from 'axios';
import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import 'bootstrap/dist/css/bootstrap.css';
import './Registration.css'
import {Loading, LoadingClose, CustomAlert} from "../../../components/Alert"; 

function Registration() {
    const navigate = useNavigate();
    const { register, handleSubmit, formState: { errors } } = useForm();
    document.title = "New Account";

   

    const onSubmit = (data) => {
       
        var new_data = {Name:data.name, Email: data.email, Password: data.password,
         phone: data.phone, dob: data.dob};
        Loading();
        axios.post("https://localhost:44345/api/user/insert",new_data)
            .then(resp=>{  
                LoadingClose();   
                console.log(resp, "resp");
                if(resp.data){
                    CustomAlert("success", "Registered", "New player added successfully");
                  navigate("/");
                  
                }
            }).catch(err=>{
                LoadingClose();
                CustomAlert("error", "Error !", "Try again");
                console.log("Failed ", err);
            });

       
      }
  
    return(
        <form className='form' id='regForm' autoComplete='off' onSubmit={handleSubmit(onSubmit)}>
            <div className="form-body">
                <div className="name">
                    <label className="form__label" >Name </label>
                    <input className="form__input" type="text" placeholder="Enter Name" {...register("name", { required: true, minLength: 5 })}/>
                    {errors.name && <p>Min :5</p>}
                </div>
                
                <div className="email">
                    
                    <label className="form__label" >Email </label>
                    <input  type="text"  className="form__input" placeholder="Email" {...register("email", 
                        { 
                            required: true,
                            // eslint-disable-next-line  
                            pattern: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{3,}))$/ 
                        })}
                    />
                    {errors.email && <p>Enter Valid Email</p>}
                </div>
                <div className="password">
                    <label className="form__label" >Password </label>
                    <input className="form__input" type="password" placeholder="Password" {...register("password", { 
                            required: true, 
                            pattern: /^(?=.*\d)(?=.*[a-z]).{5,15}$/
                        })}
                    />
                    {errors.password && <p>minimum 5, letter and digit must</p>}
                </div>
            </div>
            <div className="footer">
                <button  type="submit" className="btn">Register</button>
                <button type="button" className="btn" id='btnn' onClick={() => navigate(-1)}>Login</button>
            </div>
        </form>
       
    )       
}

export default Registration;