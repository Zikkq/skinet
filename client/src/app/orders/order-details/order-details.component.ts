import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  order: IOrder;

  constructor(private activatedRoute: ActivatedRoute, private ordersService: OrdersService, private bcService: BreadcrumbService) {
    this.bcService.set('@orderDetails', ' ');
   }

  ngOnInit(): void {
    this.loadOrder();
  }

  private loadOrder() {
    this.ordersService.getOrderById(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe({next: order => {
      this.order = order;
      this.bcService.set('@orderDetails', 'Order# ' + order.id + ' - ' + order.status)
    }, error: error => console.log(error)})
  }
}
