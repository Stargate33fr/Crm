/* eslint-disable no-shadow */
import { GridsterPage } from '@models/gridster-page';
import { IWidgetItem } from '@models/widget';
import { Action } from '@ngrx/store';

export enum WidgetListActionTypes {
  widgetList = '[WidgetList] Get Widget List',
  setWidgetList = '[WidgetList] Set Widget List',
  addWidgetForListAdd = '[WidgetList] Add Widget to ListAdd',
  removeWidgetForListAdd = '[WidgetList] Remove Widget to ListAdd',
}

export class WidgetList implements Action {
  public readonly type = WidgetListActionTypes.widgetList;
  constructor(public payload: { page: GridsterPage; widgets: IWidgetItem[] }) {}
}

export class SetWidgetList implements Action {
  public readonly type = WidgetListActionTypes.setWidgetList;
  constructor(public payload: GridsterPage) {}
}

export class AddWidgetForListAdd implements Action {
  public readonly type = WidgetListActionTypes.addWidgetForListAdd;
  constructor(public payload: { page: GridsterPage; widget: IWidgetItem }) {}
}

export class RemoveWidgetForListAdd implements Action {
  public readonly type = WidgetListActionTypes.removeWidgetForListAdd;
  constructor(public payload: { page: GridsterPage; widget: IWidgetItem }) {}
}

export type WidgetListActions = WidgetList | SetWidgetList | AddWidgetForListAdd | RemoveWidgetForListAdd;
