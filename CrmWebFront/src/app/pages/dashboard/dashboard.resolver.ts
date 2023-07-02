import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { GridsterPage } from '@models/gridster-page';
import { IWidgetItem } from '@models/widget';
import { WidgetService } from '@services/widget.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DashboardResolver implements Resolve<any> {
  constructor(private widgetService: WidgetService) {}

  resolve(): Observable<IWidgetItem[]> {
    return this.widgetService.widgetsParPage(GridsterPage.home);
  }
}
