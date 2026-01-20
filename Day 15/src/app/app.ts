import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from '../components/nav-bar/nav-bar';
import { Description } from '../components/description/description';
import { WelcomeBanner } from '../components/welcome-banner/welcome-banner';
import { Profiles } from '../components/profiles/profiles';
import { Footer } from '../components/footer/footer';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavBar,Description,WelcomeBanner,Profiles,Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('First');
}
