import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users$: Observable<User[]>;
  user$: User;

  constructor(private userService: UserService) {
  }

  @ViewChild('somenteAtivos', {static: true}) somenteAtivos: ElementRef;
  @ViewChild('searchBox', {static: true}) searchBox: ElementRef;

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.users$ = this.userService.getUsers('', false);
  }

  reloadUsers() {
    const somenteAtivosValue = this.somenteAtivos.nativeElement.checked;
    const searchBoxValue = this.searchBox.nativeElement.value;

    this.users$ = this.userService.getUsers(searchBoxValue, somenteAtivosValue ?? false);
  }

  fillUser(userId) {
    this.userService.getUser(userId).subscribe((data) => {
      this.user$ = data;
    });
  }

  update(userId) {
    this.fillUser(userId);
    Swal.fire({
      text: `Tem certeza que deseja alterar o status do usuário de Id: ${userId}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Sim, alterar!'
    }).then((result) => {
      if (result.value) {
        this.userService.updateUserState(userId, this.user$).subscribe((data) => {
          this.loadUsers();
          Swal.fire(
            '',
            'Usuário alterado com sucesso!',
            'success'
          );
        });
      }
    });
  }

  delete(userId) {
    Swal.fire({
      text: `Tem certeza que deseja excluir o usuário de Id: ${userId}?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancelar',
      confirmButtonText: 'Sim, exclua!'
    }).then((result) => {
      if (result.value) {
        this.userService.deleteUser(userId).subscribe((data) => {
          this.loadUsers();
          Swal.fire(
            '',
            'Usuário excluído com sucesso!',
            'success'
          );
        });
      }
    });
  }
}
