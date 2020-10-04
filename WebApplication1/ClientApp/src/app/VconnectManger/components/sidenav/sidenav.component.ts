import { Component, OnInit, NgZone } from '@angular/core';
import { User } from '../../../components/models/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserService } from '../../../components/services/user.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  private mediaMatcher = matchMedia('(max-width: 792px)');
  users: Observable<User[]>;

  constructor(ngzone: NgZone, private userService: UserService) {
    this.mediaMatcher.addListener(mql => ngzone.run(() => this.mediaMatcher = matchMedia('(max-width: 800px)')));
  }

  ngOnInit(): void {
    this.users = this.userService.users;
    this.userService.loadAll();
    this.users.subscribe(data => console.log(data));
  }

  isScreenSmall(): boolean {
    return this.mediaMatcher.matches;
  }
}
