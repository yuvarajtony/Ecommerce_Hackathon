import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EcommerceServiceService} from '../ecommerce-service.service';


@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.css']
})
export class ViewOrderComponent implements OnInit{
  
  received_data: any;

  constructor (public router: Router,
    private ecomservice: EcommerceServiceService) {
      this.received_data = ecomservice.getData();
  }

  ngOnInit(): void {
    console.log(this.received_data);
  }
}
