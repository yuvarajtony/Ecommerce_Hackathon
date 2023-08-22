import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EcommerceServiceService, order, orderitem } from '../ecommerce-service.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookOrderComponent } from '../book-order/book-order.component';

@Component({
  selector: 'app-book-order-dialogbox',
  templateUrl: './book-order-dialogbox.component.html',
  styleUrls: ['./book-order-dialogbox.component.css']
})
export class BookOrderDialogboxComponent implements OnInit {

  quantity: number;

  productid: number;
  customeremail: string;

  order: order = {
    orderId: 0,
    customerEmail: '',
    orderDate: '',
    deliveryDate: '',
    shipmentCity: '',
    shipmentStatus: 0
  }

  orderitem: orderitem = {
    orderItemId: 0,
    orderId: 0,
    productId: 0,
    quantity: 0,
    unitPrice: '',
    totalPrice: ''
  }

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogref: MatDialogRef<BookOrderDialogboxComponent>,
    private ecomservice: EcommerceServiceService,
    private router: Router,
    private snackbar: MatSnackBar) {
    this.productid = data.id
    this.customeremail = data.cusemail
  }

  ngOnInit(): void {
    // console.log("Product id: " + this.productid);
    // console.log("CustomerEmail: " + this.customeremail);
  }


  async Confirm() {
    this.ecomservice.getcustomerbyID(this.customeremail).subscribe(cus => {
      console.log(cus.customerCity);

      const todaydate = new Date();
      console.log("Today date: " + todaydate.toLocaleDateString());

      const deliverydate = new Date();
      deliverydate.setDate(deliverydate.getDate() + 4);
      console.log("Delivery date: " + deliverydate.toLocaleDateString());

      this.order.orderId = 0;
      this.order.customerEmail = this.customeremail;
      this.order.orderDate = todaydate.toLocaleDateString();
      this.order.deliveryDate = deliverydate.toLocaleDateString();
      this.order.shipmentCity = cus.customerCity;
      this.order.shipmentStatus = 0;

      this.ecomservice.addOrder(this.order).subscribe(res => {
        console.log(res);
      })
    })

    await new Promise(resolve => setTimeout(resolve, 2500)); 

    this.ecomservice.getproductbyID(this.productid).subscribe(product => {

      this.ecomservice.getorders().subscribe(ord => {
        const lastvalue = ord[ord.length - 1];

        console.log(lastvalue.orderId);
        
        this.orderitem.orderItemId = 0;
        this.orderitem.orderId = lastvalue.orderId;
        this.orderitem.productId = this.productid;
        this.orderitem.quantity = this.quantity;
        this.orderitem.unitPrice = product.price;
        this.orderitem.totalPrice = String(Number(product.price) * this.quantity);

        this.ecomservice.addorderitem(this.orderitem).subscribe(ans => {
          console.log(ans);
        })
      })
    })

    // console.log("Quantity: " + this.quantity);

    this.snackbar.open('Order Placed', 'Sucessfully', {
      duration: 3000
    })

    this.dialogref.close();
  }
}
