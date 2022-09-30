import { Component, OnInit } from '@angular/core';
import { AddUser, emptyAddUser, emptyUser, User } from '../../models/account-management/user.model';
import { UserService } from '../../services/account-management-services/user.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

  newUser:AddUser = emptyAddUser();
  user:User = emptyUser();

  constructor(private userService:UserService) { }

  ngOnInit(): void {
  }

  addUser(){
    this.newUser.userName = (<HTMLInputElement>document.getElementById("add-user-name")).value;
    this.newUser.emailAddress = (<HTMLInputElement>document.getElementById("add-user-email")).value;
    this.userService.addUser(this.newUser)
    .subscribe({
      next:(user) => {
        console.log(user.result[0]);
        this.user = user.result[0];
        this.notifyForChange(null);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

  notifyForChange(message:null){
    this.userService.refreshUserList(message);
  }
}
