import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent implements OnInit {
  @Input() subtotal: number;
  @Input() shipping: number;
  @Input() total: number;

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
  }

}
