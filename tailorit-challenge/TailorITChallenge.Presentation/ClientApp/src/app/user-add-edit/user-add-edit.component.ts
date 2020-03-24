import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { Gender } from '../models/gender';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-add-edit',
  templateUrl: './user-add-edit.component.html',
  styleUrls: ['./user-add-edit.component.scss']
})
export class UserAddEditComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formName: string;
  formBirthDate: string;
  formEmail: string;
  formGender: string;
  formPassword: string;
  formActive: string;
  userId: number;
  errorMessage: any;
  existingUser: User;

  constructor(private userService: UserService, private formBuilder: FormBuilder, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';
    this.actionType = 'Adicionar';
    this.formName = 'name';
    this.formBirthDate = 'birthDate';
    this.formEmail = 'email';
    this.formGender = 'gender';
    this.formPassword = 'password';
    this.formActive = 'active';
    if (this.avRoute.snapshot.params[idParam]) {
      this.userId = this.avRoute.snapshot.params[idParam];
    }

    this.form = this.formBuilder.group(
      {
        userId: 0,
        name: ['', [Validators.required, Validators.minLength(3)]],
        birthDate: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        gender: ['', [Validators.required]],
        password: ['', [Validators.required]],
        active: ['', [Validators.required]]
      }
    );
  }

  ngOnInit() {

    if (this.userId > 0) {
      this.actionType = 'Editar';
      this.userService.getUser(this.userId)
        .subscribe(data => (
          this.existingUser = data,
          this.form.controls[this.formName].setValue(data.name),
          this.form.controls[this.formBirthDate].setValue(data.birthDate),
          this.form.controls[this.formEmail].setValue(data.email),
          this.form.controls[this.formGender].setValue(data.genderId),
          this.form.controls[this.formPassword].setValue(data.password),
          this.form.controls[this.formActive].setValue(data.active)
        ));
    }
  }

  save() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Adicionar') {
      let user: User = {
        name: this.form.get(this.formName).value,
        birthDate: this.form.get(this.formBirthDate).value,
        email: this.form.get(this.formEmail).value,
        gender: null,
        genderId: parseInt(this.form.get(this.formGender).value),
        password: this.form.get(this.formPassword).value,
        active: JSON.parse(this.form.get(this.formActive).value)
      };
      this.userService.saveUser(user)
        .subscribe((data) => {
          this.router.navigate(['/user', data]);
          Swal.fire(
            '',
            'Usuário adicionado com sucesso!',
            'success'
          );
        });
    }

    if (this.actionType === 'Editar') {
      let user: User = {
        id: this.existingUser.id,
        name: this.form.get(this.formName).value,
        birthDate: this.form.get(this.formBirthDate).value,
        email: this.form.get(this.formEmail).value,
        gender: null,
        genderId: parseInt(this.form.get(this.formGender).value),
        password: this.form.get(this.formPassword).value,
        active: JSON.parse(this.form.get(this.formActive).value)
      };
      this.userService.updateUser(user.id, user)
        .subscribe((data) => {
          this.router.navigate([this.router.url]);
          Swal.fire(
            '',
            'Usuário alterado com sucesso!',
            'success'
          );
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get name() { return this.form.get(this.formName); }
  get birthDate() { return this.form.get(this.formBirthDate); }
  get email() { return this.form.get(this.formEmail); }
  get gender() { return this.form.get(this.formGender); }
  get password() { return this.form.get(this.formPassword); }
  get active() { return this.form.get(this.formActive); }
}
