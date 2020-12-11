import { Component ,OnInit} from '@angular/core';
import {CommonServiceService} from '../../Services/common-service.service'
@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  all_product:any[]=[];
  pathurl = "";
  search='';
  searchdate='';
  id='';
constructor (private common : CommonServiceService)
{
  this.pathurl=this.common._hostName+'Images'+"/";
}

  ngOnInit(): void {
    this.getAllProduct()
  }

  getAllProduct() {
     this.common.GetALLProduct()
       .subscribe(
         (data) => {
          
            console.log("a",data);
            this.all_product=data;

         }
 
       )
   }


  
   deletProduct(id){

    let formData = new FormData(); 
    formData.append('active','false');
    formData.append('id',id);

   
    this.common.deleteProduct(formData).subscribe((data) => {
      if (data) {
       console.log("delet sucss",data)

       this.getAllProduct();

      } else {
        return;
      }
    });


   }

   searchform(){
     console.log("search",this.search)

     this.common.SearchProduct(this.search,this.searchdate)
     .subscribe(
       (data) => {
        
          console.log("search",data);
          
          this.all_product=data;
       }

     )

   }

   GetOneProduct(){
     this.common.getOneProductById(this.id).subscribe((data) => {
      this.all_product=data;
    })
   }

}
