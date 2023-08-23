import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EcommerceServiceService, order, orderitem, product} from '../ecommerce-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ViewOrderDetailsDialogComponent } from '../view-order-details-dialog/view-order-details-dialog.component';


@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.css']
})
export class ViewOrderComponent implements OnInit{
  
  received_data: any;

  orders!: order[];

  constructor (public router: Router,
    private ecomservice: EcommerceServiceService,
    private vieworddialog: MatDialog) {
  }

  ngOnInit(): void {

    this.received_data = localStorage.getItem('cus_id');
    
    this.ecomservice.getorderbyCustomer(this.received_data).subscribe(data => {
      // console.log(data);

      this.orders = data;
      
    })
    // console.log(this.received_data);
  }

  viewOrderdDetail(id: number){
    const dRef = this.vieworddialog.open(ViewOrderDetailsDialogComponent, {
      data: id
    });
  }

  back()
  {
    this.router.navigate(['home']);
  }
}
