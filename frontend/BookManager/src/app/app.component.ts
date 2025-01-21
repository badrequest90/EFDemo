import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthorDetailsComponent } from "./author-details/author-details.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AuthorDetailsComponent, AuthorDetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'BookManager';
}
