import { Component, OnInit,Input } from '@angular/core';
import { EditUser, emptyEditUser, emptyUser,setUser, User } from 'src/app/models/account-management/user.model';
import { UserService } from 'src/app/services/account-management-services/user.service';

@Component({
  selector: 'app-user-edit-details',
  templateUrl: './user-edit-details.component.html',
  styleUrls: ['./user-edit-details.component.css']
})
export class UserEditDetailsComponent implements OnInit {

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

  userEditName: any;
  userEditEmailAddress: any;
  userEditId: any;
  userEdit: EditUser = emptyEditUser();
  

  editUser(){
    this.userEditName = (<HTMLInputElement>document.getElementById("edit-user-name")).value;
    this.userEditEmailAddress = (<HTMLInputElement>document.getElementById("edit-user-email")).value;
    this.userEditId = this.currentUser.id;
    this.userEdit = setUser(this.userEditId,
      this.userEditName,
      this.userEditEmailAddress,
      this.currentUser.createdDate,
      this.currentUser.deletedDate);

    console.log(this.userEdit);

    this.userService.editUser(this.userEdit)
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


