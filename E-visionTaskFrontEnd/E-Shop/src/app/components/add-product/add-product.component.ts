import { Component, OnInit } from '@angular/core';
import {CommonServiceService} from '../../Services/common-service.service';
import { NgForm, FormsModule, FormControl, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {



  addApplicantForm: FormGroup;
  public name='';
  public price='';
  public photo:any;

  file:any;
  selectedFile: any = null;


  constructor(private common : CommonServiceService , private fb: FormBuilder) { 
    this.addApplicantForm = fb.group({
      'name': [null, Validators.required],
      'price': [null, Validators.required],
      'photo': [null, Validators.required],
  });

  }

  ngOnInit(): void {
  }


  
  showPreviewImage(event: any, type: string) {
    if (type === 'file') {
         this.selectedFile = event.target;
      } 
    else {
     
    }

  }


  addApplicant() { 
   
      let formData = new FormData(); 
      formData.append('Name',this.name);
      formData.append('Price',this.price);
      formData.append('CategoryId ','1');
      formData.append('file ',this.selectedFile.files[0]);
      
      this.common.addApplicant(formData).subscribe((data) => {
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
   this.selectedFile=null;
   this.name="";
   this.price=null;
   
  
   window.scrollTo(0, 0);
   window.scrollTo(0, 0);
   window.scrollTo(0, 0);
 }

}
