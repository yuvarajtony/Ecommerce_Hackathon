import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EcommerceServiceService, customer_detail } from '../ecommerce-service.service';


@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent  implements OnInit{
  
  customer_detail: customer_detail = {
    customerEmail: '',
    customerName: '',
    customerMobileNo: '',
    customerAddressLine1: '',
    customerAddressLine2: '',
    customerCity: ''
  }

  customeremail: string;
  customername: string;
  customermobileno: string;
  customerAdd1: string;
  customerAdd2: string;
  customercity: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, 
  private dialogref: MatDialogRef<EditCustomerComponent>,
  private homeservice: EcommerceServiceService,
  private router: Router) {}


  ngOnInit(): void {
    this.getcustomerbyID(this.data)
  }

  getcustomerbyID(id: string)
  {
    this.homeservice.getcustomerbyID(id).subscribe(res => {
      this.customeremail = res.customerEmail;
      this.customername = res.customerName;
      this.customermobileno = res.customerMobileNo;
      this.customerAdd1 = res.customerAddressLine1;
      this.customerAdd2 = res.customerAddressLine2;
      this.customercity = res.customerCity;
    })
  }

  onSubmit() {
      this.customer_detail.customerEmail = this.customeremail;
      this.customer_detail.customerName = this.customername;
      this.customer_detail.customerMobileNo = this.customermobileno;
      this.customer_detail.customerAddressLine1 = this.customerAdd1;
      this.customer_detail.customerAddressLine2 = this.customerAdd2;
      this.customer_detail.customerCity = this.customercity;

      this.homeservice.editCustomer(this.customer_detail).subscribe(data => {
        console.log(data);
      })

      this.router.navigateByUrl('', {skipLocationChange: false}).then(() => {
        this.router.navigate(['home'])
      })

      this.dialogref.close();
  }
}
