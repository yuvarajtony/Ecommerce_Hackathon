import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EcommerceServiceService, product } from '../ecommerce-service.service';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

  product: product = {
    productId: 0,
    productName: '',
    price: ''
  }

  productname: string;
  price: string;

  constructor(private service: EcommerceServiceService,
    private dialogref: MatDialogRef<AddProductComponent>,
    private router: Router) { }

  onSubmit() {
    this.product.productId = 0;
    this.product.productName = this.productname;
    this.product.price = this.price;

    this.service.addproduct(this.product).subscribe(data => {
      console.log(data);
    })

    this.router.navigateByUrl('', { skipLocationChange: false }).then(() => {
      this.router.navigate(['book-order'])
    })

    this.dialogref.close();
  }
}
