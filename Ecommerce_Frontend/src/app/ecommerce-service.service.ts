import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface customer_detail {
  customerEmail: string,
  customerName: string,
  customerMobileNo: string,
  customerAddressLine1: string,
  customerAddressLine2: string,
  customerCity: string
}

export interface product {
  productId: number,
  productName: string,
  price: string
}

export interface order {
  orderId: number,
  customerEmail: string,
  orderDate: string,
  deliveryDate: string,
  shipmentCity: string,
  shipmentStatus: number
}

export interface orderitem {
  orderItemId: number,
  orderId: number,
  productId: number,
  quantity: number,
  unitPrice: string,
  totalPrice: string
}


@Injectable({
  providedIn: 'root'
})
export class EcommerceServiceService {

  private Customer_Email_ID: string;

  setData(data: string) {
    this.Customer_Email_ID = data;
  }

  getData() {
    return this.Customer_Email_ID;
  }

  customer_detail: customer_detail = {
    customerEmail: '',
    customerName: '',
    customerMobileNo: '',
    customerAddressLine1: '',
    customerAddressLine2: '',
    customerCity: ''
  }

  product: product = {
    productId: 0,
    productName: '',
    price: ''
  }

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

  constructor(private httpclient: HttpClient) { }

  // customer

  getallCustomers(): Observable<customer_detail[]> {
    return this.httpclient.get<customer_detail[]>("https://localhost:7243/api/CustomerDetail/GetCustomers");
  }

  addCustomer(customer: any) {
    this.customer_detail.customerEmail = customer.customerEmail;
    this.customer_detail.customerName = customer.customerName;
    this.customer_detail.customerMobileNo = customer.customerMobileNo;
    this.customer_detail.customerAddressLine1 = customer.customerAddressLine1;
    this.customer_detail.customerAddressLine2 = customer.customerAddressLine2;
    this.customer_detail.customerCity = customer.customerCity;

    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(this.customer_detail);

    return this.httpclient.post('https://localhost:7243/api/CustomerDetail/AddCustomer', body, { headers: headers })
  }

  getcustomerbyID(id: string): Observable<customer_detail> {
    return this.httpclient.get<customer_detail>(`https://localhost:7243/api/CustomerDetail/GetCustomerbyID/${id}`);
  }

  editCustomer(customer: any) {
    this.customer_detail.customerEmail = customer.customerEmail;
    this.customer_detail.customerName = customer.customerName;
    this.customer_detail.customerMobileNo = customer.customerMobileNo;
    this.customer_detail.customerAddressLine1 = customer.customerAddressLine1;
    this.customer_detail.customerAddressLine2 = customer.customerAddressLine2;
    this.customer_detail.customerCity = customer.customerCity;

    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(this.customer_detail);

    return this.httpclient.put('https://localhost:7243/api/CustomerDetail/UpdateCustomer', body, { headers: headers })
  }


  // product

  getproducts(): Observable<product[]> {
    return this.httpclient.get<product[]>("https://localhost:7243/api/Product/GetProduct");
  }

  getproductbyID(id: number): Observable<product> {
    return this.httpclient.get<product>(`https://localhost:7243/api/Product/GetProductbyID/${id}`);
  }


  // order

  getorders(): Observable<order[]> {
    return this.httpclient.get<order[]>("https://localhost:7243/api/Order/GetOrder");
  }

  getorderbyID(id: number): Observable<order> {
    return this.httpclient.get<order>(`https://localhost:7243/api/Order/GetorderbyID/${id}`);
  }

  getorderbyCustomer(id: string): Observable<order[]> {
    return this.httpclient.get<order[]>(`https://localhost:7243/api/Order/GetOrderbyCustomer/${id}`);
  }

  addOrder(ord: any)
  {
    this.order.orderId = ord.orderId;
    this.order.customerEmail = ord.customerEmail;
    this.order.orderDate = ord.orderDate;
    this.order.deliveryDate = ord.deliveryDate;
    this.order.shipmentCity = ord.shipmentCity;
    this.order.shipmentStatus = ord.shipmentStatus;

    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(this.order);

    return this.httpclient.post("https://localhost:7243/api/Order/AddOrder", body, { headers: headers });
  }

  deleteOrder(id: number) {
    return this.httpclient.delete(`https://localhost:7243/api/Order/DeleteOrder/${id}`);
  }


  // order item

  getOrderitem(): Observable<orderitem[]> {
    return this.httpclient.get<orderitem[]>("https://localhost:7243/api/OrderItem/GetOrderItem");
  }

  getOrderitembyID(id: number): Observable<orderitem> {
    return this.httpclient.get<orderitem>(`https://localhost:7243/api/OrderItem/GetOrderItembyID/${id}`);
  }

  addorderitem(orditm: any)
  {
    this.orderitem.orderItemId = orditm.orderItemId;
    this.orderitem.orderId = orditm.orderId;
    this.orderitem.productId = orditm.productId;
    this.orderitem.quantity = orditm.quantity;
    this.orderitem.unitPrice = orditm.unitPrice;
    this.orderitem.totalPrice = orditm.totalPrice;

    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(this.orderitem);

    return this.httpclient.post("https://localhost:7243/api/OrderItem/AddOderItems", body, { headers: headers });
  }
}
