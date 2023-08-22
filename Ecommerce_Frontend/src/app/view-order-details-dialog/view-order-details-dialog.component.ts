import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EcommerceServiceService, orderitem, product } from '../ecommerce-service.service';


@Component({
  selector: 'app-view-order-details-dialog',
  templateUrl: './view-order-details-dialog.component.html',
  styleUrls: ['./view-order-details-dialog.component.css']
})


export class ViewOrderDetailsDialogComponent implements OnInit {
  
  orderItem!: orderitem;
  product!: product;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private dialogref: MatDialogRef<ViewOrderDetailsDialogComponent>,
  private ecomservice: EcommerceServiceService,
  private router: Router) { }
  
  
  ngOnInit(): void {
    this.ecomservice.getorderitembyOrderID(this.data).subscribe(res => {
      console.log(res);

      this.orderItem = res;

      this.ecomservice.getproductbyID(res.productId).subscribe(pro => {
        console.log(pro);
        
        this.product = pro;
      })
    })
  }

  deleteOrder(id: number){
    this.ecomservice.deleteOrder(id).subscribe(data => {
      console.log(data);
    })

    this.dialogref.close();

    this.router.navigate(['home']);
  }
}
