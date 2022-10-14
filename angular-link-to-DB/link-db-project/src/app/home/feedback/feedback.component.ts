import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  numbers:number[];
  constructor() {
    this.numbers = Array(3).fill(0).map((x,i) => i);
  }

  ngOnInit(): void {
  }

}
