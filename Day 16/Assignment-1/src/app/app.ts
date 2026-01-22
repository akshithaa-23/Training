import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListEmployees } from '../componets/employees/list-employees';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ListEmployees],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-1');
}
