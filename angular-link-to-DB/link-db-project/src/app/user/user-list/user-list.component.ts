import { Component, OnInit } from '@angular/core';
import { emptyUser, User } from '../../models/account-management/user.model';
import { UserService } from '../../services/account-management-services/user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: User[] = [];
  user :User = emptyUser();
  constructor(private userService:UserService) { }

  async ngOnInit(): Promise<void> {
    await this.getUsers();
  }

  ngOnDestroy(){
    this.notifierSubscription.unsubscribe();
  }
  
  notifierSubscription: Subscription = this.userService.SubjectNotifier.subscribe(notified =>{
     this.getUsers();
  });

  getUsers():void{
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

  getUserDetails(id:string): void{
    this.userService.getUser(id)
    .subscribe({
      next:(user) => {
        console.log(user.result[0]);
        this.user = user.result[0];
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
