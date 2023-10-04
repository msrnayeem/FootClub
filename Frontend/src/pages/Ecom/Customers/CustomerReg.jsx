import 'mdb-react-ui-kit/dist/css/mdb.min.css';
import "@fortawesome/fontawesome-free/css/all.min.css";
import {
  MDBContainer,
  MDBCard,
  MDBCardBody,
  MDBBtn,
  MDBRow,
  MDBCol
}
from 'mdb-react-ui-kit';

import axios from 'axios';
import { useNavigate } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';

import {CustomAlert} from '../../../components/Alert';

import { useForm } from "react-hook-form";

function Registration() {
    document.title = "New Account";
    const navigate = useNavigate();
    const { register, handleSubmit, formState: { errors } } = useForm();
    
 
    const onSubmit  = (e) => {
        
        const data = { "Email" : e.email, "Name": e.name, "Password": e.password, "Phone" : e.phone, "Address" : e.address }
        
        axios.post("https://localhost:44345/api/customers/insert",data)
        .then(resp=>{   
              if(resp.data){
                CustomAlert("success", "Registered", "New player added successfully");
                navigate(-1);
              }
              else{
                CustomAlert("waring", "Failed", "try again");
              }
               
        }).catch(err=>{
          // CustomAlert("warning", "API", "Axios Api error"); 
            console.log("player reg", err.data);
        });  
        
      };


  return (
    <MDBContainer fluid className='my-5'>

      <MDBRow className='g-0 align-items-center'>
        <MDBCol col='10'>

          <MDBCard className='my-10 cascading-right' style={{background: 'hsla(0, 0%, 100%, 0.55)',  backdropFilter: 'blur(30px)'}}>
            <MDBCardBody className='p-5 shadow-5 text-center'>

            <form className='form' id='regForm' autoComplete='off' onSubmit={handleSubmit(onSubmit)}>
            <div className="form-body">
                <div className="name">
                    <label className="form__label" >Name </label>
                    <input className="form__input" type="text" placeholder="Enter Name" {...register("name", { required: true, minLength: 5 })}/>
                    {errors.name && <p>Min :5</p>}
                </div>

                <div className="Email">
                    <label className="form__label" >Email </label>
                    <input className="form__input" type="text" placeholder="Email" {...register("email", { 
                            required: true, 
                            pattern: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i,
                        })}
                    />
                    {errors.email && <p>minimum 5, letter and digit must</p>}
                </div>
                <div className="password">
                    <label className="form__label" >Password </label>
                    <input className="form__input" type="text" placeholder="password" {...register("password", { 
                            required: true, 
                            pattern: /^(?=.*\d)(?=.*[a-z]).{5,15}$/
                        })}
                    />
                    {errors.password && <p>minimum 5, letter and digit must</p>}
                </div>
            
                <div className="dob">
                    <label className="form__label" >Address</label>
                    <input className="form__input" type="text" {...register("address", { required: true})}/>
                    {errors.address && <p>Required</p>}
                </div>

                
                <div className="phone">
                    <label className="form__label" >phone</label>
                    <input className="form__input" type="text" placeholder="Height" {...register("phone", { required: true, pattern: /^\d+(\.\d+)?$/ })}/>
                </div>
                {errors.phone && <p>Enter Height</p>}
                

                <div className="footer">
                <MDBBtn className='w-30 mb-4' size='md'>sign up</MDBBtn>                
                </div>
        </div>
        </form>
            </MDBCardBody>
          </MDBCard>
        </MDBCol>
      </MDBRow>

    </MDBContainer>
  );
}

export default Registration;