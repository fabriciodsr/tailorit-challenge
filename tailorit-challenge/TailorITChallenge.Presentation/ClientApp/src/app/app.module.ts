import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './user/user.component';
import { UserAddEditComponent } from './user-add-edit/user-add-edit.component';
import { UserService } from './services/user.service';
import { JwtService } from './services/jwt.service';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserComponent,
    UserAddEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: function  tokenGetter() {
          return localStorage.getItem('access_token');
        },
        whitelistedDomains: [environment.appDomain],
        blacklistedRoutes: [environment.appAuthUrl]
      }
    })
  ],
  providers: [
    UserService,
    JwtService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
