import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EcommerceServiceService, customer_detail } from '../ecommerce-service.service';


@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent {

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

  constructor(private homeservice: EcommerceServiceService,
    private dialogref: MatDialogRef<AddCustomerComponent>,
    private router: Router) { }

    onSubmit()
    {
      this.customer_detail.customerEmail = this.customeremail;
      this.customer_detail.customerName = this.customername;
      this.customer_detail.customerMobileNo = this.customermobileno;
      this.customer_detail.customerAddressLine1 = this.customerAdd1;
      this.customer_detail.customerAddressLine2 = this.customerAdd2;
      this.customer_detail.customerCity = this.customercity;

      this.homeservice.addCustomer(this.customer_detail).subscribe(data => {
        console.log(data);
      })

      this.router.navigateByUrl('', {skipLocationChange: false}).then(() => {
        this.router.navigate(['home'])
      })

      this.dialogref.close();
    }
}
