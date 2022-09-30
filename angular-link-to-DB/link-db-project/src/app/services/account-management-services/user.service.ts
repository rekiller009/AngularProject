import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError,map,tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AddUser, DeleteUser, EditUser, User } from '../../models/account-management/user.model';
import { Response } from '../../models/common/response.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseApiUrl: string = environment.baseApiUrl;
  SubjectNotifier: Subject<null> = new Subject<null>();
  constructor(private http: HttpClient) { }

  // get user list
  getUsers(): Observable<Response>{
    return this.http.get<Response>(this.baseApiUrl+"api/User/GetUsers");
  }

  // get an user
  getUser(id?:string): Observable<Response>{
    return this.http.get<Response>(this.baseApiUrl + "api/User/GetUserById?id="+id);
  }

  // add user
  addUser(user:AddUser):Observable<Response>{
    return this.http.post<Response>(this.baseApiUrl + "api/User/AddUser",user);
  }

  // edit user
  editUser(user:EditUser):Observable<Response>{
    return this.http.put<Response>(this.baseApiUrl + "api/User/EditUser",user);
  }

  // delete user
  deleteUser(user:DeleteUser):Observable<Response>{
    return this.http.put<Response>(this.baseApiUrl + "api/User/DeleteUser",user);
  }

  //refresh list
  refreshUserList(message: null){
    this.SubjectNotifier.next(message);
  }
}
