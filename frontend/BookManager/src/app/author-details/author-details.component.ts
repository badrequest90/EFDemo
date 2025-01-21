import { Component, Input, OnInit } from '@angular/core';
import { Author, authors } from '../author';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-author-details',
  imports: [CommonModule, MatCardModule, MatChipsModule, RouterLink],
  templateUrl: './author-details.component.html',
  styleUrl: './author-details.component.scss'
})
export class AuthorDetailsComponent implements OnInit {
  @Input() author: Author | null = authors[0];

  ngOnInit() {

  }
}
