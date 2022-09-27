import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';
import { catchError,map,tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../../models/account-management/user.model';
import { Response } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseApiUrl: string = environment.baseApiUrl;
  
  constructor(private http: HttpClient) { }

  // get user list
  getUsers(): Observable<Response>{
    return this.http.get<Response>(this.baseApiUrl+"api/User/GetUsers");
  }

  // get an user
  getUser(id?:number): Observable<Response>{
    return this.http.get<Response>(this.baseApiUrl + "api/User/GetUserById?id="+id);
  }
  // add user

  // edit user

  // delete user
}
