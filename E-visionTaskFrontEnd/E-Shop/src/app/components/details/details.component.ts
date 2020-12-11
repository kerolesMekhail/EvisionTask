import { Component, OnInit } from '@angular/core';
import {CommonServiceService} from '../../Services/common-service.service';
import { NgForm, FormsModule, FormControl, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
public id='';
public name='';
public price='';
  constructor(private common : CommonServiceService , private fb: FormBuilder,private route: ActivatedRoute, private router: Router) { 

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let product_id = params.get('id');
      if(product_id !='' && product_id !=null){
       this.id=product_id;
        console.log("product_id",product_id)
        this.getOneProductDetails(product_id);
  }
});
  }
  getOneProductDetails( product_id) {
  
 
    this.common.getOneProductById(product_id)
      .subscribe(
        (data) => {
        
          if(data){
            this.id=data.id;
            this.name=data.name;
            this.price=data.price;
             console.log("product",data)
          }
          
        }
  
      )
  }

  
}
