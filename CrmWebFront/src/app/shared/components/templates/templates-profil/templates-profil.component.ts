import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'templates-profil',
  templateUrl: './templates-profil.component.html',
  styleUrls: ['./templates-profil.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TemplatesProfilComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
