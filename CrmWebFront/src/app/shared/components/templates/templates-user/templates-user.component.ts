import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-templates-user',
  templateUrl: './templates-user.component.html',
  styleUrls: ['./templates-user.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TemplatesUserComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
