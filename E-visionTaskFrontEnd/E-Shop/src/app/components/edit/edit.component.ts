import { Component, OnInit } from '@angular/core';
import {CommonServiceService} from '../../Services/common-service.service';
import { NgForm, FormsModule, FormControl, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  addApplicantForm: FormGroup;
  public name='';
  public price='';
  public photo:any;
  public id=''

  file:any;
  selectedFile: any = null;
  constructor(private common : CommonServiceService , private fb: FormBuilder,private route: ActivatedRoute, private router: Router) { 
    this.addApplicantForm = fb.group({
      'id': [null, Validators.required],
      'name': [null, Validators.required],
      'price': [null, Validators.required],
      'photo': [null, Validators.required],
  });
  }

  ngOnInit(): void {
    

 this.route.paramMap.subscribe((params: ParamMap) => {
      let product_id = params.get('id');
      if(product_id !='' && product_id !=null){
       this.id=product_id;
        console.log("product_id",product_id)
        this.getOneProductDetails(product_id);

      }
    
    })
  }

  
  showPreviewImage(event: any, type: string) {
    if (type === 'file') {
         this.selectedFile = event.target;
      } 
    else {
     
    }

  }

  editproduct() { 
   
    let formData = new FormData(); 
    formData.append('Name',this.name);
    formData.append('Id',this.id);
    formData.append('Price',this.price);
    formData.append('CategoryId ','1');
    formData.append('file ',this.selectedFile.files[0]);
    
    this.common.edit_product(formData).subscribe((data) => {
      if (data) {
       console.log("add sucss",data)
        this.resetValus();
      } else {
        return;
      }
    });
  }


  resetValus(){
   this.file=null;
   this.id=null;
   this.selectedFile=null;
   this.name="";
   this.price=null;
   
  
   window.scrollTo(0, 0);
   window.scrollTo(0, 0);
   window.scrollTo(0, 0);
 }


 
 getOneProductDetails( product_id) {
  
 
  this.common.getOneProductById(product_id)
    .subscribe(
      (data) => {
      
        if(data){
          
          this.name=data.name;
          this.price=data.price;
           console.log("product",data)
        }
        
      }

    )
}


}
