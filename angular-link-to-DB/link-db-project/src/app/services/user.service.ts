import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError,map,tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User, UserList } from '../models/user-list.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseApiUrl: string = environment.baseApiUrl;
  
  constructor(private http: HttpClient) { }

  // get user list
  getUsers(): Observable<UserList>{
    return this.http.get<UserList>(this.baseApiUrl+"api/User/GetUsers");
  }

  // get an user

  // add user

  // edit user

  // delete user
}
