import {Loading, LoadingClose, CustomAlert} from "../../components/Alert";
import { useNavigate } from "react-router-dom";

import axios from "axios";

function ProductHome() {
  const navigate = useNavigate();
 

  const buyNow = () => {
    Loading();
    
    var token = localStorage.getItem('token');
    var respData = JSON.parse(token);
        axios.get("https://localhost:44345/api/profile", {
            headers: {
              Authorization: respData // Set the Authorization header with the token value
            }
          })
          .then(resp => {
            
            if (resp.data != null) {
              console.log(resp.data);
                var obj = {"CustomerId" : resp.data.Id, "Status": "processing", "Quantity" : 1, "ProductId" : 2};
                console.log(obj);
                axios.post("https://localhost:44345/api/order/insert",obj, {
                  headers: {
                    Authorization: respData // Set the Authorization header with the token value
                  }
                })
                .then(resp=>{ 
                  // console.log(resp.data.Tkey);
                      LoadingClose();
                    if(resp.data != null){
                      //navigate("/orders");
                      CustomAlert("success", "Done !", "Order placed");
                    }
                    else{
                      LoadingClose();
                      CustomAlert("error", "Error !", "Try again, failed to order");
                    }
                }).catch(err=>{
                  LoadingClose();
                    CustomAlert("error", "Error !", "Axios cunnection error");
                    console.log("Failed ", err);
                });


            }
          })
          .catch(err => {
            LoadingClose();
            if (err.response && err.response.status === 401) {
              // Unauthorized request
              CustomAlert("error", "Error !", "For customer only, login");
              navigate("/login");
            } else {
              // Other error occurred
              
              console.log(err);
            }
          });
  };

    
  return (
    <section style={{ backgroundColor: '#eee' }}>
      <div class="container py-5">
        <div class="row justify-content-center mb-3">
          <div class="col-md-12 col-xl-10">
            <div class="card shadow-0 border rounded-3">
              <div class="card-body">
                <div class="row">
                  <div class="col-md-12 col-lg-3 col-xl-3 mb-4 mb-lg-0">
                    <div class="bg-image hover-zoom ripple rounded ripple-surface">
                      <img src="https://mdbcdn.b-cdn.net/img/Photos/Horizontal/E-commerce/Products/img%20(4).webp"
                        class="w-100" alt="pl"/>
                      <a href="#!">
                        <div class="hover-overlay">
                          <div class="mask" style={{ backgroundColor: 'rgba(253, 253, 253, 0.15)' }}></div>
                        </div>
                      </a>
                    </div>
                  </div>
                  <div class="col-md-6 col-lg-6 col-xl-6">
                    <h5>Quant trident shirts</h5>
                    
                    
                    <p class="text-truncate mb-4 mb-md-0">
                      There are many variations of passages of Lorem Ipsum available, but the
                      majority have suffered alteration in some form, by injected humour, or
                      randomised words which don't look even slightly believable.
                    </p>
                  </div>
                  <div class="col-md-6 col-lg-3 col-xl-3 border-sm-start-none border-start">
                    <div class="d-flex flex-row align-items-center mb-1">
                      <h4 class="mb-1 me-1">$13.99</h4>
                      <span class="text-danger"><s>$20.99</s></span>
                    </div>
                    <h6 class="text-success">Free shipping</h6>
                    <div class="d-flex flex-column mt-4">
                      <button class="btn btn-primary btn-sm" type="button" onClick={buyNow}>Buy Now</button>
                      
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        </div>
  </section>
  );
}

export default ProductHome;