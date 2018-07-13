import { Component, OnInit } from '@angular/core';
import { Kurs } from '../models';
import { KursverwaltungService } from '../kursverwaltung.service';

@Component({
  selector: 'app-kurse',
  templateUrl: './kurse.component.html',
  styleUrls: ['./kurse.component.css']
})
export class KurseComponent implements OnInit {

  kurse: Kurs[];

  constructor(private kursverwaltungService: KursverwaltungService) {
    this.init();
  }

  async init() {
    this.kurse = await this.kursverwaltungService.getKurse();
    console.log(this.kurse.length);
  }

  ngOnInit() {
  }

}
