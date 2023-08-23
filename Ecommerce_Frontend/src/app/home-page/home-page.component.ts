import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EcommerceServiceService, customer_detail } from '../ecommerce-service.service';
import { AddCustomerComponent } from '../add-customer/add-customer.component';
import { EditCustomerComponent } from '../edit-customer/edit-customer.component';


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit{

  dataSource: any;

  customer_details!: customer_detail[];

  constructor(public router: Router,
    private homeservice: EcommerceServiceService,
    private addcus_dialog: MatDialog,
    private edit_dialog: MatDialog
    ) { }

  ngOnInit() {
    this.homeservice.getallCustomers().subscribe(data => {
      this.customer_details = data;
      // console.log(data);

      this.dataSource = new MatTableDataSource(this.customer_details);
    })
  }

  openAddCus() {
    this.addcus_dialog.open(AddCustomerComponent);
  }

  openEditCusDialog(id: string)
  {
    const dRef = this.edit_dialog.open(EditCustomerComponent, {
      data: id
    });
  }

  viewOrdersdialog(id: string)
  {
    const customer_id = id;
    localStorage.setItem('cus_id', id);
    this.router.navigate(['view-order']);
  }

  bookOrdersdialog(id: string) 
  {
    const customer_id = id;
    localStorage.setItem('cus_id', id);
    this.router.navigate(['book-order']);
  }



  displayedColumns: string[] = ['slno', 'Name', 'Email', 'Contact no', 'Address', 'Edit-btn', 'view-orders-btn', 'book-orders-btn'];
}
