import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in sucessfully');
        // this.router.navigate(['/members']); can be here or as a 3rd parametar
      },
      error => {
        this.alertify.error(error); // failed to login
      }, () => {
         this.router.navigate(['/members']);
      });
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
  this.router.navigate(['/home']);
}

}
