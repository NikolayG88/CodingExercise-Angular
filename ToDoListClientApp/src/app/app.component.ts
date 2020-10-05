import { AuthService } from 'src/services/auth.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ToDoListWebApp';


  constructor(private router: Router, private authService: AuthService) {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['todolist']);
    }else{
      this.router.navigate(['login']);
    }
  }
}
