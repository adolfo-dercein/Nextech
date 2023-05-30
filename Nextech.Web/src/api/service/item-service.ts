import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, throwError } from 'rxjs';
import { ServiceBase } from './service-base';
import { ItemResponse } from '../model/item-response';
import { CustomResponse } from '../model/custom-response';
import { ToastService } from 'src/shared/services/toast-service';

@Injectable({
  providedIn: 'root'
})
export class ItemService extends ServiceBase
{
  constructor(private http: HttpClient, 
              private toastService: ToastService) { super() }

  getItemList(pageNumber: number, pageSize: number): Observable<ItemResponse>
  {
    return this.http.get<CustomResponse>(`${ this.url }/item/GetStories`, 
    { 
      params: 
      { 
        'pageNumber': pageNumber, 
        'pageSize': pageSize
      } 
    }).pipe(map((result: CustomResponse) => 
    {
      if(result.success)
      {
        return result.data 
      } 
      else
      {
        this.toastService.show(`ERROR: ${ result.message }`);
      }
    }))
  }

  getSearchItemList(searchTerm: string): Observable<ItemResponse>
  {
    return this.http.get<CustomResponse>(`${ this.url }/item/SearchStories`, 
    { 
      params: 
      { 
        'searchTerm': searchTerm
      } 
    }).pipe(map((result: CustomResponse) => 
    {
      if(result.success)
      {
        return result.data 
      } 
      else
      {
        this.toastService.show(`ERROR: ${ result.message }`);
      }
    }))
  }
}
