import { Component ,OnInit} from '@angular/core';
import {CommonServiceService} from './Services/common-service.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'E-Shop';
  all_product:any[]=[];
constructor (private common : CommonServiceService)
{

}

  ngOnInit(): void {
    this.getAllProduct()
  }

  getAllProduct() {
    
     this.common.GetALLProduct()
       .subscribe(
         (data) => {
           
            console.log("allCategories",data);
            this.all_product=data;

         }
 
       )
   }
}

