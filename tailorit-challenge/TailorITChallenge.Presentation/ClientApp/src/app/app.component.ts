import { Component, OnInit } from '@angular/core';
import { JwtService } from './services/jwt.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TailorIT Challenge';

  constructor(private jwtService: JwtService) {
  }

  ngOnInit() {
    this.getToken();
  }

  getToken() {
    this.jwtService.getToken('test', 'test');
  }
}
