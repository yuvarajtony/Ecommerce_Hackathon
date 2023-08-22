import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EcommerceServiceService, product } from '../ecommerce-service.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { BookOrderDialogboxComponent } from '../book-order-dialogbox/book-order-dialogbox.component';


@Component({
  selector: 'app-book-order',
  templateUrl: './book-order.component.html',
  styleUrls: ['./book-order.component.css']
})
export class BookOrderComponent implements OnInit{

  received_data: any;

  products!: product[];

  constructor (public router: Router,
    private ecomservice: EcommerceServiceService,
    private bookord: MatDialog) {
      this.received_data = ecomservice.getData();
  }

  ngOnInit(): void {
    // console.log(this.received_data);
    this.getProducts();
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
    const cusemail = this.received_data;
    
    // console.log(this.received_data);
    // console.log(cusemail);
    
    const dRef = this.bookord.open(BookOrderDialogboxComponent, {
      data: { id, cusemail },
    })    
  }

  back()
  {
    this.router.navigate(['home']);
  }
}
