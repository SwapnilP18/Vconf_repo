import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class UserService {

  private dataStore : {
  users: User[];
  }
  private _users: BehaviorSubject<User[]>;

  constructor(private http: HttpClient) {
    this.dataStore = { users: [] };
    this._users = new BehaviorSubject<User[]>([]);
  }

  get users(): Observable<User[]> {
    return this._users.asObservable();
  }

  loadAll() {
    const url = "https://angular-material-api.azurewebsites.net/users";
    this.http.get<User[]>(url).subscribe(data => {
      this.dataStore.users = data;
      this._users.next(Object.assign({}, this.dataStore).users);
    },
      error => { console.log('error fetching data') }
      )
  }
}
