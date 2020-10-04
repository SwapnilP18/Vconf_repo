import { Note } from "./note";

export class User {
  id: number;
  name: string;
  avatar: string;
  bio: string;
  birthDate: Date;

  note: Note[] = [];
}
