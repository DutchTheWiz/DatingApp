import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in sucessfully');
      },
      error => {
        this.alertify.error(error); // failed to login
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
    // old way
    // const token = localStorage.getItem('token');
    // return !!token; // same as return token === '' ? true : false ; **** intresteng syntax
  }

logout() {
  localStorage.removeItem('token');
  this.alertify.message('Logged out');
}

}
