import { Component, Input, OnInit } from '@angular/core';
import { DeleteUser, emptyDeleteUser, emptyUser, setUser, User } from 'src/app/models/account-management/user.model';
import { UserService } from 'src/app/services/account-management-services/user.service';

@Component({
  selector: 'app-user-delete',
  templateUrl: './user-delete.component.html',
  styleUrls: ['./user-delete.component.css']
})
export class UserDeleteComponent implements OnInit {

  currentUser:User = emptyUser();

  @Input('user')
  set user(detail:User){
    this.currentUser = setUser(detail.id,
                            detail.userName,
                            detail.emailAddress,
                            detail.createdDate,
                            detail.deletedDate);
    }
  
  constructor(private userService:UserService) { }

  ngOnInit(): void {
  }

  userDelete:DeleteUser = emptyDeleteUser();

  deleteUser() {
    this.userDelete.id = this.currentUser.id;
    
    this.userService.deleteUser(this.userDelete)
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

