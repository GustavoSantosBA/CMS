import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  pageTitle = 'sdfasd';
  userName = '';
  constructor(
    private appComponentes : AppComponent
    ) {

   }

  ngOnInit() {

  }

}
