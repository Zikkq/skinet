import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { Constants } from './core/constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';

  constructor(private basketService: BasketService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  private loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe({next: () => console.log('loaded user'), error: error => console.log(error)});
  }

  private loadBasket() {
    const basketId = localStorage.getItem(Constants.basketId);
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe({
        next: () => console.log('initialised basket'),
        error: error => console.log(error)
      });
    }
  }
}
