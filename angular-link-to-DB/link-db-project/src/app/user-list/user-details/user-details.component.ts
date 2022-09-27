import { Component, OnInit,Input } from '@angular/core';
import { emptyUser, User } from 'src/app/models/account-management/user.model';
import { UserService } from 'src/app/services/account-management-services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  currentUser:User = emptyUser();

  @Input('user')

  set user(detail:User){
    this.currentUser.id = detail.id,
    this.currentUser.userName = detail.userName,
    this.currentUser.emailAddress = detail.emailAddress,
    this.currentUser.createdDate = detail.createdDate,
    this.currentUser.deletedDate = detail.deletedDate
  }
  // @Input() user: User = {
  //   id: 0,
  //   userName: '',
  //   emailAddress: '',
  //   createdDate: '',
  //   deletedDate: ''
  // };
  constructor(private userService:UserService) { }

  ngOnInit(): void {
  }

}
