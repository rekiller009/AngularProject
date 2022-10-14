import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit {
  numbers:number[];
  constructor() {
    this.numbers = Array(6).fill(0).map((x,i) => i);
  }
  ngOnInit(): void {
  }

}
