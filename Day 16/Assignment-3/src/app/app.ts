import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Display } from '../components/display/display';
import { Arraydisplay } from '../components/arraydisplay/arraydisplay';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Display,Arraydisplay],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-3');
}
