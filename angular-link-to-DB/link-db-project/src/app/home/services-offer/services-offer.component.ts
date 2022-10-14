import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-services-offer',
  templateUrl: './services-offer.component.html',
  styleUrls: ['./services-offer.component.css']
})
export class ServicesOfferComponent implements OnInit {

  numbers:number[];
  constructor() {
    this.numbers = Array(5).fill(0).map((x,i) => i);
  }

  ngOnInit(): void {
  }

}
