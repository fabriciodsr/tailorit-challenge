import { Gender } from './gender';

export class User {
    id?: number;
    name: string;
    birthDate: Date;
    email: string;
    gender: Gender;
    genderId: number;
    active: boolean;
    password: string;
  }