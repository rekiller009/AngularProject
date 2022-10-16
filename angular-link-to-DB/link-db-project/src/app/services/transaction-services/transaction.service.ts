import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  baseApiUrl: string = environment.baseApiUrl;
  SubjectNotifier: Subject<null> = new Subject<null>();
  constructor(private http: HttpClient) { }

  // get transactions
  getTransactions(): Observable<Response>{
    return this.http.get<Response>(this.baseApiUrl+"api/Transaction/GetTransactions");
  }
}
