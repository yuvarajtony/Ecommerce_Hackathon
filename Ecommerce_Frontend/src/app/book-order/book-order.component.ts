import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EcommerceServiceService, product } from '../ecommerce-service.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { BookOrderDialogboxComponent } from '../book-order-dialogbox/book-order-dialogbox.component';
import { AddProductComponent } from '../add-product/add-product.component';


@Component({
  selector: 'app-book-order',
  templateUrl: './book-order.component.html',
  styleUrls: ['./book-order.component.css']
})
export class BookOrderComponent implements OnInit{

  products!: product[];

  constructor (public router: Router,
    private ecomservice: EcommerceServiceService,
    private bookord: MatDialog,
    private addprod: MatDialog) {
  }

  ngOnInit(): void {
    // console.log(this.received_data);
    this.getProducts();
  }

  addproduct(){
    this.addprod.open(AddProductComponent);
  }

  getProducts()
  {
    this.ecomservice.getproducts().subscribe(data => {
      this.products = data;
      
      // console.log(data);
    })
  }

  bookOrder(id: number)
  {
    // console.log(id);
    const cusemail = localStorage.getItem('cus_id');
    
    // console.log(this.received_data);
    console.log("cus email: " + cusemail);
    
    const dRef = this.bookord.open(BookOrderDialogboxComponent, {
      data: { id, cusemail },
    })    
  }

  back()
  {
    this.router.navigate(['home']);
  }
}
