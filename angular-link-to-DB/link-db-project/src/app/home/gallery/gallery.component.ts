import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  numbers:number[];
  constructor() {
    this.numbers = Array(5).fill(0).map((x,i) => i);
  }

  ngOnInit(): void {
  }

}
