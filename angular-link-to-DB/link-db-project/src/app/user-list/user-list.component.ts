import { Component, OnInit } from '@angular/core';
import { User } from '../models/user-list.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: User[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.getUsers()
    .subscribe({
      next:(user) =>{
        console.log(user.result);
        this.users = user.result;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

}
