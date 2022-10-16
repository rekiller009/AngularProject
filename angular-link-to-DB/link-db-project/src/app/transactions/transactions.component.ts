import { Component, OnInit } from '@angular/core';
import { Transaction } from '../models/account-management/transaction.model';
import { TransactionService } from '../services/transaction-services/transaction.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  constructor(private transactionService:TransactionService) { }
  transactions: Transaction[] = [];
  ngOnInit(): void {
    this.getTransactions();
  }


  getTransactions():void{
    this.transactionService.getTransactions()
      .subscribe({
        next:(transaction)=>{
          console.log(transaction);
          this.transactions = transaction.result;
        },
        error:(response) => {
          console.log(response);
        }
      })
  }
}
