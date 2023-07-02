import { NzTableSortFn, NzTableSortOrder } from 'ng-zorro-antd/table';

export interface ColumnItem {
  sortOrder: NzTableSortOrder | null;
  sortFn: NzTableSortFn | null;
  sortDirections: NzTableSortOrder[] | null;
}
