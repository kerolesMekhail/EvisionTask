import { Injectable } from '@angular/core';
import { HttpClient,HttpInterceptor } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommonServiceService {
public _hostName= "https://localhost:44381";
public public_url="/api/Product/GetAllProduct";
public public_url2="/api/Product/GetAllProductByOne";
public public_url3="/api/Product/PostProduct";
public public_url4="/api/Product/SearchProduct";
public public_url5="/api/Product/PutProduct";
public public_url6="/api/Product/SoftDeleteProduct";
constructor(private http: HttpClient) {

   }
   
  GetALLProduct(){
    return this.http.get<any>(this._hostName + this.public_url)
}


  getOneProductById(ProductId: string) {  
    console.log('ProductId to server',ProductId);
    return this.http.get<any>(this._hostName + this.public_url2 +'?id='+ProductId);  
  }  
  SearchProduct(search: string,searchdate:string) {  
    return this.http.get<any>(this._hostName + this.public_url4 +'?Name='+search+'&ModifiedDT='+searchdate);  
  }  
  addApplicant(data){
    console.log("data go to server",data);

    return this.http.post<any>(this._hostName + this.public_url3 , data);
  }
  deleteProduct(data){
    
    return this.http.post<any>(this._hostName + this.public_url6 , data);
  }

  edit_product(data){
    console.log("data go to server",data);

    return this.http.post<any>(this._hostName + this.public_url5 , data);
  }

}

    
 